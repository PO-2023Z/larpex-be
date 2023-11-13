using larpex_events.contracts.Contracts.Requests;
using larpex_events.contracts.Contracts.Responses;
using larpex_events.Services.Interface;

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
        throw new NotImplementedException();
    }

    public void DeleteEvent(Guid eventId, string requestOwnerEmail)
    {
        throw new NotImplementedException();
    }

    public GetEventsResponse GetEvents(string requestOwnerEmail)
    {
        throw new NotImplementedException();
    }

    public ReadEventResponse ReadEvent(Guid eventId, string requestOwnerEmail)
    {
        throw new NotImplementedException();
    }

    public UpdateEventResponse UpdateEvent(Guid eventId, UpdateEventRequest request, string requestOwnerEmail)
    {
        throw new NotImplementedException();
    }

    public UpdateEventSettingsResponse UpdateEventSettings(Guid eventId, UpdateEventSettingsRequest request, string requestOwnerEmail)
    {
        throw new NotImplementedException();
    }
}
