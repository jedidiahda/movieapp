using System;
using System.Collections.Generic;

namespace MovieWebApp.Models;

public partial class PaymentType
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
