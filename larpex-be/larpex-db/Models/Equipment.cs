using System;
using System.Collections.Generic;

namespace larpex_db.Models;

public partial class Equipment
{
    public Guid Equipmentid { get; set; }

    public string? Itemstate { get; set; }

    public Guid? Itemid { get; set; }

    public Guid? Playerid { get; set; }

    public virtual Item? Item { get; set; }

    public virtual Player? Player { get; set; }
}
