namespace larpex_events.Persistance.DTOs;

public partial class Item
{
    public string Itemid { get; set; } = null!;

    public string? Itemname { get; set; }

    public string? Itemdescription { get; set; }

    public string? Rarity { get; set; }

    public string? Type { get; set; }

    public string? Itemicon { get; set; }

    public string? Gameid { get; set; }

    public virtual ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();

    public virtual Game? Game { get; set; }
}
