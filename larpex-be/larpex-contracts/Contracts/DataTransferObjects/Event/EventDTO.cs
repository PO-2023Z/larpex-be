namespace larpex_events.contracts.Contracts.DataTransferObjects.Event;

public class EventDTO
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string DescriptionForClient { get; set; }
    public string DescriptionForEmployee { get; set; }
    public string OwnerEmail { get; set; }
    public decimal PricePerUser { get; set; }
    public decimal EventPrice { get; set; }
    public Guid Location { get; set; }
    public Guid Game { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int? CurrentlySignedPlayers { get; set; }
    public string EventStatus { get; set; }
    public EventSettingsDTO EventSettings { get; set; }
}
