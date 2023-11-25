using System;
using System.Collections.Generic;

namespace larpex_events.larpex-events.Persistance.Models;

public partial class Userscredential
{
    public string Usercredentialid { get; set; } = null!;

    public string? Password { get; set; }

    public string? Userid { get; set; }

    public virtual User? User { get; set; }
}
