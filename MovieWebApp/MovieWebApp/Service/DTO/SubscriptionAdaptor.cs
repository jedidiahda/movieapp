using MovieWebApp.Models;
using MovieWebApp.Service.DTO;

namespace MovieWebApp.Service.DTO
{
    public class SubscriptionAdaptor
    {
        public static SubscriptionDTO GetSubscriptionDTO(Subscription subscription)
        {
            if(subscription == null) return null;

            SubscriptionDTO subscriptionDTO = new SubscriptionDTO(subscription.Id,subscription.Name, subscription.AtHomeDvd, subscription.NoDvdperMonth, subscription.Price,subscription.IsDeleted);
            return subscriptionDTO;
        }

        public static Subscription GetSubscription(SubscriptionDTO subscriptionDTO)
        {
            if(subscriptionDTO == null) return null;

            Subscription subscription = new Subscription();
            subscription.Id = subscriptionDTO.Id;
            subscription.Name = subscriptionDTO.Name;
            subscription.AtHomeDvd = subscriptionDTO.AtHomeDvd;
            subscription.NoDvdperMonth = subscriptionDTO.NoDvdperMonth;
            subscription.Price = subscriptionDTO.Price;
            subscription.IsDeleted = subscriptionDTO.IsDeleted;

            return subscription;
        }
    }
}
