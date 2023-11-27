using System;
using System.Collections.Generic;

namespace larpex_db.Models;

public partial class Userscredential
{
    public Guid Usercredentialid { get; set; }

    public string? Password { get; set; }

    public Guid? Userid { get; set; }

    public virtual User? User { get; set; }
}
