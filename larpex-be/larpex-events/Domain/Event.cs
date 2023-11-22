using larpex_events.Domain.Enums;

namespace larpex_events.Domain;

public class Event
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string OwnerEmail { get; set; }
    public EventStatus Status { get; set; }
    public decimal Price { get; set; }
    public bool Paid { get; set; }
}
