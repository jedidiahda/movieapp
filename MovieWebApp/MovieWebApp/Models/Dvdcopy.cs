using System;
using System.Collections.Generic;

namespace MovieWebApp.Models;

public partial class Dvdcopy
{
    public string? Status { get; set; }

    public string Code { get; set; } = null!;

    public int DvdcatalogId { get; set; }

    public bool IsDeleted { get; set; }

    public int Id { get; set; }

    public virtual Dvdcatalog Dvdcatalog { get; set; } = null!;
}
