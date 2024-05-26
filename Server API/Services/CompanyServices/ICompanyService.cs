using Server_API.Models.Entity;

namespace Server_API.Services.CompanyServices
{
    public interface ICompanyServices
    {
        public bool AddService(string serviceName);
        public bool UpdateServiceById(int id, string serviceName);
        public bool DeleteServiceById(int id);
        public List<CompanyService> GetAllServices();
        public List<string> GetServiceNames();
    }
}
