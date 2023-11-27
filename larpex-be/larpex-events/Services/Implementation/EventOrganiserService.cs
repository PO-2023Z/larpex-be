using larpex_events.contracts.Contracts.Requests;
using larpex_events.contracts.Contracts.Responses;
using larpex_events.Services.Interface;
using larpex_events.Services.Mapper;
using System.Net;

namespace larpex_events.Services.Implementation;

public class EventOrganiserService : IEventsOrganiserService
{
    private readonly decimal PricePerHour = 500;

    private readonly IEventsRepository _eventsRepository;
    //private readonly IPaymentAdapter _paymentAdapter;
    // private readonly ILocations _locations;

    public EventOrganiserService(IEventsRepository eventsRepository)
    {
        _eventsRepository = eventsRepository;
        // _locations = locations;
    }

    public CreateEventResponse CreateEvent(CreateEventRequest request, string requestOwnerEmail)
    {
        var eventObject = request.MapToEvent();
        eventObject.OwnerEmail = requestOwnerEmail;

        if (eventObject.StartDate > eventObject.EndDate)
        {
            throw new ArgumentException($"Start date must be before end date");
        }

        var hours = (eventObject.EndDate - eventObject.StartDate).TotalHours;
        eventObject.EventPrice = this.PricePerHour * (decimal)hours;

        eventObject.Status = Domain.Enums.EventStatus.Created;

        _eventsRepository.Add(eventObject);

        return eventObject.MapToCreateEventResponse();
    }

    public void DeleteEvent(Guid eventId, string requestOwnerEmail)
    {
        var eventObject = _eventsRepository.Get(eventId)
            ?? throw new Exception($"Event with ID: {eventId} does not exist");

        if (eventObject.OwnerEmail != requestOwnerEmail)
        {
            throw new Exception($"Person with email: {requestOwnerEmail} is not authorized to this Event");
        }

        _eventsRepository.Remove(eventId);
    }

    public GetEventsResponse GetEvents(string requestOwnerEmail)
    {
        return _eventsRepository.GetAll()
            .Where(e => e.OwnerEmail == requestOwnerEmail)
            .ToList()
            .MapToGetEventsResponse();
    }

    public ReadEventResponse? ReadEvent(Guid eventId, string requestOwnerEmail)
    {
        var eventObject = _eventsRepository.Get(eventId)
            ?? throw new Exception($"Event with ID: {eventId} does not exist");

        if (eventObject.OwnerEmail != requestOwnerEmail)
        {
            throw new Exception($"Person with email: {requestOwnerEmail} is not authorized to this Event");
        }

        return eventObject.MapToReadEventResponse();
    }

    public UpdateEventResponse UpdateEvent(Guid eventId, UpdateEventRequest request, string requestOwnerEmail)
    {
        var eventObject = _eventsRepository.Get(eventId)
            ?? throw new Exception($"Event with ID: {eventId} does not exist");

        if (eventObject.OwnerEmail != requestOwnerEmail)
        {
            throw new Exception($"Person with email: {requestOwnerEmail} is not authorized to this Event");
        }

        eventObject = request.MapToEvent(eventObject);
        eventObject.OwnerEmail = requestOwnerEmail;

        if (eventObject.StartDate > eventObject.EndDate)
        {
            throw new ArgumentException($"Start date must be before end date");
        }

        var hours = (eventObject.EndDate - eventObject.StartDate).TotalHours;
        eventObject.EventPrice = this.PricePerHour * (decimal)hours;

        _eventsRepository.Update(eventObject);

        return eventObject.MapToUpdateEventResponse();
    }

    public UpdateEventSettingsResponse UpdateEventSettings(Guid eventId, UpdateEventSettingsRequest request, string requestOwnerEmail)
    {
        var eventObject = _eventsRepository.Get(eventId) 
            ?? throw new Exception($"Event with ID: {eventId} does not exist");

        if (eventObject.OwnerEmail != requestOwnerEmail)
        {
            throw new Exception($"Person with email: {requestOwnerEmail} is not authorized to this Event");
        }

        eventObject.Settings = request.MapToEventSettings(eventObject.Settings);

        _eventsRepository.Update(eventObject);

        return eventObject.MapToUpdateEventSettingsResponse();
    }
}
