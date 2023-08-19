using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieWebApp.Models;
using MovieWebApp.Repository;
using MovieWebApp.Service;
using MovieWebApp.Service.DTO;

namespace MovieWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestDVDController : ControllerBase
    {
        private readonly RequestDVDService _requestDVDService;

        public RequestDVDController(IRequestDVDRepository requestDVDRepository)
        {
            _requestDVDService = new RequestDVDService(requestDVDRepository);
        }

        [HttpGet]
        public IActionResult GetAll(int customerId)
        {
            return Ok(_requestDVDService.GetAll(customerId));
        }

        [HttpDelete]
        public IActionResult Delete(int requestId)
        {
            try
            {
                _requestDVDService.Delete(requestId);
                return Ok();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(RequestedDvdDTO requestedDvd)
        {
            try
            {
                return Ok(_requestDVDService.Save(requestedDvd));
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

   
}
