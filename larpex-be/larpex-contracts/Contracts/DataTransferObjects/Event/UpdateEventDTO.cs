namespace larpex_events.contracts.Contracts.DataTransferObjects.Event;

public class UpdateEventDTO
{
    public string? Name { get; set; }
    public string? EmployeeDescription { get; set; }
    public string? ClientDescription { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? CurrentlySignedPlayers { get; set; }
    public decimal? PricePerUser { get; set; }
    public string? EventStatus { get; set; }
}
