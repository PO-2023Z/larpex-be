using System;
using System.Collections.Generic;

namespace larpex_events.Persistance.DTOs;

public partial class Payment
{
    public Guid Paymentid { get; set; }

    public string? Paymenttype { get; set; }

    public DateTime? Paymentdate { get; set; }

    public string? Paymentstate { get; set; }

    public decimal? Paymentamount { get; set; }

    public Guid? Userid { get; set; }

    public Guid? Eventid { get; set; }

    public virtual Event? Event { get; set; }

    public virtual User? User { get; set; }
}
