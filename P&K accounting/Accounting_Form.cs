using P_K_accounting.Models; 
using P_K_accounting.Service;

namespace P_K_accounting
{
    public partial class Accounting_Form : Form
    {
        private readonly ClientService _clientService;
        public Accounting_Form()
        {
            InitializeComponent();
            _clientService = new ClientService(new HttpService());
        }

        private async void Accounting_Form_Load(object sender, EventArgs e)
        {
            await LoadClientsAsync();           
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

        private void addingPanel_Click(object sender, EventArgs e)
        {
            TogglePanels(AddPanel, UpdatePanel);
        }

        private void updatingPanel_Click(object sender, EventArgs e)
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
            IdUpdateText.Text = row.Cells[0].Value.ToString();
            ServiceNameUpdateText.Text = row.Cells[1].Value.ToString();
            AmountUpdateText.Text = row.Cells[2].Value.ToString();
            updateIssueDateTimePicker.Value = DateTime.Parse(row.Cells[3].Value.ToString());
            updateDueToDateTimPicker.Value = DateTime.Parse(row.Cells[4].Value.ToString());
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
            clientDropDown.Enabled = false;
            var clients = await _clientService.GetClientListAsync();
            clientDropDown.Items.Clear();           
            foreach (var client in clients)
            {
                clientDropDown.Items.Add(client);    
            }

            clientDropDown.Enabled = clients.Any();
        }

        private async Task LoadClientBillsAsync()
        {
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
                ServiceName = ServiceNameText.Text,
                Amount = Convert.ToDecimal(AmountText.Text),
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
                ServiceName = ServiceNameUpdateText.Text,
                Amount = Convert.ToDecimal(AmountUpdateText.Text),
                IssueDate = updateIssueDateTimePicker.Value,
                DueToDate = updateDueToDateTimPicker.Value
            };

            var response = await _clientService.UpdateClientByIdAsync(Convert.ToInt32(IdUpdateText.Text), pbvm);
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
  
    }
}

