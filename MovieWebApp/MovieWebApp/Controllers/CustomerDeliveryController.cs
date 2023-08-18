using Microsoft.AspNetCore.Mvc;
using MovieWebApp.Repository;
using MovieWebApp.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerDeliveryController : ControllerBase
    {
        private readonly CustomerDeliveryService _customerDeliveryService;
        
        public CustomerDeliveryController(ICustomerDeliveryRepository customerDeliveryRepository)
        {
            _customerDeliveryService = new CustomerDeliveryService(customerDeliveryRepository);
        }

        // GET: api/<CustomerDeliveryController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_customerDeliveryService.GetValidCustomerDelivery());
        }

        [HttpPost]
        [Route("deliver")]
        public IActionResult DeliveryToCustomer(int subscriptionId, string code,int dvdCatalogId)
        {
            try
            {
                _customerDeliveryService.SendDvdToCustomer(subscriptionId, code, dvdCatalogId);
                return Ok();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
