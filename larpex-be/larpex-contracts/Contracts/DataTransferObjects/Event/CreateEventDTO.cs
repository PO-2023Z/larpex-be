namespace larpex_events.contracts.Contracts.DataTransferObjects.Event;

public class CreateEventDTO
{
    public string Name { get; set; }
    public string? EmployeeDescription { get; set; }
    public string? ClientDescription { get; set; }
    public decimal PricePerUser { get; set; }
    public int? CurrentlySignedPlayers { get; set; }
    public Guid Location { get; set; }
    public Guid Game { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
