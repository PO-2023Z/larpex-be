using larpex_games.Domain.Enums;

namespace larpex_games.Domain;
public class Game
{
    public Guid GameId { get; set; }
    public string GameName { get; set; }
    public string OwnerEmail { get; set; }
    public int MaximumPlayers { get; set; }
    public int Difficulty { get; set; }
    public string Description { get; set; }
    public string Map { get; set; }
    public string Scenario { get; set; }
    public string CorrectionNotes { get; set; }
    public string VerdictNotes { get; set; }
    public CreationState State { get; set; }
    public DateTime DateOfCreation { get; set; }
}
