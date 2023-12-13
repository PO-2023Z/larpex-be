namespace larpex_events.contracts.Contracts.DataTransferObjects;

public class UpdateGameDto
{
    // UpdateGameDto doesn't have a status property, because it will be changed separately
    public string GameId { get; set; }
    public string GameName { get; set; }
    public int MaximumPlayers { get; set; }
    public int Difficulty { get; set; }
    
    public string Description { get; set; }
    public string MapUrl { get; set; }
    public string Scenario { get; set; }
}