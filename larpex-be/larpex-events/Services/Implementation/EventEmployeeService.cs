using larpex_events.contracts.Contracts.Responses;
using larpex_events.Domain.Enums;
using larpex_events.Services.Interface;

namespace larpex_events.Services.Implementation;

public class EventEmployeeService : IEventsEmployeeService
{
    private readonly IEventsRepository _eventsRepository;
    public EventEmployeeService(IEventsRepository eventRepository)
    {
        _eventsRepository = eventRepository;
    }

    public GetEventsResponse GetEvents()
    {
        throw new NotImplementedException();
    }

    public GetEventsResponse GetEventsByOwner(string ownerEmail)
    {
        throw new NotImplementedException();
    }

    public GetEventsResponse GetEventsByStatus(EventStatus status)
    {
        throw new NotImplementedException();
    }
}
