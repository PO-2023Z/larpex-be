using larpex_contracts.contracts.Contracts.Requests.Game;
using larpex_games.Domain.Enums;
using larpex_games.Services.Interface;


namespace larpex_games.Services.Implementation;
public class CreatorGameService : ICreatorGameService
{
    private readonly IGamesRepository _gamesRepository;

    public CreatorGameService(IGamesRepository gamesRepository)
    {
        _gamesRepository = gamesRepository;
    }

    public void SendGameSuggestion(SendGameSuggestionRequest request, string email)
    {
        var game = _gamesRepository.Get(request.GameId)
            ?? throw new Exception($"Game with ID: {request.GameId} does not exist");

        if (game.OwnerEmail != email)
        {
            throw new Exception($"Person with email: {email} is not authorized to this Game");
        }

        if (game.State != CreationState.UnderDevelopment)
        {
            throw new Exception($"Game with ID: {request.GameId} is not under development");
        }


        game.State = CreationState.AwaitingAcceptation;

        _gamesRepository.Update(game);
    }
}
