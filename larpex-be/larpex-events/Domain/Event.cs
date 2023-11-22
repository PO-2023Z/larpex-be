using larpex_events.Domain.Enums;

namespace larpex_events.Domain;

public class Event
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string LocationName { get; set; }
    public DateTime Date { get; set; }
    public int CurrentlySignedPlayers { get; set; }
    public int MaxPlayers { get; set; }
    public string OwnerEmail { get; set; }
    public EventStatus Status { get; set; }
    public EventSettings? Settings { get; set; }
}
