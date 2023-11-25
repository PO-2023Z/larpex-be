using System;
using System.Collections.Generic;

namespace larpex_events.larpex-events.Persistance.Models;

public partial class Gamerole
{
    public string Gameroleid { get; set; } = null!;

    public string? Rolename { get; set; }

    public string? Roledescription { get; set; }

    public string? Gameid { get; set; }

    public virtual Game? Game { get; set; }

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();
}
