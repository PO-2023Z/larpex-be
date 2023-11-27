using System;
using System.Collections.Generic;

namespace larpex_db.Models;

public partial class Userscredential
{
    public Guid Usercredentialid { get; set; }

    public string? Password { get; set; }

    public string? UserEmail { get; set; }

    public virtual User? UserEmailNavigation { get; set; }
}
