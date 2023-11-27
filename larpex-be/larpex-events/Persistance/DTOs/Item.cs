using System;
using System.Collections.Generic;

namespace larpex_events.Persistance.DTOs;

public partial class Item
{
    public Guid Itemid { get; set; }

    public string? Itemname { get; set; }

    public string? Itemdescription { get; set; }

    public string? Rarity { get; set; }

    public string? Type { get; set; }

    public string? Itemicon { get; set; }

    public Guid? Gameid { get; set; }

    public virtual ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();

    public virtual Game? Game { get; set; }
}
