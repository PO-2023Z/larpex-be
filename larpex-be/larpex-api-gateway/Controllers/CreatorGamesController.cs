using larpex_auth;
using larpex_contracts.contracts.Contracts.Requests.Game;
using larpex_events.contracts.Contracts.Requests.Game;
using larpex_events.contracts.Contracts.Responses;
using larpex_events.contracts.Contracts.Responses.Game;
using larpex_events.Domain.Enums;
using larpex_events.Services.Interface;
using larpex_games.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace larpex_api_gateway.Controllers;

[ApiController]
[Route("[controller]")]
public classCreatorGamesController : ControllerBase
{
    private readonly ICreatorGameService _gamesService;

    public CreatorGamesController(ICreatorGameService gamesService)
    {
        _gamesService = gamesService;
    }
    
    
    [HttpGet()]
    public async Task<GetCreatorGamesResponse> GetGames()
    {
        string token = HttpContext.Request.Headers["Authorization"];
        if (string.IsNullOrWhiteSpace(token) || !token.StartsWith("Bearer "))
        {
            throw new UnauthorizedAccessException("Invalid token");
        }
        var email = TokenGenerator.GetEmail(token.Substring("Bearer ".Length));

        
        return _gamesService.GetGames(email);
    }
    
    [HttpGet("{gameId}")]
    public async Task<GetCreatorGameResponse> GetGame(Guid gameId)
    {
        string token = HttpContext.Request.Headers["Authorization"];
        if (string.IsNullOrWhiteSpace(token) || !token.StartsWith("Bearer "))
        {
            throw new UnauthorizedAccessException("Invalid token");
        }
        var email = TokenGenerator.GetEmail(token.Substring("Bearer ".Length));

        
        return _gamesService.GetGame(gameId, email);
    }
    
    [HttpPost("create/")]
    public async Task CreateGame(CreateGameRequest request)
    {
        string token = HttpContext.Request.Headers["Authorization"];
        if (string.IsNullOrWhiteSpace(token) || !token.StartsWith("Bearer "))
        {
            throw new UnauthorizedAccessException("Invalid token");
        }
        var email = TokenGenerator.GetEmail(token.Substring("Bearer ".Length));

        _gamesService.CreateGame(request, email);
    }
    
    [HttpPost("modify/")]
    public async Task ModifyGame(ModifyGameRequest request)
    {
        string token = HttpContext.Request.Headers["Authorization"];
        if (string.IsNullOrWhiteSpace(token) || !token.StartsWith("Bearer "))
        {
            throw new UnauthorizedAccessException("Invalid token");
        }
        var email = TokenGenerator.GetEmail(token.Substring("Bearer ".Length));

        _gamesService.ModifyGame(request.game, email);
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