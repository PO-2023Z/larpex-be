using larpex_events.Contracts.Responses;
using larpex_events.Domain.Enums;
using larpex_events.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace larpex_events.Controllers;

[ApiController]
[Route("[controller]")]
public class EventsInternalEmployeeController : ControllerBase
{
    private readonly IEventsEmployeeService _eventsService;

    public EventsInternalEmployeeController(IEventsEmployeeService eventsService)
    {
        _eventsService = eventsService;
    }

    [HttpGet]
    public async Task<GetEventsResponse> GetEvents()
    {
        return _eventsService.GetEvents();
    }

    [HttpGet("{eventStatus}")]
    public async Task<GetEventsResponse> GetEventsByStatus(EventStatus status)
    {
        return _eventsService.GetEventsByStatus(status);
    }

    [HttpGet("{ownerEmail}")]
    public async Task<GetEventsResponse> GetEventsByStatus(string ownerEmail)
    {
        return _eventsService.GetEventsByOwner(ownerEmail);
    }
}