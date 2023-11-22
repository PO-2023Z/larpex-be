namespace larpex_events.contracts.Contracts.DataTransferObjects;

public class EventDTO
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string DescriptionForClient { get; set; }
    public string DescriptionForEmployee { get; set; }
    public decimal Price { get; set; }
    public Guid Location { get; set; }
    public DateTime? Date { get; set; }
    //public EventStatus Status { get; set; }
    public int? CurrentlySignedPlayers { get; set; }
    public int? MaxPlayers { get; set; }
}
