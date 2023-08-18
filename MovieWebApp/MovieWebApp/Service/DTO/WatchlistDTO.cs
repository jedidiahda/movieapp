namespace MovieWebApp.Service.DTO
{
    public class WatchlistDTO
    {
        public int Rank { get; set; }

        public int DvdcatalogId { get; set; }

        public int CustomerId { get; set; }
        public DVDCatalogDTO? Dvdcatalog { get; set; }
    }
}
