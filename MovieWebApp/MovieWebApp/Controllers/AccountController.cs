using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieWebApp.Repository;
using MovieWebApp.Service;
using MovieWebApp.Service.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;

        public AccountController(IAccountRepository accountRepository,IConfiguration configuration,ICustomerRepository customerRepository)
        {
            _accountService = new AccountService(accountRepository,configuration,customerRepository);
        }

        // POST api/<AccountController>
        [HttpPost]
        public IActionResult Post(AccountDTO accountDTO)
        {
            try
            {
               return Ok(_accountService.Save(accountDTO));
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public IActionResult Login(AccountDTO accountDTO)
        {
            IActionResult response = Unauthorized();
            var token = _accountService.AuthenticateUser(accountDTO);
            

            if (token != string.Empty)
            {
                response = Ok(new { token = token});
            }

            return response;
        }
    }
}
