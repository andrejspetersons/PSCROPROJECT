using Server_API.Context;

namespace Server_API.Services.ValidationServices
{
    public class DuplicateService : IDuplicateService
    {
        private readonly PSICRODbContext _context;
        public DuplicateService(PSICRODbContext context)
        {
            _context = context;
        }

        public bool EmailExist(string email)
        {
            return _context.Clients.Any(client => client.Email == email);
        }

        public bool LoginExist(string login)
        {
            return _context.Clients.Any(client => client.Login == login);
        }

        public bool PhoneNumberExist(string phone)
        {
            return _context.Clients.Any(client => client.Phone == phone);
        }

        public bool ServiceNameExist(string servicename)
        {
            return _context.CompanyServices.Any(service => service.Name == servicename);
        }
    }
}
