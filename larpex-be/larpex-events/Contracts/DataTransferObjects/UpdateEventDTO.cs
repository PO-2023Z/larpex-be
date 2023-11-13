namespace larpex_events.Contracts.DataTransferObjects;

public class CreateEventDTO
{
    public string Name { get; set; }
    public string EmployeeDescription { get; set; }
    public string ClientDescription { get; set; }
    public Guid Location { get; set; }
    public Guid Game {  get; set; }
    public DateTime EventDate { get; set; }
}
