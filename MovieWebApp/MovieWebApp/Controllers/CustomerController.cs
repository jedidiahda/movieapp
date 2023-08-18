using Microsoft.AspNetCore.Mvc;
using MovieWebApp.Repository;
using MovieWebApp.Service;
using MovieWebApp.Service.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;


        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerService = new CustomerService(customerRepository);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{customerId}")]
        public IActionResult Get(int customerId)
        {
            return Ok(_customerService.Get(customerId));
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post(CustomerDTO customerDTO)
        {
            try
            {
                _customerService.Save(customerDTO);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(customerDTO);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{customerId}")]
        public IActionResult Put(int customerId, CustomerDTO customerDTO)
        {
            try
            {
                _customerService.Update(customerId, customerDTO);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
            return Ok(customerDTO);
        }


    }
}
