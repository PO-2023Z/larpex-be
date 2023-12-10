using larpex_contracts.contracts.Contracts.DataTransferObjects.Game.Enums;

namespace larpex_games.contracts.Contracts.Requests.Game;
public class BrowseGamesSuggestionsRequest
{
    public string? GameName { get; set; }
    public SortExpression? SortExpression { get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}
