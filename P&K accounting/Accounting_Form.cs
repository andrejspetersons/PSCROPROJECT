using P_K_accounting.Models; 
using P_K_accounting.Service;

namespace P_K_accounting
{
    public partial class Accounting_Form : Form
    {
        private readonly ClientPaymentBillService _clientService;
        private readonly CompanyFacilityService _companyService;
        private Clients_Form _clientsForm;
        private CompanyService_Form _companyServiceForm;


        public Accounting_Form()
        {
            InitializeComponent();
            _clientService = new ClientPaymentBillService(new HttpService_PaymentBills());
            _companyService = new CompanyFacilityService(new HttpService_CompanyService());
        }

        private async void Accounting_Form_Load(object sender, EventArgs e)
        {
            DropDownLoadingMode(clientDropDown);
            DropDownLoadingMode(serviceDropDown);
            await LoadServicesAsync();
            await LoadClientsAsync();
        }

        private void DropDownLoadingMode(ComboBox dropDownOnLoad)
        {
            dropDownOnLoad.Text = "Loading...";
            dropDownOnLoad.Enabled = false;
        }

        private void DropDownLoaded(ComboBox dropDownLoaded)
        {
            dropDownLoaded.Text = "";
            dropDownLoaded.Enabled = true;
        }

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

        private async void getClientRecords_Click(object sender, EventArgs e)
        {
            await LoadClientBillsAsync();
        }

        private void addingPanelBtn_Click(object sender, EventArgs e)
        {
            TogglePanels(AddPanel, UpdatePanel);
        }

        private void updatingPanelBtn_Click(object sender, EventArgs e)
        {
            TogglePanels(UpdatePanel, AddPanel);
        }

        private void clientBillsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PopulateUpdateFields(e.RowIndex);
        }
        private void clientBillsTable_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            HighlightLatePayments(e.RowIndex);
        }

        private async void clientBillsTable_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                await FilterData(clientBillsTable.Columns[e.ColumnIndex].DataPropertyName);
            }
        }

        private void TogglePanels(Panel visiblePanel, Panel hidePanel)
        {
            Point location = new Point(12, 75);
            visiblePanel.Visible = true;
            hidePanel.Visible = false;
            visiblePanel.Location = location;
        }

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

        private void HighlightLatePayments(int rowIndex)
        {
            var row = clientBillsTable.Rows[rowIndex];
            if (row.Cells[5].Value == null) return;
            if (DateTime.TryParse(row.Cells[4].Value.ToString(), out var dueToDate) &&
                DateTime.TryParse(row.Cells[5].Value.ToString(), out var paymentDate) &&
                paymentDate > dueToDate)
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 87, 87);
            }
        }

        private async Task LoadClientsAsync()
        {
            clientDropDown.Items.Clear();
            var clients = await _clientService.GetClientListAsync();
            if (clients.Any())
            {
                foreach (var client in clients)
                {
                    clientDropDown.Items.Add(client);
                }

                DropDownLoaded(clientDropDown);
            }
            else
            {
                clientDropDown.Text = "No clients available";
                clientDropDown.Enabled = false;
            }

        }

        private async Task LoadServicesAsync()
        {
            serviceDropDown.Items.Clear();
            var services = await _companyService.GetServiceNames();
            if (services.Any())
            {
                foreach (var service in services)
                {
                    serviceDropDown.Items.Add(service);
                }

                DropDownLoaded(serviceDropDown);
            }
            else
            {
                serviceDropDown.Text = "No service available";
                serviceDropDown.Enabled = false;
            }
        }

        private async Task LoadClientBillsAsync()
        {
            if (string.IsNullOrEmpty(clientDropDown.SelectedItem?.ToString()))
            {
                MessageBox.Show("Choose client from dropdown list first", "Info", MessageBoxButtons.OK);
                return;
            }
            else
            {
                var selectedClientName = clientDropDown.SelectedItem.ToString();
                var clientBills = await _clientService.GetClientPaymentBillsAsync(selectedClientName);
                clientBillsTable.DataSource = clientBills;
            }
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
            MessageBox.Show(response.IsSuccessStatusCode ? "Payment Bill successfully added" : "Entered data is incorrect", "Info", MessageBoxButtons.OK);
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
            MessageBox.Show(response.IsSuccessStatusCode ? "Payment info was updated successfully" : "Entered data is incorrect", "Info", MessageBoxButtons.OK);

        }
        private async Task DeletePaymentAsync()
        {
            if (clientBillsTable.SelectedRows.Count == 0)
            {
                MessageBox.Show("No Payment Bill selected", "Info", MessageBoxButtons.OK);
                return;
            }

            var response = await _clientService.DeletePaymentBillAsync(Convert.ToInt32(clientBillsTable.SelectedRows[0].Cells[0].Value));
            MessageBox.Show(response.IsSuccessStatusCode ? "Payment Bill was successfully deleted" : "Payment Bill doesn't exist", "Info", MessageBoxButtons.OK);
        }

        private async Task FilterData(string columnName)
        {
            var selectedClientName = clientDropDown.SelectedItem.ToString();
            var clientBillsFiltered = await _clientService.OrderClientBillsAsync(columnName, selectedClientName);
            clientBillsTable.DataSource = clientBillsFiltered;
        }

        private void btnToClientsForm_Click(object sender, EventArgs e)
        {
            if (_clientsForm == null || _clientsForm.IsDisposed)
            {
                _clientsForm = new Clients_Form();
                _clientsForm.FormClosed += (s, args) => _clientsForm = null;
                _clientsForm.Show();
            }
            else
            {
                _clientsForm.BringToFront();
            }

        }

        private void btnToServiceForm_Click(object sender, EventArgs e)
        {
            if (_companyServiceForm == null || _companyServiceForm.IsDisposed)
            {
                _companyServiceForm = new CompanyService_Form();
                _companyServiceForm.FormClosed += (s, args) => _companyServiceForm = null;
                _companyServiceForm.Show();
            }

        }

        private async void getServiceDropDownBtn_Click(object sender, EventArgs e)
        {
            DropDownLoadingMode(serviceDropDown);
            await LoadServicesAsync();
            DropDownLoaded(serviceDropDown);
        }

        private async void getClientDropDownBtn_Click(object sender, EventArgs e)
        {
            DropDownLoadingMode(clientDropDown);
            await LoadClientsAsync();
            DropDownLoaded(clientDropDown);
        }
    }
}

