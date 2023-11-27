using larpex_events.contracts.Contracts.DataTransferObjects;
using larpex_events.contracts.Contracts.Requests;
using larpex_events.contracts.Contracts.Responses;
using larpex_events.Domain;

namespace larpex_events.Services.Mapper;

public static class MapperExtensionMethods
{
    public static EventDTO MapToEventDTO(this Event eventObject)
    {
        return new EventDTO
        {
            Id = eventObject.Id.ToString(),
            Name = eventObject.Name,
            DescriptionForClient = eventObject.DescriptionForClients.TextDescription,
            DescriptionForEmployee = eventObject.DescriptionForEmployees.TechnicalDescription,
            Price = eventObject.Price,
            Location= eventObject.Location.Id,
            Date = eventObject.EventDate,
            CurrentlySignedPlayers = eventObject.CurrentlySignedPlayers,
        };
    }

    public static ReadEventResponse MapToReadEventResponse(this Event eventObject)
    {
        return new ReadEventResponse
        {
            Event = eventObject.MapToEventDTO()
        };
    }

    public static CreateEventResponse MapToCreateEventResponse(this Event eventObject)
    {
        return new CreateEventResponse
        {
            Event = eventObject.MapToEventDTO()
        };
    }

    public static UpdateEventResponse MapToUpdateEventResponse(this Event eventObject)
    {
        return new UpdateEventResponse
        {
            Event = eventObject.MapToEventDTO()
        };
    }

    public static UpdateEventSettingsResponse MapToUpdateEventSettingsResponse(this Event eventObject)
    {
        return new UpdateEventSettingsResponse
        {
            EventSettings = new EventSettingsDTO
            {
                MaxPlayerLimit = eventObject.Settings?.MaxPlayerLimit,
                IsVisible = eventObject.Settings?.IsVisible,
                IsExternalOrganiser = eventObject.Settings?.IsExternalOrganiser,
            }
        };
    }

    public static GetEventsResponse MapToGetEventsResponse(this List<Event> events)
    {
        return new GetEventsResponse
        {
            Events = events.Select(e => e.MapToEventDTO()).ToList()
        };
    }

    public static Event MapToEvent(this CreateEventRequest createEventRequest)
    {
        return new Event
        {
            Id = Guid.NewGuid(),
            Name = createEventRequest.Event.Name,
            Price = createEventRequest.Event.Price,
            EventDate = createEventRequest.Event.EventDate,
            CurrentlySignedPlayers = createEventRequest.Event.CurrentlySignedPlayers,
            DescriptionForClients = new EventDescriptionForClient
            {
                TextDescription = createEventRequest.Event.ClientDescription
            },
            DescriptionForEmployees = new EventDescriptionForEmployee
            {
                TechnicalDescription = createEventRequest.Event.EmployeeDescription
            },
            Location = new Location()
            {
                Id = createEventRequest.Event.Location
            },
            Game = new Game()
            {
                Id = createEventRequest.Event.Game
            }
        };
    }

    public static Event MapToEvent(this UpdateEventRequest updateEventRequest)
    {
        return new Event
        {
            Name = updateEventRequest.Event.Name,
            DescriptionForClients = new EventDescriptionForClient
            {
                TextDescription = updateEventRequest.Event.ClientDescription
            },
            DescriptionForEmployees = new EventDescriptionForEmployee
            {
                TechnicalDescription = updateEventRequest.Event.EmployeeDescription
            },
            EventDate = updateEventRequest.Event.EventDate,
            CurrentlySignedPlayers = updateEventRequest.Event.CurrentlySignedPlayers
        };
    }

    public static EventSettings MapToEventSettings(this UpdateEventSettingsRequest updateEventSettingsRequest)
    {
        return new EventSettings
        {
            MaxPlayerLimit = updateEventSettingsRequest.EventSettings.MaxPlayerLimit,
            IsVisible = updateEventSettingsRequest.EventSettings.IsVisible,
            IsExternalOrganiser = updateEventSettingsRequest.EventSettings.IsExternalOrganiser
        };
    }
}
