using larpex_events.contracts.Contracts.DataTransferObjects;

namespace larpex_events.contracts.Contracts.Requests.Game;

public class ModifyGameRequest
{
    public UpdateGameDto game { get; set; }
}