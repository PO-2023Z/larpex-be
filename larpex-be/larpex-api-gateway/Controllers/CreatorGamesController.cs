using larpex_auth;
using larpex_contracts.contracts.Contracts.Requests.Game;
using larpex_events.contracts.Contracts.Responses;
using larpex_events.Domain.Enums;
using larpex_events.Services.Interface;
using larpex_games.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace larpex_api_gateway.Controllers;

[ApiController]
[Route("[controller]")]
public class CreatorGamesController : ControllerBase
{
    private readonly ICreatorGameService _gamesService;

    public CreatorGamesController(ICreatorGameService gamesService)
    {
        _gamesService = gamesService;
    }

    [HttpPost()]
    public async Task SendGameSuggestion(SendGameSuggestionRequest request)
    {
        string token = HttpContext.Request.Headers["Authorization"];
        if (string.IsNullOrWhiteSpace(token) || !token.StartsWith("Bearer "))
        {
            throw new UnauthorizedAccessException("Invalid token");
        }
        var email = TokenGenerator.GetEmail(token.Substring("Bearer ".Length));

        _gamesService.SendGameSuggestion(request, email);
    }
}