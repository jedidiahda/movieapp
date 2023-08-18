using System;
using System.Collections.Generic;

namespace MovieWebApp.Models;

public partial class CustomerSubscription
{
    public int CustomerId { get; set; }

    public int SubscriptId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int Id { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<Dvdstatus> Dvdstatuses { get; set; } = new List<Dvdstatus>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Subscription Subscript { get; set; } = null!;
}
