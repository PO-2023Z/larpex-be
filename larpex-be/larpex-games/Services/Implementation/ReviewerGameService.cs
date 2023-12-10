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

        if (!string.IsNullOrEmpty(request.GameName))
        {
            games = games.Where(x => x.GameName.Contains(request.GameName));
        }

        if (request.SortExpression is not null)
        {
            switch (request.SortExpression)
            {
                case larpex_contracts.contracts.Contracts.DataTransferObjects.Game.Enums.SortExpression.GameName:
                    games = games.OrderBy(x => x.GameName);
                    break;

                case larpex_contracts.contracts.Contracts.DataTransferObjects.Game.Enums.SortExpression.CreationDate:
                    games = games.OrderBy(x => x.DateOfCreation);
                    break;
            }
        }

        var totalPages = games.Count() / request.PageSize + ((games.Count() % request.PageSize) > 0 ? 1 : 0);
        games = games.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize);
        // upewnic sie czy to smiga jak nalezy

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
