using System;
using System.Collections.Generic;

namespace larpex_db.Models;

public partial class User
{
    public Guid Userid { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Avatar { get; set; }

    public virtual ICollection<Userscredential> Userscredentials { get; set; } = new List<Userscredential>();
}
