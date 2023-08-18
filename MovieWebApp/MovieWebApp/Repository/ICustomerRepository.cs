using MovieWebApp.Models;

namespace MovieWebApp.Repository
{
    public interface ICustomerRepository
    {
        public Customer Save(Customer customer);
        public Customer Get(int customerId);
        public Customer Get(string email);

        public Customer Update(int customerId, Customer customer);
        public IEnumerable<Customer> GetAll(int limit,int pageNumber);
    }
}
