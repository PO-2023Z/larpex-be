using System;
using System.Collections.Generic;

namespace larpex_db.Models;

public partial class Userscredential
{
    public Guid Usercredentialid { get; set; }

    public string? Password { get; set; }

    public string? Useremail { get; set; }

    public virtual User? UseremailNavigation { get; set; }
}
