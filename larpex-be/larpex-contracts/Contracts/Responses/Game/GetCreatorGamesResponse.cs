using larpex_events.contracts.Contracts.DataTransferObjects.Game;

namespace larpex_events.contracts.Contracts.Responses.Game;

public class GetCreatorGamesResponse
{
    public List<GameSummaryDto> Games { get; set; }
}