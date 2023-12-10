using larpex_contracts.contracts.Contracts.DataTransferObjects.Game.Enums;

namespace larpex_events.contracts.Contracts.Requests.Game;
public class GiveVerdictRequest
{
    public Guid GameId { get; set; }
    public Verdict Verdict { get; set; }
    public string? Explanation { get; set; }
}
