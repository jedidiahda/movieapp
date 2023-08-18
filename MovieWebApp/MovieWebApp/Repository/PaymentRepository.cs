using MovieWebApp.Models;

namespace MovieWebApp.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly MovieDbContext _movieDbContext;

        public PaymentRepository(MovieDbContext movieDbContext)
        {
            this._movieDbContext = movieDbContext;
        }

        public Payment Save(Payment payment)
        {
            _movieDbContext.Payments.Add(payment);
            _movieDbContext.SaveChanges();
            return payment;
        }
    }
}
