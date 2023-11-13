using larpex_events.Contracts.Responses;
using larpex_events.Domain.Enums;

namespace larpex_events.Services.Interface;

public interface IEventsEmployeeService
{
    GetEventsResponse GetEvents();
    GetEventsResponse GetEventsByStatus(EventStatus status);
    GetEventsResponse GetEventsByOwner(string ownerEmail);
}
