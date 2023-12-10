using System;
using System.Collections.Generic;

namespace larpex_db.Models;

public partial class Payment
{
    public Guid Paymentid { get; set; }

    public string Paymenttype { get; set; } = null!;

    public DateTime? Paymentdate { get; set; }

    public string Paymentstate { get; set; } = null!;

    public decimal? Paymentamount { get; set; }

    public Guid? Eventid { get; set; }

    public string? Useremail { get; set; }

    public virtual Event? Event { get; set; }
}
