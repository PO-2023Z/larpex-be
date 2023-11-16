namespace larpex_events.contracts.Contracts.DataTransferObjects;

public class UpdateEventDTO
{
    public string? Name { get; set; }
    public string? EmployeeDescription { get; set; }
    public string? ClientDescription { get; set; }
    public DateTime? EventDate { get; set; }
}
