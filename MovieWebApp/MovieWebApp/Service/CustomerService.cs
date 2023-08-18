using MovieWebApp.Repository;
using MovieWebApp.Service.DTO;

namespace MovieWebApp.Service
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public CustomerDTO Save(CustomerDTO customerDTO)
        {
            var customer = _customerRepository.Save(CustomerAdapter.GetCustomer(customerDTO));
            customerDTO.Id = customer.Id;
            return customerDTO;
        }
        public CustomerDTO Get(int customerId)
        {
            return CustomerAdapter.GetCustomerDTO(_customerRepository.Get(customerId));
        }
        public CustomerDTO Update(int customerId, CustomerDTO customerDTO)
        {
            _customerRepository.Update(customerId, CustomerAdapter.GetCustomer(customerDTO));
            return customerDTO;
        }
        public IEnumerable<CustomerDTO> GetAll(int limit, int pageNumber)
        {
            var customerList = _customerRepository.GetAll(limit, pageNumber);
            var customerDTOList = new List<CustomerDTO>();
            foreach (var customer in customerList)
            {
                customerDTOList.Add(CustomerAdapter.GetCustomerDTO(customer));
            }
            return customerDTOList;
        }
    }
}
