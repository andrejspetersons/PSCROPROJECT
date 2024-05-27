using Microsoft.AspNetCore.Mvc;
using Server_API.Services.UserService;

namespace Server_API.Controllers
{
    public class UserLoginController : Controller
    {
        private readonly IUserService _userservice;
        public UserLoginController(IUserService userservice)
        {
            _userservice = userservice;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody]string username)
        {
            if (_userservice.isLoggedIn(username))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
