using larpex_contracts.contracts.Contracts.DataTransferObjects.Game;
using larpex_contracts.contracts.Contracts.Responses.Game;
using larpex_games.contracts.Contracts.Responses.Game;
using larpex_games.Domain;

namespace larpex_games.Services.Mapper;
public static class MapperExtensionMethods
{
    public static GameSuggestionDTO MapToGameSuggestionDTO(this Game game)
    {
        return new GameSuggestionDTO
        {
            Id = game.GameId,
            GameName = game.GameName,
            DateOfCreation = game.DateOfCreation
        };
    }

    public static GetGameSuggestionDetailsResponse MapToGetGameSuggestionDetailsResponse(this Game game)
    {
        return new GetGameSuggestionDetailsResponse
        {
            Id = game.GameId,
            GameName = game.GameName,
            GameDescription = game.Description,
            Difficulty = game.Difficulty,
            MaximumNumberOfPlayers = game.MaximumPlayers,
            GameScenario = game.Scenario,
            MapURL = game.Map
        };
    }

    //public static BrowseGamesSuggestionResponse MapToBrowseGamesSuggestionResponse(this List<Game> games, int itemsFrom, int itemsTo, int totalPages)
    public static BrowseGamesSuggestionResponse MapToBrowseGamesSuggestionResponse(this List<Game> games, int totalPages, int totalItemsCount, int itemsFrom, int itemsTo)
    {
        return new BrowseGamesSuggestionResponse
        {
            Items = games.Select(x => x.MapToGameSuggestionDTO()).ToList(),
            TotalItemsCount = totalItemsCount,
            ItemFrom = itemsFrom,
            ItemTo = itemsTo,
            TotalPages = totalPages
        };
    }
}
