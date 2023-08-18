using MovieWebApp.Models;

namespace MovieWebApp.Service.DTO
{
    public class CustomerAdapter
    {
        public static Customer GetCustomer(CustomerDTO customerDTO)
        {
            if(customerDTO == null) return new Customer();
            var customer = new Customer();
            customer.Id = customerDTO.Id;
            customer.FirstName = customerDTO.FirstName;
            customer.LastName = customerDTO.LastName;
            customer.Email = customerDTO.Email;
            customer.Gender = customerDTO.Gender;
            customer.Address = customerDTO.Address;
            
            return customer;
        }

        public static CustomerDTO GetCustomerDTO(Customer customer)
        {
            if(customer == null) return new CustomerDTO();
            var customerDTO = new CustomerDTO();
            customerDTO.Id = customer.Id;
            customerDTO.FirstName = customer.FirstName;
            customerDTO.LastName = customer.LastName;
            customerDTO.Gender = customer.Gender;
            customerDTO.Address = customer.Address;
            customerDTO.Email = customer.Email;

            return customerDTO;
        }
    }
}
