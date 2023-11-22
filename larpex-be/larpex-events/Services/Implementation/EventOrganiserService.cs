using larpex_events.contracts.Contracts.Requests;
using larpex_events.contracts.Contracts.Responses;
using larpex_events.Services.Interface;
using larpex_events.Services.Mapper;

namespace larpex_events.Services.Implementation;

public class EventOrganiserService : IEventsOrganiserService
{
    private readonly IEventsRepository _eventsRepository;
    //private readonly IPaymentAdapter _paymentAdapter;
    private readonly ILocations _locations;

    public EventOrganiserService(IEventsRepository eventsRepository, ILocations locations)
    {
        _eventsRepository = eventsRepository;
        _locations = locations;
    }

    public CreateEventResponse CreateEvent(CreateEventRequest request, string requestOwnerEmail)
    {
        var eventObject = request.MapToEvent();
        eventObject.OwnerEmail = requestOwnerEmail;

        _eventsRepository.Add(eventObject);

        return eventObject.MapToCreateEventResponse();
    }

    public void DeleteEvent(Guid eventId, string requestOwnerEmail)
    {
        var eventObject = _eventsRepository.Get(eventId)
            ?? throw new Exception($"Event with ID: {eventId} does not exist");

        if (eventObject.OwnerEmail != requestOwnerEmail)
        {
            throw new Exception("Dupa");
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
            throw new Exception("Dupa");
        }

        return eventObject.MapToReadEventResponse();
    }

    public UpdateEventResponse UpdateEvent(Guid eventId, UpdateEventRequest request, string requestOwnerEmail)
    {
        var eventObject = _eventsRepository.Get(eventId)
            ?? throw new Exception($"Event with ID: {eventId} does not exist");

        if (eventObject.OwnerEmail != requestOwnerEmail)
        {
            throw new Exception("Dupa");
        }

        eventObject = request.MapToEvent();
        eventObject.OwnerEmail = requestOwnerEmail;

        _eventsRepository.Update(eventObject);

        return eventObject.MapToUpdateEventResponse();
    }

    public UpdateEventSettingsResponse UpdateEventSettings(Guid eventId, UpdateEventSettingsRequest request, string requestOwnerEmail)
    {
        var eventObject = _eventsRepository.Get(eventId) 
            ?? throw new Exception($"Event with ID: {eventId} does not exist");

        if (eventObject.OwnerEmail != requestOwnerEmail)
        {
            throw new Exception("Dupa");
        }

        eventObject.Settings = request.MapToEventSettings();

        _eventsRepository.Update(eventObject);

        return eventObject.MapToUpdateEventSettingsResponse();
    }
}
