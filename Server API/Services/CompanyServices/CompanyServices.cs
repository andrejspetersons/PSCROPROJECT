using Server_API.Context;
using Server_API.Models.Entity;

namespace Server_API.Services.CompanyServices
{
    public class CompanyServices : ICompanyServices
    {
        private readonly PSICRODbContext _context;
        public CompanyServices(PSICRODbContext context)
        {
            _context = context;
        }
        public bool AddService(string serviceName)
        {
            var service = _context.CompanyServices.FirstOrDefault(service => service.Name == serviceName);
            if (service == null)
            {
                _context.CompanyServices.Add(new CompanyService { Name = serviceName });
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteServiceById(int id)
        {
            var service = _context.CompanyServices.FirstOrDefault(service => service.Id == id);
            if (service == null)
            {
                return false;
            }
            else
            {
                _context.CompanyServices.Remove(service);
                _context.SaveChanges();
                return true;
            }
        }

        public List<CompanyService> GetAllServices()
        {
            return _context.CompanyServices.ToList();
        }

        public List<string> GetServiceNames()
        {
            return _context.CompanyServices.Select(service => service.Name).ToList();
        }

        public bool UpdateServiceById(int id,string serviceName)
        {
            var service = _context.CompanyServices.FirstOrDefault(service => service.Id == id);
            if (service == null)
            {
                return false;
            }
            else
            {
                service.Name = serviceName;
                _context.SaveChanges();
                return true;
            }
        }
    }
}
