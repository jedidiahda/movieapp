namespace MovieWebApp.Service.DTO
{
    public class DvdcopyDTO
    {
        public int ID { get; set; }
        public string? Status { get; set; }

        public string Code { get; set; }

        public int DvdcatalogId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
