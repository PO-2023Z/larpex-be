using larpex_contracts.contracts.Contracts.Requests.Game;
using larpex_events.contracts.Contracts.DataTransferObjects.Game;
using larpex_events.contracts.Contracts.Requests.Game;
using larpex_events.contracts.Contracts.Responses.Game;
using larpex_games.Services.Interface;


namespace larpex_games.Services.Implementation;
public class CreatorGameService : ICreatorGameService
{
    private readonly IGamesRepository _gamesRepository;

    public CreatorGameService(IGamesRepository gamesRepository)
    {
        _gamesRepository = gamesRepository;
    }

    public List<GameDto> GetGames(string creatorEmail)
    {
        throw new NotImplementedException();
    }

    public GetCreatorGameResponse GetGame(Guid gameId, string creatorEmail)
    {
        throw new NotImplementedException();
    }

    public void CreateGame(CreateGameRequest request, string creatorEmail)
    {
        throw new NotImplementedException();
    }

    public void ModifyGame(GameDto game, string creatorEmail)
    {
        throw new NotImplementedException();
    }

    public void SendGameSuggestion(SendGameSuggestionRequest request, string email)
    {
        var game = _gamesRepository.Get(request.GameId)
            ?? throw new Exception($"Game with ID: {request.GameId} does not exist");

        if (game.OwnerEmail != email)
        {
            throw new Exception($"Person with email: {email} is not authorized to this Game");
        }

        game.State = Domain.Enums.CreationState.AwaitingAcceptation;

        _gamesRepository.Update(game);
    }
}
