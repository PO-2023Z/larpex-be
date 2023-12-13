using larpex_contracts.contracts.Contracts.Requests.Game;
using larpex_events.contracts.Contracts.DataTransferObjects;
using larpex_events.contracts.Contracts.DataTransferObjects.Game;
using larpex_events.contracts.Contracts.Requests.Game;
using larpex_events.contracts.Contracts.Responses.Game;

namespace larpex_games.Services.Interface;
public interface ICreatorGameService
{
    GetCreatorGamesResponse GetGames(string creatorEmail);
    GetCreatorGameResponse? GetGame(Guid gameId, string creatorEmail);
    void CreateGame(CreateGameRequest request, string creatorEmail);
    void ModifyGame(UpdateGameDto game, string creatorEmail);
    
    void SendGameSuggestion(SendGameSuggestionRequest request, string email);
}
