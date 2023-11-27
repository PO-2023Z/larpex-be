using System;
using System.Collections.Generic;

namespace larpex_db.Models;

public partial class Game
{
    public Guid Gameid { get; set; }

    public string? Gamename { get; set; }

    public int? Maximumplayer { get; set; }

    public int? Difficulty { get; set; }

    public string? Description { get; set; }

    public string? Map { get; set; }

    public string? Scenario { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<Gamerole> Gameroles { get; set; } = new List<Gamerole>();

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
