using NpgsqlTypes;

namespace larpex_events.Persistance.DTOs;

public partial class Player
{
    public string Playerid { get; set; } = null!;

    public string? Gameroleid { get; set; }

    public string? Userid { get; set; }

    public string? Eventid { get; set; }

    public string? Nick { get; set; }

    public NpgsqlPoint? Coordinates { get; set; }

    public virtual ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();

    public virtual Event? Event { get; set; }

    public virtual Gamerole? Gamerole { get; set; }

    public virtual User? User { get; set; }
}
