using larpex_contracts.contracts.Contracts.Requests.Game;
using larpex_contracts.contracts.Contracts.Responses.Game;
using larpex_events.contracts.Contracts.Requests.Game;
using larpex_games.contracts.Contracts.Requests.Game;
using larpex_games.contracts.Contracts.Responses.Game;
using larpex_games.Services.Interface;
using larpex_games.Services.Mapper;

namespace larpex_games.Services.Implementation;
public class ReviewerGameService : IReviewerGameService
{
    private readonly IGamesRepository _gamesRepository;

    public ReviewerGameService(IGamesRepository gamesRepository)
    {
        _gamesRepository = gamesRepository;
    }

    public void AddCorrection(AddCorrectionRequest request)
    {
        var game = _gamesRepository.Get(request.GameId)
            ?? throw new Exception($"Game with ID: {request.GameId} does not exist");

        game.GameId = request.GameId;
        game.CorrectionNotes = request.Message ?? string.Empty;

        _gamesRepository.Update(game);
    }

    public GetGameSuggestionDetailsResponse GetSuggestionDetails(GetGameSuggestionDetailsRequest request)
    {
        var game = _gamesRepository.Get(request.GameId)
            ?? throw new Exception($"Game with ID: {request.GameId} does not exist");

        return game.MapToGetGameSuggestionDetailsResponse();
    }

    public BrowseGamesSuggestionResponse GetSuggestions(BrowseGamesSuggestionsRequest request)
    {
        var games = _gamesRepository.GetAll()
            .Where(x => x.State == Domain.Enums.CreationState.AwaitingAcceptation);

        if (request.GameName is not null)
        {
            games = games.Where(x => x.GameName.Contains(request.GameName));
        }

        if (request.SortExpression is not null)
        {
            //games = games.
        }

        var totalPages = 1;

        if (request.PageNumber is not null && request.PageSize is not null)
        {
            totalPages = games.Count() / (int)request.PageSize + ((games.Count() % (int)request.PageSize) > 0 ? 1 : 0);
            games = games.Skip(((int)request.PageNumber - 1) * (int)request.PageSize).Take((int)request.PageSize);
            // upewnic sie czy to smiga jak nalezy
        }

        return games.ToList().MapToBrowseGamesSuggestionResponse(totalPages);
    }

    public void GiveVerdict(GiveVerdictRequest request)
    {
        var game = _gamesRepository.Get(request.GameId)
            ?? throw new Exception($"Game with ID: {request.GameId} does not exist");


        game.State = request.Verdict == larpex_contracts.contracts.Contracts.DataTransferObjects.Game.Enums.Verdict.Accepted
            ? Domain.Enums.CreationState.Accepted 
            : Domain.Enums.CreationState.Rejected;

        game.VerdictNotes = request.Explanation ?? string.Empty;

        _gamesRepository.Update(game);
    }
}
