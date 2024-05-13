using Microsoft.AspNetCore.Mvc;
using Server_API.Context;
using Server_API.Models.WebFormsModels;

namespace Server_API.Controllers
{
    public class UserLoginController : Controller
    {
        private readonly PSICRODbContext _context;
        public UserLoginController(PSICRODbContext context)
        {
            _context = context;    
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody]UserLoginViewModel userlogin)
        {
            var result = _context.Clients.FirstOrDefault(client => client.Login == userlogin.UserName);
            if (result == null)
            {
                return NotFound(result);
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
