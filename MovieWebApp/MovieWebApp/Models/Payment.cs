using System;
using System.Collections.Generic;

namespace MovieWebApp.Models;

public partial class Payment
{
    public decimal? Amount { get; set; }

    public DateTime? PaymentDate { get; set; }

    public int? PaymentType { get; set; }

    public int CustomerSubscriptionId { get; set; }

    public string? BillingAddress { get; set; }

    public int Id { get; set; }

    public virtual CustomerSubscription CustomerSubscription { get; set; } = null!;

    public virtual PaymentType? PaymentTypeNavigation { get; set; }
}
