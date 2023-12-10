using larpex_contracts.contracts.Contracts.Requests.Game;

namespace larpex_games.Services.Interface;
public interface ICreatorGameService
{
    void SendGameSuggestion(SendGameSuggestionRequest request, string email);
}
