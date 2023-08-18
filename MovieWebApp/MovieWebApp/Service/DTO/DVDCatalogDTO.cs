namespace MovieWebApp.Service.DTO
{
    public class DVDCatalogDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";

        public string Description { get; set; } = "";

        public string Genre { get; set; } = "";

        public string Language { get; set; } = "";

        public int NoDisk { get; set; }

        public int StockQty { get; set; }

        public DateTime? ReleasedDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}
