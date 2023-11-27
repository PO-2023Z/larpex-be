using System;
using System.Collections.Generic;

namespace larpex_db.Models;
public partial class Event
{
    public Guid Eventid { get; set; }

    public string? Eventname { get; set; }

    public DateTime? Startdate { get; set; }

    public decimal? Priceperuser { get; set; }

    public string? Technicaldescription { get; set; }

    public string? Descriptionforclients { get; set; }

    public string? Descriptionforemployees { get; set; }

    public string? Icon { get; set; }

    public string? Eventstate { get; set; }

    public DateTime? Enddate { get; set; }

    public bool? Paidfor { get; set; }

    public Guid? Gameid { get; set; }

    public Guid? Placeid { get; set; }

    public decimal? Eventprice { get; set; }

    public string? Owneremail { get; set; }

    public virtual Game? Game { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Place? Place { get; set; }

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();
}
