﻿using System;
using System.Collections.Generic;

namespace larpex_events.larpex-events.Persistance.Models;

public partial class Equipment
{
    public string Equipmentid { get; set; } = null!;

    public string? Itemstate { get; set; }

    public string? Itemid { get; set; }

    public string? Playerid { get; set; }

    public virtual Item? Item { get; set; }

    public virtual Player? Player { get; set; }
}