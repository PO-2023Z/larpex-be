using System;
using System.Collections.Generic;

namespace larpex_db.Models;

public partial class Place
{
    public Guid Placeid { get; set; }

    public string? Address { get; set; }

    public string? Details { get; set; }

    public decimal? Priceperhour { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
