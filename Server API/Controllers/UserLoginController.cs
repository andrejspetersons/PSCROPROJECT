using Microsoft.AspNetCore.Mvc;
using Serilog;
using Server_API.Services.UserService;
using System.Net;

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
                Log.Information("Method {method} was called with Result:{HttpStatusCode}", nameof(Login), (int)HttpStatusCode.OK);
                return Ok();
            }
            else
            {
                Log.Error("Method {method} was called with Result:{HttpStatusCode}.No client was found with username {username}", nameof(Login), (int)HttpStatusCode.NotFound, username);
                return NotFound();
            }
        }
    }
}
