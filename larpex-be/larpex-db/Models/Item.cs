﻿using System;
using System.Collections.Generic;

namespace larpex_db.Models;

public partial class Item
{
    public Guid Itemid { get; set; }

    public string Itemname { get; set; } = null!;

    public string? Itemdescription { get; set; }

    public string Rarity { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string? Itemicon { get; set; }

    public Guid? Gameid { get; set; }

    public virtual ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();

    public virtual Game? Game { get; set; }
}
