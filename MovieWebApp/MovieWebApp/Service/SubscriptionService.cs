using MovieWebApp.Service.DTO;
using MovieWebApp.Repository;
using MovieWebApp.Models;

namespace MovieWebApp.Service
{
    public class SubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;


        public SubscriptionService(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }
        public IEnumerable<SubscriptionDTO> GetAll()
        {
            IEnumerable<Subscription> subscriptions = _subscriptionRepository.GetAll();
            List<SubscriptionDTO> subscriptionDTOs = new List<SubscriptionDTO>();
            foreach(var subscription in subscriptions)
            {
                subscriptionDTOs.Add(SubscriptionAdaptor.GetSubscriptionDTO(subscription));
            }
            return subscriptionDTOs;
        }

        public SubscriptionDTO Save(SubscriptionDTO subscriptionDTO)
        {
            var subscription = _subscriptionRepository.Save(SubscriptionAdaptor.GetSubscription(subscriptionDTO));
            return SubscriptionAdaptor.GetSubscriptionDTO(subscription);
        }

        public SubscriptionDTO Update(int subscriptionId, SubscriptionDTO subscriptionDTO)
        {
            var subscription = _subscriptionRepository.Update(subscriptionId, SubscriptionAdaptor.GetSubscription(subscriptionDTO));
            return SubscriptionAdaptor.GetSubscriptionDTO(subscription);
        }

        public SubscriptionDTO GetSubscription(int subscriptionId)
        {
            return SubscriptionAdaptor.GetSubscriptionDTO(_subscriptionRepository.Get(subscriptionId));
        }

        public void Delete(int subcriptionId)
        {
            _subscriptionRepository.Delete(subcriptionId);
        }

        public CustomerSubscription Subscribe(CustomerSubscriptionDTO customerSubscriptionDTO)
        {

            var customerSub = _subscriptionRepository.Subscribe(CustomerSubscriptionAdapter.GetCustomerSubscription(customerSubscriptionDTO),PaymentAdapter.GetPayment(customerSubscriptionDTO.payment));
            return customerSub;
        }

        public CustomerSubscription GetAvailableScription(int customerId, DateTime date)
        {
            return _subscriptionRepository.GetAvailableScription(customerId,date);
        }
        public IEnumerable<Dvdstatus> GetCustomerDvdStatus(int customerSubId)
        {
            return _subscriptionRepository.GetCustomerDvdStatus(customerSubId);
        }
    }
}
