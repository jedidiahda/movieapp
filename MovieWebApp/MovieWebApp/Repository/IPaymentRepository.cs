using MovieWebApp.Models;

namespace MovieWebApp.Repository
{
    public interface IPaymentRepository
    {
        public Payment Save(Payment payment);
    }
}
