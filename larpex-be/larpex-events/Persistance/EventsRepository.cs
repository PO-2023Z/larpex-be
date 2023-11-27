using larpex_events.Domain;
using larpex_events.Domain.Enums;
using larpex_events.Services.Interface;

namespace larpex_events.Persistance;

public class EventsRepository : IEventsRepository
{
    private readonly LarpexdbContext _larpexContext;

    public EventsRepository(LarpexdbContext larpexContext)
    {
        _larpexContext = larpexContext;
    }

    public void Remove(Guid eventId)
    {
        var eventDto = _larpexContext.Events.FirstOrDefault(eventObj => eventObj.Eventid == eventId);
        if (eventDto == null) return;
        _larpexContext.Events.Remove(eventDto);
        _larpexContext.SaveChanges();
    }


    public void SetPaymentStatus(Guid eventId, bool paid)
    {
        return;
        throw new NotImplementedException();
    }

    public void Add(Event eventObject)
    {
        var eventDto = MapToEventDTO(eventObject);
        _larpexContext.Events.Add(eventDto);
        _larpexContext.SaveChanges();
    }

    public Event? Get(Guid eventId)
    {
        var eventDto = _larpexContext.Events.FirstOrDefault(e => e.Eventid == eventId);
        if (eventDto == null) return null;

        return MapToEvent(eventDto);
    }

    public List<Event> GetAll()
    {
        var eventDtos = _larpexContext.Events.ToList();
        var events = new List<Event>();

        foreach (var eventDto in eventDtos) events.Add(MapToEvent(eventDto));

        return events;
    }

    public void Update(Event eventObject)
    {
        var eventDto = MapToEventDTO(eventObject);
        _larpexContext.Events.Update(eventDto);
        _larpexContext.SaveChanges();
    }

    private Event MapToEvent(DTOs.Event eventDto)
    {
        // Map Event object into Domain.Event object
        return new Event
        {
            Id = eventDto.Eventid,
            Name = eventDto.Eventname ?? "Event name missing",
            OwnerEmail = eventDto.Owneremail ?? "Owner email missing",
            Status = (EventStatus)Enum.Parse(typeof(EventStatus), eventDto.Eventstate ?? "Created"),
            StartDate = eventDto.Startdate ?? DateTime.Now,
            EndDate = eventDto.Enddate ?? DateTime.Now,
            CurrentlySignedPlayers = eventDto.Players.Count,
            PricePerUser = eventDto.Priceperuser ?? 0,
            EventPrice = eventDto.Eventprice ?? 0,
            Paid = eventDto.Paidfor ?? false,
            Game = new Game { Id = eventDto.Gameid ?? Guid.Empty },
            Location = new Location { Id = eventDto.Placeid ?? Guid.Empty },
            DescriptionForClients = MapToEventDescriptionForClient(eventDto.Descriptionforclients, eventDto.Startdate),
            DescriptionForEmployees =
                MapToEventDescriptionForEmployee(eventDto.Descriptionforemployees, eventDto.Technicaldescription, eventDto.Startdate),
            Settings = MapToEventSettings(eventDto.Isexternalorganiser ?? true, eventDto.Isvisible ?? false, eventDto.Maxplayerlimit ?? 50),
        };
    }

    private DTOs.Event MapToEventDTO(Event eventObject)
    {
        // Map Domain.Event object into Event object
        return new DTOs.Event
        {
            Eventid = eventObject.Id,
            Eventname = eventObject.Name,
            Owneremail = eventObject.OwnerEmail,
            Eventstate = eventObject.Status.ToString(),
            Priceperuser = eventObject.PricePerUser,
            Eventprice = eventObject.EventPrice,
            Paidfor = eventObject.Paid,
            Gameid = eventObject.Game.Id,
            Placeid = eventObject.Location.Id,
            Descriptionforclients = eventObject.DescriptionForClients.TextDescription,
            Descriptionforemployees = eventObject.DescriptionForEmployees.TextDescription,
            Technicaldescription = eventObject.DescriptionForEmployees.TechnicalDescription,
            Startdate = eventObject.StartDate,
            Enddate = eventObject.EndDate,
            Maxplayerlimit = eventObject.Settings?.MaxPlayerLimit,
            Isvisible = eventObject.Settings?.IsVisible,
            Isexternalorganiser = eventObject.Settings?.IsExternalOrganiser
        };
    }

    private EventDescriptionForClient MapToEventDescriptionForClient(string? description, DateTime? startDate)
    {
        var newStartDate = startDate ?? DateTime.Now;
        return new EventDescriptionForClient
        {
            Date = newStartDate,
            TextDescription = description ?? string.Empty
        };
    }

    private EventDescriptionForEmployee MapToEventDescriptionForEmployee(string? description,
        string? technicalDescription, DateTime? startDate)
    {
        var newStartDate = startDate ?? DateTime.Now;
        return new EventDescriptionForEmployee
        {
            Date = newStartDate,
            TextDescription = description ?? string.Empty,
            TechnicalDescription = technicalDescription ?? string.Empty
        };
    }

    public decimal GetEventPrice(Guid eventId)
    {
        throw new NotImplementedException();
    }

    private EventSettings MapToEventSettings(bool isExternalOrganiser = true, bool isVisible = true, int maxPlayerLimit = 50)
    {
        return new EventSettings
        {
            IsExternalOrganiser = isExternalOrganiser,
            IsVisible = isVisible,
            MaxPlayerLimit = maxPlayerLimit
        };
    }
}