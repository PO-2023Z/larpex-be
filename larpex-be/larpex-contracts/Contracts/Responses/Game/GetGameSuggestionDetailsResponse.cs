namespace larpex_contracts.contracts.Contracts.Responses.Game;
public class GetGameSuggestionDetailsResponse
{
    public Guid Id { get; set; }
    public string GameName { get; set; }
    public string GameDescription { get; set; }
    public int Difficulty { get; set; }
    public int MaximumNumberOfPlayers { get; set; }
    public string GameScenario { get; set; }
    public string MapURL { get; set; }
}
