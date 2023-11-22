namespace larpex_events.Persistance.DTOs;

public partial class Event
{
    public string Eventid { get; set; } = null!;

    public string? Eventname { get; set; }

    public TimeOnly? Startdate { get; set; }

    public decimal? Priceperuser { get; set; }

    public string? Description { get; set; }

    public string? Icon { get; set; }

    public string? Eventstate { get; set; }

    public TimeOnly? Enddate { get; set; }

    public bool? Paidfor { get; set; }

    public string? Gameid { get; set; }

    public string? Placeid { get; set; }

    public virtual Game? Game { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Place? Place { get; set; }

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();
}
