namespace MovieWebApp.Service.DTO
{
    public class CustomerReturnDTO
    {
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? Title { get; set; }
        public string? Code { get; set; }
        public int? CustomerSubscriptionId { get; set; }
        public int? DvdCatalogId { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
