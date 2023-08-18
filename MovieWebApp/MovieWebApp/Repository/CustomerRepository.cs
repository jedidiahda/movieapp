using MovieWebApp.Models;

namespace MovieWebApp.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MovieDbContext _movieDbContext;

        public CustomerRepository(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }
        public Customer Get(int customerId)
        {
            return _movieDbContext.Customers.Where(s => s.Id == customerId).FirstOrDefault();
        }
        public Customer Get(string email)
        {
            return _movieDbContext.Customers.Where(s => s.Email == email).FirstOrDefault();
        }

        public IEnumerable<Customer> GetAll(int limit, int pageNumber)
        {
            return _movieDbContext.Customers.Skip(pageNumber*limit).Take(limit).ToList();
        }

        public Customer Save(Customer customer)
        {
            _movieDbContext.Customers.Add(customer);
            _movieDbContext.SaveChanges();
            return customer;
        }

        public Customer Update(int customerId, Customer customer)
        {
            var saveCustomer = _movieDbContext.Customers.Where(s => s.Id == customerId).SingleOrDefault();
            if (saveCustomer == null) return null;

            saveCustomer.FirstName = customer.FirstName;
            saveCustomer.LastName = customer.LastName;
            saveCustomer.Email = customer.Email;
            saveCustomer.Gender = customer.Gender;
            saveCustomer.Address = customer.Address;

            return saveCustomer;
        }
    }
}
