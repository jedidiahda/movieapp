using System;
using System.Collections.Generic;

namespace MovieWebApp.Models;

public partial class Subscription
{
    public int Id { get; set; }

    public int AtHomeDvd { get; set; }

    public int NoDvdperMonth { get; set; }

    public decimal Price { get; set; }

    public string Name { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public virtual ICollection<CustomerSubscription> CustomerSubscriptions { get; set; } = new List<CustomerSubscription>();
}
