using P_K_accounting.Models;
using System.Net;
using System.Text;
using System.Text.Json;

namespace P_K_accounting.Service
{
    public class ClientService
    {
        private readonly HttpService_Clients _clientService;
        public ClientService(HttpService_Clients clientService)
        {
            _clientService = clientService;
        }

        public async Task<List<ClientAccountantViewModel>> ClientCredentialsLoadAsync()
        {
            HttpResponseMessage response = await _clientService.GetClientsAsync("http://localhost:5239/client-api/clients");
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return new List<ClientAccountantViewModel>();
            }

            response.EnsureSuccessStatusCode();
            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<ClientAccountantViewModel>>(responseContent);
            
        }

        public async Task<HttpResponseMessage> AddClientAsync(ClientAddViewModel cavm)
        {
            string json = JsonSerializer.Serialize(cavm);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _clientService.AddClientAsync($"http://localhost:5239/client-api/add", content);
        }

        public async Task<HttpResponseMessage> UpdateClientAsync(int id, ClientAccountantViewModel cvm)
        {
            string json = JsonSerializer.Serialize(cvm);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _clientService.UpdateClientAsync($"http://localhost:5239/client-api/update/{id}",content);
        }

        public async Task<HttpResponseMessage> DeleteClientAsync(int id)
        {
            return await _clientService.DeleteClientAsync($"http://localhost:5239/client-api/delete/{id}");
        }
    }
}
