using P_K_accounting.Models;
using System.Text.Json;

namespace P_K_accounting.Service.GridViewServices
{
    public class GridViewCompanyService
    {
        public async Task<List<CompanyServiceAccountantViewModel>> AddRecordToGrid(HttpResponseMessage response, DataGridView currentGrid)
        {
            var currentDataSource = (List<CompanyServiceAccountantViewModel>)currentGrid.DataSource;
            var content = await response.Content.ReadAsStringAsync();
            var companyServiceRecord = JsonSerializer.Deserialize<CompanyServiceAccountantViewModel>(content);
            var newServiceRecord = new CompanyServiceAccountantViewModel
            {
                ServiceId = companyServiceRecord.ServiceId,
                ServiceName = companyServiceRecord.ServiceName
            };

            var updatedDataSource = new List<CompanyServiceAccountantViewModel>(currentDataSource) { newServiceRecord };
            return updatedDataSource;
        }

        public async Task<List<CompanyServiceAccountantViewModel>> UpdateRecordInGrid(HttpResponseMessage response, DataGridView currentGrid)
        {
            var currentDataSource = (List<CompanyServiceAccountantViewModel>)currentGrid.DataSource;
            var content = await response.Content.ReadAsStringAsync();
            var serviceUpdated = JsonSerializer.Deserialize<CompanyServiceAccountantViewModel>(content);

            var currentRecord = currentDataSource.FirstOrDefault(service => service.ServiceId == serviceUpdated.ServiceId);
            if (currentRecord != null)
            {
                currentRecord.ServiceName = serviceUpdated.ServiceName;
            }

            return currentDataSource;
        }

        public async Task<List<CompanyServiceAccountantViewModel>> DeleteRecordFromGrid(int id, DataGridView currentGrid)
        {
            var currentDataSource = (List<CompanyServiceAccountantViewModel>)currentGrid.DataSource;
            var serviceToRemove = currentDataSource.FirstOrDefault(service => service.ServiceId == id);
            if (serviceToRemove != null)
            {
                currentDataSource.Remove(serviceToRemove);
            }

            var updatedDataSource = new List<CompanyServiceAccountantViewModel>(currentDataSource);
            return updatedDataSource;
        }
    }
}
