using System;
using System.Collections.Generic;
using larpex_db.Models;
using NpgsqlTypes;

namespace larpex_db.Models;

public partial class Player
{
    public Guid Playerid { get; set; }

    public Guid? Gameroleid { get; set; }

    public Guid? Userid { get; set; }

    public Guid? Eventid { get; set; }

    public string? Nick { get; set; }

    public NpgsqlPoint? Coordinates { get; set; }

    public virtual ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();

    public virtual Event? Event { get; set; }

    public virtual Gamerole? Gamerole { get; set; }

    public virtual User? User { get; set; }
}
