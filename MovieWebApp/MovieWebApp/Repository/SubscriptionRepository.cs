

using MovieWebApp.Models;

namespace MovieWebApp.Repository
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly MovieDbContext _movieDbContext;

        public SubscriptionRepository(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public void Delete(int subscriptionId)
        {

            var saveSubscription = _movieDbContext.Subscriptions.Where(s => s.Id == subscriptionId).FirstOrDefault();

            if (saveSubscription != null)
            {
                saveSubscription.IsDeleted = true;
                _movieDbContext.SaveChanges();
            }
        }

        public Subscription Get(int subscriptionId)
        {
            return _movieDbContext.Subscriptions.Where(s => s.Id == subscriptionId).FirstOrDefault();
        }

        public IEnumerable<Subscription> GetAll()
        {
            
            return this._movieDbContext.Subscriptions.Where(s=>s.IsDeleted == false).ToList();
        }

        public Subscription Save(Subscription subscription)
        {
            _movieDbContext.Subscriptions.Add(subscription);
            _movieDbContext.SaveChanges();
            return subscription;
        }



        public Subscription Update(int subscriptionId, Subscription subscription)
        {
            var saveSubscription = _movieDbContext.Subscriptions.Where(s => s.Id == subscriptionId).FirstOrDefault();
            
            if(saveSubscription != null)
            {
                saveSubscription.Name = subscription.Name;
                saveSubscription.AtHomeDvd = subscription.AtHomeDvd;
                saveSubscription.Price = subscription.Price;
                saveSubscription.NoDvdperMonth = subscription.NoDvdperMonth;
                _movieDbContext.SaveChanges();
            }
     
            return subscription;
        }

        public CustomerSubscription Subscribe(CustomerSubscription customerSubscription,Payment payment)
        {
            var tran = _movieDbContext.Database.BeginTransaction();
            try
            {
                
                _movieDbContext.CustomerSubscriptions.Add(customerSubscription);
                _movieDbContext.SaveChanges();

                payment.CustomerSubscriptionId = customerSubscription.Id;
                _movieDbContext.Payments.Add(payment);
                _movieDbContext.SaveChanges();

                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
            }
       
            return customerSubscription;
        }

        public CustomerSubscription GetAvailableScription(int customerId,DateTime date)
        {
            return _movieDbContext.CustomerSubscriptions
                .Where(s => s.CustomerId == customerId && s.StartDate >= date && date <= s.EndDate).FirstOrDefault(); 
        }

        public IEnumerable<Dvdstatus> GetCustomerDvdStatus(int customerSubId)
        {
            return _movieDbContext.Dvdstatuses.Where(s => s.CustomerSubscriptionId == customerSubId);
        }
    }
}
