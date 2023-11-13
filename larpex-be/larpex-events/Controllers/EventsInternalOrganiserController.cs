using Microsoft.AspNetCore.Mvc;

namespace larpex_events.Controllers;

[ApiController]
[Route("[controller]")]
public class EventsInternalOrganiserController : ControllerBase
{
    private readonly IEventsOrganiserService _eventsService;

    public EventsInternalOrganiserController(IEventsOrganiserService eventsService)
    {
        _eventsService = eventsService;
    }

    [HttpGet()]
    public async Task<GetEventsResponse> GetEvents()
    {
        return _eventsService.GetEvents("email?");
    }

    [HttpPost()]
    public async Task<CreateEventResponse> CreateEvent(CreateEventRequest request)
    {
        return _eventsService.CreateEvent(request, "email?");
    }

    [HttpGet("{eventId}")]
    public async Task<ReadEventResponse> ReadEvent(Guid eventId)
    {
        return _eventsService.ReadEvent(eventId, "email?");
    }

    [HttpPut("settings/{eventId}")]
    public async Task<UpdateEventSettingsResponse> UpdateEventSettings(Guid eventId, UpdateEventSettingsRequest request)
    {
        return _eventsService.UpdateEventSettings(eventId, request, "email?");
    }

    [HttpPut("{eventId}")]
    public async Task<UpdateEventResponse> UpdateEvent(Guid eventId, UpdateEventRequest request)
    {
        return _eventsService.UpdateEvent(eventId, request, "email?");
    }

    [HttpDelete("{eventId}")]
    public async Task UpdateEvent(Guid eventId)
    {
        _eventsService.DeleteEvent(eventId, "email?");
    }
}