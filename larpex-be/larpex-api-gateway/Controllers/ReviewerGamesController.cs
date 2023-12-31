﻿using larpex_contracts.contracts.Contracts.Requests.Game;
using larpex_contracts.contracts.Contracts.Responses.Game;
using larpex_events.contracts.Contracts.Requests.Game;
using larpex_events.contracts.Contracts.Responses;
using larpex_events.Domain.Enums;
using larpex_events.Services.Interface;
using larpex_games.contracts.Contracts.Requests.Game;
using larpex_games.contracts.Contracts.Responses.Game;
using larpex_games.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace larpex_api_gateway.Controllers;

[ApiController]
[Route("[controller]")]
public class ReviewerGamesController : ControllerBase
{
    private readonly IReviewerGameService _gamesService;

    public ReviewerGamesController(IReviewerGameService gamesService)
    {
        _gamesService = gamesService;
    }

    [HttpGet("get-suggestions")]
    public async Task<BrowseGamesSuggestionResponse> GetSuggestions(
        [FromQuery] BrowseGamesSuggestionsRequest request)
    {
        return _gamesService.GetSuggestions(request);
    }

    [HttpGet("get-suggestion-details")]
    public async Task<GetGameSuggestionDetailsResponse> GetSuggestionDetails(
        [FromQuery] GetGameSuggestionDetailsRequest request)
    {
        return _gamesService.GetSuggestionDetails(request);
    }

    [HttpPost("give-verdict")]
    public async Task GiveVerdict(GiveVerdictRequest request)
    {
        _gamesService.GiveVerdict(request);
    }

    [HttpPost("add-correction")]
    public async Task AddCorrection(AddCorrectionRequest request)
    {
        _gamesService.AddCorrection(request);
    }
}