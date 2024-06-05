using P_K_accounting.Models;
using P_K_accounting.Service.HttpServices;
using System.Net;
using System.Text;
using System.Text.Json;

namespace P_K_accounting.Service.EntityService
{
    public class CompanyFacilityService
    {
        private readonly HttpService_CompanyService _companyService;
        public CompanyFacilityService(HttpService_CompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<List<CompanyServiceAccountantViewModel>> GetAllServices()
        {
            HttpResponseMessage response = await _companyService.GetAllServices($"http://localhost:5239/service-api/services");
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return new List<CompanyServiceAccountantViewModel>();
            }

            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<CompanyServiceAccountantViewModel>>(content);
        }

        public async Task<HttpResponseMessage> AddService(string serviceName)
        {
            string json = JsonSerializer.Serialize(serviceName);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _companyService.AddNewService($"http://localhost:5239/service-api/add", content);
        }

        public async Task<HttpResponseMessage> UpdateServiceById(int id, string serviceName)
        {
            string json = JsonSerializer.Serialize(serviceName);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _companyService.UpdateServiceById($"http://localhost:5239/service-api/update/{id}", content);
        }

        public async Task<HttpResponseMessage> DeleteServiceById(int id)
        {
            return await _companyService.DeleteServiceById($"http://localhost:5239/service-api/delete/{id}");
        }

        public async Task<List<string>> GetServiceNames()
        {
            HttpResponseMessage response = await _companyService.GetServiceList($"http://localhost:5239/service-api/servicenames");
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return new List<string>();
            }

            response.EnsureSuccessStatusCode();
            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<string>>(responseContent);
        }

    }
}
