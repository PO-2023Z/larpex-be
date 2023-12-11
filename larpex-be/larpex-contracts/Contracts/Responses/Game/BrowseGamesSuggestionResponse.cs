using larpex_contracts.contracts.Contracts.DataTransferObjects.Game;

namespace larpex_games.contracts.Contracts.Responses.Game;
public class BrowseGamesSuggestionResponse
{
    public List<GameSuggestionDTO> Items { get; set; }
    public int TotalItemsCount { get; set; }
    public int ItemFrom { get; set; }
    public int ItemTo { get; set; }
    public int TotalPages { get; set; }
}
