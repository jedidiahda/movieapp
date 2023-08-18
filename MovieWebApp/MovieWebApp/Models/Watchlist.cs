using System;
using System.Collections.Generic;

namespace MovieWebApp.Models;

public partial class Watchlist
{
    public int? Rank { get; set; }

    public int DvdcatalogId { get; set; }

    public int CustomerId { get; set; }

    public virtual Dvdcatalog Dvdcatalog { get; set; } = null!;
}
