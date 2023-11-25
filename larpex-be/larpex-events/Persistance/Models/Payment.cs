using System;
using System.Collections.Generic;

namespace larpex_events.larpex-events.Persistance.Models;

public partial class Payment
{
    public string Paymentid { get; set; } = null!;

    public string? Paymenttype { get; set; }

    public DateTime? Paymentdate { get; set; }

    public string? Paymentstate { get; set; }

    public decimal? Paymentamount { get; set; }

    public string? Userid { get; set; }

    public string? Eventid { get; set; }

    public virtual Event? Event { get; set; }

    public virtual User? User { get; set; }
}
