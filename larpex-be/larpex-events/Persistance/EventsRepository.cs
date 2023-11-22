using larpex_events.Domain;
using larpex_events.Domain.Enums;
using larpex_events.Services.Interface;
using Event = larpex_events.Persistance.DTOs.Event;

namespace larpex_events.Persistance;

public class EventsRepository : IEventsRepository
{
    private readonly LarpexContext _larpexContext;

    public EventsRepository(LarpexContext larpexContext)
    {
        _larpexContext = larpexContext;
    }

    public void Add(Domain.Event eventObject)
    {
        var eventDto = MapToEventDTO(eventObject);
        _larpexContext.Events.Add(eventDto);
        _larpexContext.SaveChanges();
    }

    public Domain.Event? Get(Guid eventId)
    {
        var eventDto = _larpexContext.Events.FirstOrDefault(e => e.Eventid == eventId.ToString());
        if(eventDto == null)
        {
            return null;
        }
        
        return MapToEvent(eventDto);
    }

    public List<Domain.Event> GetAll()
    {
        var eventDtos = _larpexContext.Events.ToList();
        List<Domain.Event> events = new List<Domain.Event>();
        
        foreach (var eventDto in eventDtos)
        {
            events.Add(MapToEvent(eventDto));
        }
        
        return events;
    }

    public void Remove(Guid eventId)
    {
        var eventDto = _larpexContext.Events.FirstOrDefault(eventObj => eventObj.Eventid == eventId.ToString());
        if(eventDto == null)
        {
            return;
        }
        _larpexContext.Events.Remove(eventDto);
        _larpexContext.SaveChanges();
    }

    public void Update(Domain.Event eventObject)
    {
        var eventDto = MapToEventDTO(eventObject);
        _larpexContext.Events.Update(eventDto);
        _larpexContext.SaveChanges();
    }

    private Domain.Event MapToEvent(Event eventDto)
    {
        // Map Event object into Domain.Event object
        return new Domain.Event
        {
            Id = new Guid(eventDto.Eventid),
            Name = eventDto.Eventname ?? "Event name missing",
            OwnerEmail = "owner@gmail.com",
            Status = (Domain.Enums.EventStatus)Enum.Parse(typeof(Domain.Enums.EventStatus), eventDto.Eventstate ?? "Created"),
            Price = eventDto.Priceperuser ?? 0,
            Paid = eventDto.Paidfor ?? false,
            Game = new Game { Id = eventDto.Gameid != null ?  new Guid(eventDto.Gameid) : Guid.Empty },
            Location = new Location {Id = eventDto.Placeid != null ? new Guid(eventDto.Placeid) : Guid.Empty },
            DescriptionForClients = MapToEventDescriptionForClient(eventDto.Description, eventDto.Startdate),
            DescriptionForEmployees = MapToEventDescriptionForEmployee(eventDto.Description, eventDto.Description, eventDto.Startdate),
            Settings = MapToEventSettings()
        };
    }
    
    private Event MapToEventDTO(Domain.Event eventObject)
    {
        // Map Domain.Event object into Event object
        return new Event
        {
            Eventid = eventObject.Id.ToString(),
            Eventname = eventObject.Name,
            Eventstate = eventObject.Status.ToString(),
            Priceperuser = eventObject.Price,
            Paidfor = eventObject.Paid,
            Gameid = eventObject.Game.Id.ToString(),
            Placeid = eventObject.Location.Id.ToString(),
            Description = eventObject.DescriptionForClients.TextDescription,
            Startdate = TimeOnly.FromDateTime(eventObject.DescriptionForClients.Date),
            Enddate = TimeOnly.FromDateTime(eventObject.DescriptionForClients.Date).AddHours(2)
        };
    }
    
    private Domain.EventDescriptionForClient MapToEventDescriptionForClient(string? description, TimeOnly? startDate)
    {
        TimeOnly newStartDate = startDate ?? TimeOnly.FromDateTime(DateTime.Now);
        return new Domain.EventDescriptionForClient
        {
            Date = DateOnly.FromDateTime(DateTime.Now).ToDateTime(newStartDate),
            TextDescription = description ?? String.Empty
        };
    }
    
    private Domain.EventDescriptionForEmployee MapToEventDescriptionForEmployee(string? description, string? technicalDescription, TimeOnly? startDate)
    {
        TimeOnly newStartDate = startDate ?? TimeOnly.FromDateTime(DateTime.Now);
        return new Domain.EventDescriptionForEmployee
        {
            Date = DateOnly.FromDateTime(DateTime.Now).ToDateTime(newStartDate),
            TextDescription = description ?? String.Empty,
            TechnicalDescription = technicalDescription ?? String.Empty
        };
    }

    private Domain.EventSettings MapToEventSettings()
    {
        return new EventSettings
        {
            IsExternalOrganiser = true,
            IsVisible = true,
            MaxPlayerLimit = 50
        };
    }
}
