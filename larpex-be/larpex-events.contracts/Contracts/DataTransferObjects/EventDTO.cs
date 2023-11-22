namespace larpex_events.contracts.Contracts.DataTransferObjects;

public class EventDTO
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string LocationName { get; set; }
    public DateTime Date { get; set; }
    //public EventStatus Status { get; set; }
    public int CurrentlySignedPlayers { get; set; }
    public int MaxPlayers { get; set; }
}
