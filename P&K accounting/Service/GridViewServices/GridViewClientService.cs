using P_K_accounting.Models;
using System.Text.Json;

namespace P_K_accounting.Service.GridViewServices
{
    public class GridViewClientService
    {
        public async Task<List<ClientAccountantViewModel>> AddRecordToGrid(HttpResponseMessage response, DataGridView currentGrid)
        {
            var currentDataSource = (List<ClientAccountantViewModel>)currentGrid.DataSource;
            var content = await response.Content.ReadAsStringAsync();
            var clientInfo = JsonSerializer.Deserialize<ClientAccountantViewModel>(content);
            var newClient = new ClientAccountantViewModel()
            {
                ClientId = clientInfo.ClientId,
                FirstName = clientInfo.FirstName,
                LastName = clientInfo.LastName,
                Phone = clientInfo.Phone,
                Email = clientInfo.Email
            };

            var updatedDataSource = new List<ClientAccountantViewModel>(currentDataSource) { newClient };
            return updatedDataSource;
        }

        public async Task<List<ClientAccountantViewModel>> UpgradeRecordInGrid(HttpResponseMessage response, DataGridView currentGrid)
        {
            var currentDataSource = (List<ClientAccountantViewModel>)currentGrid.DataSource;
            var content = await response.Content.ReadAsStringAsync();
            var clientUpdated = JsonSerializer.Deserialize<ClientAccountantViewModel>(content);

            var currentRecord = currentDataSource.FirstOrDefault(record => record.ClientId == clientUpdated.ClientId);
            if (currentRecord != null)
            {
                currentRecord.FirstName = clientUpdated.FirstName;
                currentRecord.LastName = clientUpdated.LastName;
                currentRecord.Phone = clientUpdated.Phone;
                currentRecord.Email = clientUpdated.Email;
            }

            return currentDataSource;
        }

        public async Task<List<ClientAccountantViewModel>> DeleteRecordFromGid(int id, DataGridView currentGrid)
        {
            var currentDataSource = (List<ClientAccountantViewModel>)currentGrid.DataSource;
            var clientToRemove = currentDataSource.FirstOrDefault(client => client.ClientId == id);
            if (clientToRemove != null)
            {
                currentDataSource.Remove(clientToRemove);
            }

            var updatedDataSource = new List<ClientAccountantViewModel>(currentDataSource);
            return updatedDataSource;
        }
    }
}
