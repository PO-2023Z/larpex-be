using larpex_contracts.contracts.Contracts.DataTransferObjects.Game.Enums;
using larpex_contracts.contracts.Contracts.Requests.Game;
using larpex_contracts.contracts.Contracts.Responses.Game;
using larpex_events.contracts.Contracts.Requests.Game;
using larpex_games.contracts.Contracts.Requests.Game;
using larpex_games.contracts.Contracts.Responses.Game;
using larpex_games.Domain.Enums;
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

        if (game.State != CreationState.AwaitingAcceptation)
            throw new Exception($"Game with ID: {request.GameId} is not awaiting acceptation");
        
        game.CorrectionNotes = request.Message ?? string.Empty;
        game.State = CreationState.UnderDevelopment;

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
            .Where(x => x.State == CreationState.AwaitingAcceptation);

        if (!string.IsNullOrEmpty(request.GameName))
        {
            games = games.Where(x => x.GameName.Contains(request.GameName));
        }
        
        var totalItems = games.Count();

        if (request.SortExpression is not null)
        {
            switch (request.SortExpression)
            {
                case SortExpression.GameName:
                    games = games.OrderBy(x => x.GameName);
                    break;

                case SortExpression.CreationDate:
                    games = games.OrderBy(x => x.DateOfCreation);
                    break;
            }
        }
        var pageSize = request.PageSize;
        if (pageSize < 1)
        {
            pageSize = 5;
        }
        
        var pageNumber = request.PageNumber;
        if(pageNumber < 1)
        {
            pageNumber = 1;
        }
        
        var itemFrom = (pageNumber - 1) * pageSize + 1;

        var totalPages = games.Count() / pageSize  + ((games.Count() % pageSize) > 0 ? 1 : 0);
        games = games.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        var itemTo = itemFrom + games.Count() -1;

        return games.ToList().MapToBrowseGamesSuggestionResponse(totalPages, totalItems, itemFrom, itemTo);
    }

    public void GiveVerdict(GiveVerdictRequest request)
    {
        var game = _gamesRepository.Get(request.GameId)
            ?? throw new Exception($"Game with ID: {request.GameId} does not exist");

        if (game.State != CreationState.AwaitingAcceptation)
            throw new Exception($"Game with ID: {request.GameId} is not awaiting acceptation");
        
        game.State = request.Verdict == Verdict.Accepted
            ? CreationState.Accepted 
            : CreationState.Rejected;

        game.VerdictNotes = request.Explanation ?? string.Empty;

        _gamesRepository.Update(game);
    }
}
