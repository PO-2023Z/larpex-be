namespace larpex_events.contracts.Contracts.DataTransferObjects.Game;

public class NewGameDto
{
    // NewGameDto doesn't have a status or GameId property
    public string GameName { get; set; }
    public int MaximumPlayers { get; set; }
    public int Difficulty { get; set; }
    
    public string Description { get; set; }
    public string MapUrl { get; set; }
    public string Scenario { get; set; }
}