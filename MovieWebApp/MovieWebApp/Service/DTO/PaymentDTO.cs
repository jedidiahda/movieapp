namespace MovieWebApp.Service.DTO
{
    public class PaymentDTO
    {
        public decimal? Amount { get; set; }

        public DateTime? PaymentDate { get; set; }

        public int? PaymentType { get; set; }


        public string? BillingAddress { get; set; }

    }
}
