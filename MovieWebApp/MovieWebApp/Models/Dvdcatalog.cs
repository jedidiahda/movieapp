using System;
using System.Collections.Generic;

namespace MovieWebApp.Models;

public partial class Dvdcatalog
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? Genre { get; set; }

    public string? Language { get; set; }

    public int NoDisk { get; set; }

    public int StockQty { get; set; }

    public DateTime? ReleasedDate { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Dvdcopy> Dvdcopies { get; set; } = new List<Dvdcopy>();

    public virtual ICollection<Watchlist> Watchlists { get; set; } = new List<Watchlist>();
}
