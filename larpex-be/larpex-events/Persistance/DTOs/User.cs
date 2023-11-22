﻿namespace larpex_events.Persistance.DTOs;

public partial class User
{
    public string Userid { get; set; } = null!;

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Avatar { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();

    public virtual ICollection<Userscredential> Userscredentials { get; set; } = new List<Userscredential>();
}