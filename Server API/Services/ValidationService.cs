using Server_API.Context;

namespace Server_API.Services
{
    public class ValidationService
    {
        private readonly PSICRODbContext _context;
        public ValidationService(PSICRODbContext context)
        {
            _context = context;   
        }

        public bool LoginExist(string login)
        {
            return _context.Clients.Any(client => client.Login == login);
        }
    }
}
