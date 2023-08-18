using System;
using System.Collections.Generic;

namespace MovieWebApp.Models;

public partial class CustomerDeliveryDto
{
    public int? CustomerId { get; set; }

    public int? CustomerSubscriptionId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Gender { get; set; }

    public int? DvdcatalogId { get; set; }

    public string? Title { get; set; }

    public string? Status { get; set; }

    public int? Rank { get; set; }

    public string? Code { get; set; }
}
