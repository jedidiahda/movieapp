using Microsoft.AspNetCore.Mvc;
using MovieWebApp.Repository;
using MovieWebApp.Service;
using MovieWebApp.Service.DTO;

namespace MovieWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly SubscriptionService _SubscriptionService;

        public SubscriptionController(ISubscriptionRepository subscriptionRepository)
        {
            _SubscriptionService = new SubscriptionService(subscriptionRepository);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_SubscriptionService.GetAll());
        }

        [HttpGet("{subscriptionId}")]
        public IActionResult Get(int subscriptionId)
        {
            return Ok(_SubscriptionService.GetSubscription(subscriptionId));
        }

        [HttpPost]
        public IActionResult Post(SubscriptionDTO subscriptionDTO)
        {
            try
            {
                if (subscriptionDTO != null)
                {
                    _SubscriptionService.Save(subscriptionDTO);
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }

            return Ok();
        }


        [HttpPut("{subscriptionId}")]
        public IActionResult Put(int subscriptionId,SubscriptionDTO subscriptionDTO)
        {
            try
            {
                _SubscriptionService.Update(subscriptionId, subscriptionDTO);
            }catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
            return Ok(subscriptionDTO);
        }

        [HttpDelete("{subscriptionId}")]
        public IActionResult Delete(int subscriptionId)
        {
            var subscription = _SubscriptionService.GetSubscription(subscriptionId);
            if(subscription == null)
            {
                return NotFound("Subscription not found");
            }

            _SubscriptionService.Delete(subscriptionId);

            return Ok();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Route("subscribe")]
        public IActionResult Subcribe(CustomerSubscriptionDTO customerSubscriptionDTO)
        {
            if (customerSubscriptionDTO == null)
            {
                return BadRequest("Something went wrong");
            }

            try
            {
                return Ok(_SubscriptionService.Subscribe(customerSubscriptionDTO));
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("GetAvailableScription")]
        public IActionResult GetAvailableScription(int customerId,DateTime date)
        {
            return Ok(CustomerSubscriptionAdapter.GetCustomerSubscriptionDTO( _SubscriptionService.GetAvailableScription(customerId, date)));
        }

        [HttpGet]
        [Route("GetCustomerDvdStatus")]
        public IActionResult GetCustomerDVDStatus(int customerSubId)
        {
            return Ok(_SubscriptionService.GetCustomerDvdStatus(customerSubId));
        }
    }
}
