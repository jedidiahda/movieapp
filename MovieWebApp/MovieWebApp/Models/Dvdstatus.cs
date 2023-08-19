using System;
using System.Collections.Generic;

namespace MovieWebApp.Models;

public partial class Dvdstatus
{
    public int Id { get; set; }

    public DateTime? DeliveredDate { get; set; }

    public DateTime? ReturnedDate { get; set; }

    public int? CustomerSubscriptionId { get; set; }

    public string? Dvdcode { get; set; }

    public int? DvdcatalogId { get; set; }

    public virtual CustomerSubscription? CustomerSubscription { get; set; }
}
