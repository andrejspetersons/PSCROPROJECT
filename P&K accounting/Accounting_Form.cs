using P_K_accounting.Models;
using P_K_accounting.Service.EntityService;
using P_K_accounting.Service.FormService;
using P_K_accounting.Service.GridViewServices;
using P_K_accounting.Service.HttpServices;
using P_K_accounting.Service.UIServices;
using System.Net;

namespace P_K_accounting
{
    public partial class Accounting_Form : Form
    {
        #region Services
        private readonly ClientPaymentBillService _clientService;
        private readonly CompanyFacilityService _companyService;
        private readonly UIHelper _helper;
        private readonly GridViewBillService _gridService;
        private readonly FormSwitcher _formSwitcher;
        #endregion
        #region FormDeclaration
        private Clients_Form _clientsForm;
        private CompanyService_Form _companyServiceForm;
        #endregion
        
        public Accounting_Form()
        #region Constructor
        {

            InitializeComponent();
            _clientService = new ClientPaymentBillService(new HttpService_PaymentBills());
            _companyService = new CompanyFacilityService(new HttpService_CompanyService());
            _helper = new UIHelper();
            _gridService = new GridViewBillService();
            _formSwitcher = new FormSwitcher();
        }
        #endregion

        #region OnFormLoadEvent
        private async void Accounting_Form_Load(object sender, EventArgs e)
        {
            _helper.DropDownLoadingMode(clientDropDown);
            _helper.DropDownLoadingMode(serviceDropDown);
            await LoadServicesAsync();
            await LoadClientsAsync();
        }
        #endregion
        #region EventHandlers
        private async void clientDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadClientBillsAsync();
        }

        private async void addBtn_Click(object sender, EventArgs e)
        {
            await AddPaymentAsync();
        }

        private async void updateBtn_Click(object sender, EventArgs e)
        {
            await UpdatePaymentAsync();
        }

        private async void deleteBillBtn_Click(object sender, EventArgs e)
        {
            await DeletePaymentAsync();
        }

        private void addingPanelBtn_Click(object sender, EventArgs e)
        {
            _helper.TogglePanels(AddPanel, UpdatePanel);
        }

        private void updatingPanelBtn_Click(object sender, EventArgs e)
        {
            _helper.TogglePanels(UpdatePanel, AddPanel);
        }

        private void clientBillsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PopulateUpdateFields(e.RowIndex);
        }
        private void clientBillsTable_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            _helper.HighlightLatePayments(clientBillsTable.Rows[e.RowIndex]);
        }

        private async void clientBillsTable_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                await FilterData(clientBillsTable.Columns[e.ColumnIndex].DataPropertyName);
            }
        }
        #endregion

        private void PopulateUpdateFields(int rowIndex)
        {
            if (rowIndex == -1) return;
            var row = clientBillsTable.Rows[rowIndex];
            idUpdateText.Text = row.Cells[0].Value.ToString();
            serviceNameUpdateText.Text = row.Cells[1].Value.ToString();
            amountUpdateText.Text = row.Cells[2].Value.ToString();
            updateIssueDateTimePicker.Value = DateTime.Parse(row.Cells[3].Value.ToString());
            updateDueToDateTimePicker.Value = DateTime.Parse(row.Cells[4].Value.ToString());
        }

        private async Task LoadClientsAsync()
        {
            var clients = await _clientService.GetClientListAsync();
            if (clients.Any())
            {
                clientDropDown.DataSource = clients;
                _helper.DropDownLoaded(clientDropDown);
            }
            else
            {
                _helper.DropDownFailToLoad(clientDropDown);
            }          
        }

        private async Task LoadServicesAsync()
        {
            
            var services = await _companyService.GetServiceNames();
            if (services.Any())
            {
                serviceDropDown.DataSource = services;
                _helper.DropDownLoaded(serviceDropDown);
            }
            else
            {
                _helper.DropDownFailToLoad(serviceDropDown);
            }
             
        }

        private async Task LoadClientBillsAsync()
        {
            if (string.IsNullOrEmpty(clientDropDown.SelectedItem?.ToString()))
            {
                MessageBox.Show("Choose client from dropdown list first", "Info", MessageBoxButtons.OK);
                return;
            }
            var selectedClientName = clientDropDown.SelectedItem.ToString();
            var clientBills = await _clientService.GetClientPaymentBillsAsync(selectedClientName);
            clientBillsTable.DataSource = clientBills;
        }

        private async Task AddPaymentAsync()
        {
            if (string.IsNullOrEmpty(clientDropDown.SelectedItem?.ToString()))
            {
                MessageBox.Show("Choose client from dropdown list first", "Info", MessageBoxButtons.OK);
                return;
            }

            var pbvm = new PaymentBillAccountantViewModel
            {
                ServiceName = serviceDropDown.Text,
                Amount = Convert.ToDecimal(amountText.Text),
                IssueDate = issueDateTimePicker.Value,
                DueToDate = duetoDateTimePicker.Value
            };

            var response = await _clientService.AddPaymentAsync(clientDropDown.SelectedItem.ToString(), pbvm);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                clientBillsTable.DataSource = await _gridService.AddRecordToGrid(response, clientBillsTable);
                clientBillsTable.Refresh();
            }
            await _helper.GetDialogByResponse(response);
        }

        private async Task UpdatePaymentAsync()
        {
            var pbvm = new PaymentBillAccountantViewModel
            {
                ServiceName = serviceNameUpdateText.Text,
                Amount = Convert.ToDecimal(amountUpdateText.Text),
                IssueDate = updateIssueDateTimePicker.Value,
                DueToDate = updateDueToDateTimePicker.Value
            };

            var response = await _clientService.UpdateClientBillByIdAsync(Convert.ToInt32(idUpdateText.Text), pbvm);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                clientBillsTable.DataSource=await _gridService.UpdateRecordInGrid(response, clientBillsTable);
                clientBillsTable.Refresh();
            }
            await _helper.GetDialogByResponse(response);
        }

        private async Task DeletePaymentAsync()
        {
            if (clientBillsTable.SelectedRows.Count == 0)
            {
                MessageBox.Show("No Payment Bill selected", "Info", MessageBoxButtons.OK);
                return;
            }

            int idToDelete = Convert.ToInt32(clientBillsTable.SelectedRows[0].Cells[0].Value);
            var response = await _clientService.DeletePaymentBillAsync(idToDelete);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                clientBillsTable.DataSource = await _gridService.DeleteRecordFromGrid(idToDelete, clientBillsTable);
                clientBillsTable.Refresh();
            }
            await _helper.GetDialogByResponse(response);
        }

        private async Task FilterData(string columnName)
        {
            var selectedClientName = clientDropDown.SelectedItem.ToString();
            var clientBillsFiltered = await _clientService.OrderClientBillsAsync(columnName, selectedClientName);
            clientBillsTable.DataSource = clientBillsFiltered;
        }

        private void btnToClientsForm_Click(object sender, EventArgs e)
        {
            _formSwitcher.ShowClientsForm();
        }
        
        private void btnToServiceForm_Click(object sender, EventArgs e)
        {
            _formSwitcher.ShowCompanyServiceForm();
        }

        #region LoadDataForComboBoxes
        private async void getServiceDropDownBtn_Click(object sender, EventArgs e)
        {
            _helper.DropDownLoadingMode(serviceDropDown);
            await LoadServicesAsync();
            _helper.DropDownLoaded(serviceDropDown);
        }

        private async void getClientDropDownBtn_Click(object sender, EventArgs e)
        {
            _helper.DropDownLoadingMode(clientDropDown);
            await LoadClientsAsync();
            _helper.DropDownLoaded(clientDropDown);
        }
        #endregion
    }
}

