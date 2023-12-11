using System;
using System.Collections.Generic;

namespace larpex_db.Models;

public partial class Game
{
    public Guid Gameid { get; set; }

    public string Gamename { get; set; } = null!;

    public int Maximumplayer { get; set; }

    public int Difficulty { get; set; }

    public string? Description { get; set; }

    public string? Map { get; set; }

    public string? Scenario { get; set; }

    public string Creationstate { get; set; } = null!;

    public string Gameauthoremail { get; set; } = null!;

    public string? Amendment { get; set; }

    public DateTime? Dateofcreation { get; set; }

    public string? Correctionnotes { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<Gamerole> Gameroles { get; set; } = new List<Gamerole>();

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
