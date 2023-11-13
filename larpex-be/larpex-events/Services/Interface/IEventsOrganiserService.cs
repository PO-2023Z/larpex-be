using larpex_events.contracts.Contracts.Requests;
using larpex_events.contracts.Contracts.Responses;

namespace larpex_events.Services.Interface;

public interface IEventsOrganiserService
{
    CreateEventResponse CreateEvent(CreateEventRequest request, string requestOwnerEmail);
    ReadEventResponse ReadEvent(Guid eventId, string requestOwnerEmail);
    UpdateEventResponse UpdateEvent(Guid eventId, UpdateEventRequest request, string requestOwnerEmail);
    void DeleteEvent(Guid eventId, string requestOwnerEmail);
    GetEventsResponse GetEvents(string requestOwnerEmail);
    UpdateEventSettingsResponse UpdateEventSettings(Guid eventId, UpdateEventSettingsRequest request, string requestOwnerEmail);
    //PayResponse Pay(Payment payment);
}
