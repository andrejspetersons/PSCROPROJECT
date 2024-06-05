using P_K_accounting.Service.EntityService;
using P_K_accounting.Service.GridViewServices;
using P_K_accounting.Service.HttpServices;
using P_K_accounting.Service.UIServices;
using System.Net;

namespace P_K_accounting
{
    public partial class CompanyService_Form : Form
    {
        private readonly CompanyFacilityService _companyService;
        private readonly GridViewCompanyService _gridService;
        private UIHelper _helper;
        public CompanyService_Form()
        {
            _companyService = new CompanyFacilityService(new HttpService_CompanyService());
            _gridService = new GridViewCompanyService();
            _helper = new UIHelper();
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

        private void addPanelBtn_Click(object sender, EventArgs e)
        {
            _helper.TogglePanels(addingPanel, updatingPanel);
        }

        private void updatePanelBtn_Click(object sender, EventArgs e)
        {
            _helper.TogglePanels(updatingPanel, addingPanel);
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

        private async Task GetServices()
        {
            var services = await _companyService.GetAllServices();
            companyserviceTable.DataSource = services;
        }

        private async Task AddService(string serviceName)
        {
            HttpResponseMessage response = await _companyService.AddService(serviceName);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                companyserviceTable.DataSource = await _gridService.AddRecordToGrid(response, companyserviceTable);
                companyserviceTable.Refresh();
            }
            await _helper.GetDialogByResponse(response);
        }

        private async Task UpdateService(int id, string serviceName)
        {
            HttpResponseMessage response = await _companyService.UpdateServiceById(id, serviceName);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                companyserviceTable.DataSource = await _gridService.UpdateRecordInGrid(response, companyserviceTable);
                companyserviceTable.Refresh();
            }
            await _helper.GetDialogByResponse(response);
        }

        private async Task DeleteService(int id)
        {
            HttpResponseMessage response = await _companyService.DeleteServiceById(id);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                companyserviceTable.DataSource = await _gridService.DeleteRecordFromGrid(id, companyserviceTable);
                companyserviceTable.Refresh();
            }
            await _helper.GetDialogByResponse(response);
        }
     
    }
}
