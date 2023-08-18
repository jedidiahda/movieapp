using MovieWebApp.Models;

namespace MovieWebApp.Service.DTO
{
    public class CustomerSubscriptionDTO
    {
        public int CustomerId { get; set; }

        public int SubscriptId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Id { get; set; }

        public PaymentDTO payment { get; set; }
    }
}
