namespace larpex_events.Persistance.DTOs;

public partial class Userscredential
{
    public string Usercredentialid { get; set; } = null!;

    public string? Password { get; set; }

    public string? Userid { get; set; }

    public virtual User? User { get; set; }
}
