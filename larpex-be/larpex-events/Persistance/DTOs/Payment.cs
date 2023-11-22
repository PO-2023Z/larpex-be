namespace larpex_events.Persistance.DTOs;

public partial class Payment
{
    public string Paymentid { get; set; } = null!;

    public string? Paymenttype { get; set; }

    public TimeOnly? Paymentdate { get; set; }

    public string? Paymentstate { get; set; }

    public decimal? Paymentamount { get; set; }

    public string? Userid { get; set; }

    public string? Eventid { get; set; }

    public virtual Event? Event { get; set; }

    public virtual User? User { get; set; }
}
