using larpex_events.contracts.Contracts.Responses;
using larpex_events.Domain.Enums;
using larpex_events.Services.Interface;
using larpex_events.Services.Mapper;

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
        return _eventsRepository.GetAll().MapToGetEventsResponse();
    }

    public GetEventsResponse GetEventsByOwner(string ownerEmail)
    {
        return _eventsRepository.GetAll()
            .Where(e => e.OwnerEmail == ownerEmail)
            .ToList()
            .MapToGetEventsResponse();
    }

    public GetEventsResponse GetEventsByStatus(EventStatus status)
    {
        return _eventsRepository.GetAll()
            .Where(e => e.Status == status)
            .ToList()
            .MapToGetEventsResponse();
    }
}
