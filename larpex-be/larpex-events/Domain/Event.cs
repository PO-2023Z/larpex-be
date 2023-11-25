using larpex_events.Domain.Enums;

namespace larpex_events.Domain;

public class Event
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string OwnerEmail { get; set; }
    public EventStatus Status { get; set; }
    public DateTime? EventDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? CurrentlySignedPlayers { get; set; }
    public decimal PricePerUser { get; set; }
    public decimal Price { get; set; }
    public bool Paid { get; set; }
    public Game Game { get; set; }
    public Location Location { get; set; }
    public EventDescriptionForEmployee DescriptionForEmployees { get; set; }
    public EventDescriptionForClient DescriptionForClients { get; set; }
    public EventSettings Settings { get; set; }
}
