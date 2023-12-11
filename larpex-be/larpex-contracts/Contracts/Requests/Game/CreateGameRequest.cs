using larpex_events.contracts.Contracts.DataTransferObjects.Game;

namespace larpex_events.contracts.Contracts.Requests.Game;

public class CreateGameRequest
{
    public NewGameDto Game { get; set; }
}