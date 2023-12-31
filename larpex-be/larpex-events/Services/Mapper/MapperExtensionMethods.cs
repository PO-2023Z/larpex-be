﻿using larpex_events.contracts.Contracts.DataTransferObjects.Event;
using larpex_events.contracts.Contracts.Requests;
using larpex_events.contracts.Contracts.Requests.Event;
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
            PricePerUser = eventObject.PricePerUser,
            EventPrice = eventObject.EventPrice,
            Location = eventObject.Location.Id,
            Game = eventObject.Game.Id,
            StartDate = eventObject.StartDate.ToLocalTime(),
            EndDate = eventObject.EndDate.ToLocalTime(),
            CurrentlySignedPlayers = eventObject.CurrentlySignedPlayers,
            OwnerEmail = eventObject.OwnerEmail,
            EventStatus = eventObject.Status.ToString(),
            EventSettings = eventObject.Settings?.MapToSettingsDTO()
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
            PricePerUser = createEventRequest.Event.PricePerUser,
            StartDate = createEventRequest.Event.StartDate.ToLocalTime(),
            EndDate = createEventRequest.Event.EndDate.ToLocalTime(),
            CurrentlySignedPlayers = createEventRequest.Event.CurrentlySignedPlayers,
            Settings = createEventRequest.EventSettings?.MapToEventSettings(),
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

    public static Event MapToEvent(this UpdateEventRequest updateEventRequest, Event eventObject)
    {
        eventObject.Name = updateEventRequest.Event.Name ?? eventObject.Name;
        eventObject.DescriptionForEmployees.TextDescription = updateEventRequest.Event.EmployeeDescription ?? eventObject.DescriptionForEmployees.TextDescription;
        eventObject.DescriptionForClients.TextDescription = updateEventRequest.Event.ClientDescription ?? eventObject.DescriptionForClients.TextDescription;
        eventObject.StartDate = updateEventRequest.Event.StartDate?.ToLocalTime() ?? eventObject.StartDate;
        eventObject.EndDate = updateEventRequest.Event.EndDate?.ToLocalTime() ?? eventObject.EndDate;
        eventObject.CurrentlySignedPlayers = updateEventRequest.Event.CurrentlySignedPlayers ?? eventObject.CurrentlySignedPlayers;
        eventObject.PricePerUser = updateEventRequest.Event.PricePerUser ?? eventObject.PricePerUser;
        eventObject.Status = (Domain.Enums.EventStatus?)Enum.Parse(typeof(Domain.Enums.EventStatus), updateEventRequest.Event.EventStatus) ?? eventObject.Status;
        
        return eventObject;
    }

    public static EventSettings MapToEventSettings(this UpdateEventSettingsRequest updateEventSettingsRequest, EventSettings settings)
    {
        settings.MaxPlayerLimit = updateEventSettingsRequest.EventSettings.MaxPlayerLimit ?? settings.MaxPlayerLimit;
        settings.IsVisible = updateEventSettingsRequest.EventSettings.IsVisible ?? settings.IsVisible;
        settings.IsExternalOrganiser = updateEventSettingsRequest.EventSettings.IsExternalOrganiser ?? settings.IsExternalOrganiser;

        return settings;
    }

    public static EventSettingsDTO MapToSettingsDTO(this EventSettings settings)
    {
        return new EventSettingsDTO
        {
            MaxPlayerLimit = settings.MaxPlayerLimit,
            IsExternalOrganiser = settings.IsExternalOrganiser,
            IsVisible = settings.IsVisible,
        };
    }

    public static EventSettings MapToEventSettings(this EventSettingsDTO settingsDTO)
    {
        return new EventSettings
        {
            MaxPlayerLimit = settingsDTO.MaxPlayerLimit,
            IsExternalOrganiser = settingsDTO.IsExternalOrganiser,
            IsVisible = settingsDTO.IsVisible,
        };
    }
}
