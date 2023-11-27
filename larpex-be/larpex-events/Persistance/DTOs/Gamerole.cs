using System;
using System.Collections.Generic;

namespace larpex_events.Persistance.DTOs;

public partial class Gamerole
{
    public Guid Gameroleid { get; set; }

    public string? Rolename { get; set; }

    public string? Roledescription { get; set; }

    public Guid? Gameid { get; set; }

    public virtual Game? Game { get; set; }

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();
}
