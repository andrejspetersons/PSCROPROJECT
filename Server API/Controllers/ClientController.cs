using Microsoft.AspNetCore.Mvc;
using Server_API.Services.AccountantService;
using Server_API.Services.UserService;

namespace Server_API.Controllers
{
    public class ClientController : Controller
    {
        private readonly IUserService _userservice;
        private readonly IAccountantService _accountantservice;

        public ClientController(IUserService userservice, IAccountantService accountantservice)
        {
            _userservice = userservice;
            _accountantservice = accountantservice;
        }

        [HttpGet]
        [Route("paymentbills/{username}")]
        public IActionResult GetClientPaymentBills(string username)
        {
            var clientBills = _userservice.GetClientPaymentBills(username);
            if (clientBills.Count>0)
            {              
                return Ok(clientBills);
            }

            return NoContent();        
        }

        [HttpPut]
        [Route("paybill/{id}")]
        public IActionResult PayTheBill(int id)
        {
            if (_userservice.PayTheBill(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("clients")]
        public IActionResult GetAllClients()
        {
            var result = _accountantservice.GetAllClients();
            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }

    }
}
