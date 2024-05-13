using Microsoft.AspNetCore.Mvc;
using Server_API.Context;
using Server_API.Models.Entity;
using Server_API.Services;

namespace Server_API.Controllers
{
    public class UserRegisterController : Controller
    {

        private readonly PSICRODbContext _context;
        private readonly ValidationService _validationService;

        public UserRegisterController(PSICRODbContext context,ValidationService validationService)
        {
            _context = context;
            _validationService = validationService;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult RegisterUser([FromBody] Client client)
        {
            if (_validationService.LoginExist(client.Login))
            {
                return Conflict();
            }
            _context.Clients.Add(client);
            _context.SaveChanges();
            return Ok(client);
        }


    }
}
