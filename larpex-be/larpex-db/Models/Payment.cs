using System;
using System.Collections.Generic;
using larpex_db.Models;

namespace larpex_db.Models;

public partial class Payment
{
    public Guid Paymentid { get; set; }

    public string? Paymenttype { get; set; }

    public DateTime? Paymentdate { get; set; }

    public string? Paymentstate { get; set; }

    public decimal? Paymentamount { get; set; }

    public string? UserEmail { get; set; }

    public Guid? Eventid { get; set; }

    public virtual Event? Event { get; set; }

    public virtual User? UserEmailNavigation { get; set; }
}
