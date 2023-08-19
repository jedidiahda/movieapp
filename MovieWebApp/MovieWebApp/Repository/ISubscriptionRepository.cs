using MovieWebApp.Models;
using MovieWebApp.Service.DTO;

namespace MovieWebApp.Repository
{
    public interface ISubscriptionRepository
    {
        public Subscription Save(Subscription subscription);
        public IEnumerable<Subscription> GetAll();

        public Subscription Update(int subscriptionId, Subscription subscription);
        public Subscription Get(int subscriptionId);
        public void Delete(int subscriptionId);

        public CustomerSubscription Subscribe(CustomerSubscription customerSubscription, Payment payment);
        public CustomerSubscription GetAvailableScription(int customerId, DateTime date);
        public IEnumerable<DvdStatusDTO> GetCustomerDvdStatus(int customerSubId);
        
    }
}
