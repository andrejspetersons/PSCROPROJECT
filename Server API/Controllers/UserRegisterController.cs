using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Server_API.Models.Entity;
using Server_API.Services.UserService;

namespace Server_API.Controllers
{
    public class UserRegisterController : Controller
    {

        private readonly IUserService _userservice;
        private readonly IValidator<Client> _clientvalidator;

        public UserRegisterController(IUserService userservice, IValidator<Client> clientvalidator)
        {
            _userservice = userservice;
            _clientvalidator = clientvalidator;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult RegisterUser([FromBody] Client client)
        {
            var result = _clientvalidator.Validate(client);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            if (_userservice.isRegistered(client))
            {
                return Conflict();
            }
            else
            {
                return Ok(client);
            }          
        }


    }
}
