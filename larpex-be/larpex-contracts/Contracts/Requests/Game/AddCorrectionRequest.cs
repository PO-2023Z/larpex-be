namespace larpex_contracts.contracts.Contracts.Requests.Game;
public class AddCorrectionRequest
{
    public Guid GameId { get; set; }
    public string? Message { get; set; }
}
