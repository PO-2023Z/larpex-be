using larpex_auth;
using larpex_events.contracts.Contracts.Requests;
using larpex_events.contracts.Contracts.Responses;
using larpex_events.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace larpex_api_gateway.Controllers;

//TODO: Authorize
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
    public async Task<ActionResult<GetEventsResponse>> GetEvents()
    {
        string token = HttpContext.Request.Headers["Authorization"];
        if (string.IsNullOrWhiteSpace(token) || !token.StartsWith("Bearer "))
        {
            return Unauthorized("Invalid token");
        }
        var email = TokenGenerator.GetEmail(token.Substring("Bearer ".Length));

        return _eventsService.GetEvents(email);
    }

    [HttpPost()]
    public async Task<ActionResult<CreateEventResponse>> CreateEvent(CreateEventRequest request)
    {
        string token = HttpContext.Request.Headers["Authorization"];
        if (string.IsNullOrWhiteSpace(token) || !token.StartsWith("Bearer "))
        {
            return Unauthorized("Invalid token");
        }
        var email = TokenGenerator.GetEmail(token.Substring("Bearer ".Length));

        return _eventsService.CreateEvent(request, email);
    }

    [HttpGet("{eventId}")]
    public async Task<ActionResult<ReadEventResponse>> ReadEvent(Guid eventId)
    {
        string token = HttpContext.Request.Headers["Authorization"];
        if (string.IsNullOrWhiteSpace(token) || !token.StartsWith("Bearer "))
        {
            return Unauthorized("Invalid token");
        }
        var email = TokenGenerator.GetEmail(token.Substring("Bearer ".Length));

        return _eventsService.ReadEvent(eventId, email);
    }

    [HttpPut("settings/{eventId}")]
    public async Task<ActionResult<UpdateEventSettingsResponse>> UpdateEventSettings(Guid eventId, UpdateEventSettingsRequest request)
    {
        string token = HttpContext.Request.Headers["Authorization"];
        if (string.IsNullOrWhiteSpace(token) || !token.StartsWith("Bearer "))
        {
            return Unauthorized("Invalid token");
        }
        var email = TokenGenerator.GetEmail(token.Substring("Bearer ".Length));

        return _eventsService.UpdateEventSettings(eventId, request, email);
    }

    [HttpPut("{eventId}")]
    public async Task<ActionResult<UpdateEventResponse>> UpdateEvent(Guid eventId, UpdateEventRequest request)
    {
        string token = HttpContext.Request.Headers["Authorization"];
        if (string.IsNullOrWhiteSpace(token) || !token.StartsWith("Bearer "))
        {
            return Unauthorized("Invalid token");
        }
        var email = TokenGenerator.GetEmail(token.Substring("Bearer ".Length));

        return _eventsService.UpdateEvent(eventId, request, email);
    }

    [HttpDelete("{eventId}")]
    public async Task UpdateEvent(Guid eventId)
    {
        string token = HttpContext.Request.Headers["Authorization"];
        if (string.IsNullOrWhiteSpace(token) || !token.StartsWith("Bearer "))
        {
            throw new  UnauthorizedAccessException("Invalid token");
        }
        var email = TokenGenerator.GetEmail(token.Substring("Bearer ".Length));

        _eventsService.DeleteEvent(eventId, email);
    }
}