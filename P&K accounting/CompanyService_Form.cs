using P_K_accounting.Service;
using System.Net;

namespace P_K_accounting
{
    public partial class CompanyService_Form : Form
    {
        private readonly CompanyFacilityService _companyService;
        public CompanyService_Form()
        {
            _companyService = new CompanyFacilityService(new HttpService_CompanyService());
            InitializeComponent();
        }

        private async void CompanyService_Form_Load(object sender, EventArgs e)
        {
            await GetServices();
        }

        private async void addServiceBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ServiceNameAddText.Text))
            {
                MessageBox.Show("Fill up the form first", "Info", MessageBoxButtons.OK);
                return;
            }
            else
            {
                await AddService(ServiceNameAddText.Text);
            }
        }

        private async void updateServiceBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ServiceNameUpdateText.Text))
            {
                MessageBox.Show("Fill up the form first", "Info", MessageBoxButtons.OK);
                return;
            }
            else
            {
                await UpdateService(Convert.ToInt32(ServiceIdUpdate.Text), ServiceNameUpdateText.Text);
            }
        }

        private async void deleteServiceBtn_Click(object sender, EventArgs e)
        {
            if (companyserviceTable.SelectedRows.Count == 0)
            {
                MessageBox.Show("No Service was selected", "Info", MessageBoxButtons.OK);
                return;
            }
            else
            {
                var serviceId = Convert.ToInt32(companyserviceTable.SelectedRows[0].Cells[0].Value.ToString());
                await DeleteService(Convert.ToInt32(serviceId));
            }

        }

        private async void getServicesBtn_Click(object sender, EventArgs e)
        {
            await GetServices();
        }

        private void addPanelBtn_Click(object sender, EventArgs e)
        {
            TogglePanel(addingPanel, updatingPanel);
        }

        private void updatePanelBtn_Click(object sender, EventArgs e)
        {
            TogglePanel(updatingPanel, addingPanel);
        }

        private void companyserviceTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PopulateField(e.RowIndex);
        }

        private void PopulateField(int index)
        {
            if (index == -1) return;
            var row = companyserviceTable.Rows[index];
            ServiceIdUpdate.Text = row.Cells[0].Value.ToString();
            ServiceNameUpdateText.Text = row.Cells[1].Value.ToString();
        }

        private void TogglePanel(Panel showPanel, Panel hidePanel)
        {
            showPanel.Visible = true;
            hidePanel.Visible = false;
            showPanel.Location = new Point(32, 75);
        }

        private async Task GetServices()
        {
            var services = await _companyService.GetAllServices();
            companyserviceTable.DataSource = services;
        }

        private async Task AddService(string serviceName)
        {
            HttpResponseMessage response = await _companyService.AddService(serviceName);
            MessageBox.Show(response.IsSuccessStatusCode ? "Service successfully added" :
            (response.StatusCode == HttpStatusCode.Conflict ? "Service already exist" : "Entered data is incorrect"), "Info", MessageBoxButtons.OK);
        }

        private async Task UpdateService(int id, string serviceName)
        {
            HttpResponseMessage response = await _companyService.UpdateServiceById(id, serviceName);
            MessageBox.Show(response.IsSuccessStatusCode ? "Service successfully updated" : "Entered data is incorrect", "Info", MessageBoxButtons.OK);
        }

        private async Task DeleteService(int id)
        {
            HttpResponseMessage response = await _companyService.DeleteServiceById(id);
            MessageBox.Show(response.IsSuccessStatusCode ? "Service deleted successfully" : "Service doesnt exist", "Info", MessageBoxButtons.OK);
        }
     
    }
}
