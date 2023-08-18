using System;
using System.Collections.Generic;

namespace MovieWebApp.Models;

public partial class RequestedDvd
{
    public string? Title { get; set; }

    public DateTime SubmissionDate { get; set; }

    public int Id { get; set; }

    public int CustomerId { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
