using MovieWebApp.Models;

namespace MovieWebApp.Service.DTO
{
    public class CustomerSubscriptionAdapter
    {
        public static CustomerSubscription GetCustomerSubscription(CustomerSubscriptionDTO customerSubscriptionDTO)
        {
            if(customerSubscriptionDTO == null) return new CustomerSubscription();
            var customerSubscription = new CustomerSubscription();
            customerSubscription.Id = customerSubscriptionDTO.Id;
            customerSubscription.EndDate = customerSubscriptionDTO.EndDate;
            customerSubscription.StartDate = customerSubscriptionDTO.StartDate;
            customerSubscription.SubscriptId = customerSubscriptionDTO.SubscriptId;
            customerSubscription.CustomerId = customerSubscriptionDTO.CustomerId;
            return customerSubscription;
        }

        public static CustomerSubscriptionDTO GetCustomerSubscriptionDTO(CustomerSubscription customerSubscription)
        {
            if(customerSubscription == null) return new CustomerSubscriptionDTO();
            var customerSubscriptionDTO = new CustomerSubscriptionDTO();
            customerSubscriptionDTO.Id = customerSubscription.Id;
            customerSubscriptionDTO.EndDate = customerSubscription.EndDate; 
            customerSubscriptionDTO.StartDate = customerSubscription.StartDate;
            customerSubscriptionDTO.CustomerId = customerSubscription.CustomerId;
            customerSubscriptionDTO.SubscriptId= customerSubscription.SubscriptId;
            return customerSubscriptionDTO;
        }
    }
}
