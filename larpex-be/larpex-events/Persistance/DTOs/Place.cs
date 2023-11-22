namespace larpex_events.Persistance.DTOs;

public partial class Place
{
    public string Placeid { get; set; } = null!;

    public string? Address { get; set; }

    public string? Details { get; set; }

    public decimal? Priceperhour { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
