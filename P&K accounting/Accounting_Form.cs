using P_K_accounting.Models; 
using System.Text;
using P_K_accounting.Service;
using NewtonJson=Newtonsoft.Json;
using Json= System.Text.Json;


namespace P_K_accounting
{
    public partial class Accounting_Form : Form
    {
        private readonly HttpService _httpService;
        public Accounting_Form()
        {
            InitializeComponent();
            _httpService = new HttpService();
        }

        private async void Accounting_Form_Load(object sender, EventArgs e)
        {
            if (clientDropDown.Items.Count == 0)
            {
                clientDropDown.Enabled = false;
            }

            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage getClientsResponse = await _httpService.GetClientList($"http://localhost:5239/clients");
                if (getClientsResponse.IsSuccessStatusCode)
                {
                    string responseContent = await getClientsResponse.Content.ReadAsStringAsync();
                    var clients = Json.JsonSerializer.Deserialize<List<string>>(responseContent);
                    clientDropDown.Items.Clear();
                    clientDropDown.Enabled = true;
                    foreach (var client in clients)
                    {
                        clientDropDown.Items.Add(client);
                    }
                }

            }
        }

        private async void clientDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedClientName = clientDropDown.SelectedItem.ToString();

            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage getClientBills = await _httpService.GetClientPayments($"http://localhost:5239/paymentbill/{selectedClientName}");
                if (getClientBills.IsSuccessStatusCode)
                {
                    string responseContent = await getClientBills.Content.ReadAsStringAsync();
                    var clientBills = Json.JsonSerializer.Deserialize<IEnumerable<PaymentBillAccountantViewModel>>(responseContent);
                    clientBillsTable.DataSource = clientBills;
                }
                else
                {
                    MessageBox.Show("Client doesnt have any bill", "Info", MessageBoxButtons.OK);
                }
            }
        }

        private void addingPanel_Click(object sender, EventArgs e)
        {
            Point location = new Point(12, 75);
            AddPanel.Visible = true;
            UpdatePanel.Visible = false;
            AddPanel.Location = location;
        }

        private void updatingPanel_Click(object sender, EventArgs e)
        {
            Point location = new Point(12, 75);
            AddPanel.Visible = false;
            UpdatePanel.Visible = true;
            UpdatePanel.Location = location;
        }

        private async void addBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(clientDropDown.SelectedItem.ToString()))
            {
                string currentClient = clientDropDown.SelectedItem.ToString();
                PaymentBillAccountantViewModel pbvm = new PaymentBillAccountantViewModel();
                pbvm.ServiceName = ServiceNameText.Text;
                pbvm.Amount = Convert.ToDecimal(AmountText.Text);
                pbvm.IssueDate = issueDateTimePicker.Value;
                pbvm.DueToDate = duetoDateTimePicker.Value;
                string json = Json.JsonSerializer.Serialize(pbvm);

                using (HttpClient httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await _httpService.AddPayment($"http://localhost:5239/paymentbill/{currentClient}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Payment Bill successfully added");
                    }
                    else
                    {
                        MessageBox.Show("Entered data is incorrect", "Error", MessageBoxButtons.OKCancel);
                    }
                }
            }
            else
            {
                MessageBox.Show("Choose client from dropdown first", "Info", MessageBoxButtons.OK);
            }

        }

        private void clientBillsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                int rowIndex = e.RowIndex;
                DataGridViewRow row = clientBillsTable.Rows[rowIndex];
                IdUpdateText.Text = row.Cells[0].Value.ToString();
                ServiceNameUpdateText.Text = row.Cells[1].Value.ToString();
                AmountUpdateText.Text = row.Cells[2].Value.ToString();
                updateIssueDateTimePicker.Value = DateTime.Parse(row.Cells[3].Value.ToString());
                updateDueToDateTimPicker.Value = DateTime.Parse(row.Cells[4].Value.ToString());
            }
        }

        private async void updateBtn_Click(object sender, EventArgs e)
        {
            string currentClient = clientDropDown.SelectedItem.ToString();
            PaymentBillAccountantViewModel pbvm = new PaymentBillAccountantViewModel();
            int id = Convert.ToInt32(IdUpdateText.Text);
            pbvm.ServiceName = ServiceNameUpdateText.Text;
            pbvm.Amount = Convert.ToDecimal(AmountUpdateText.Text);
            pbvm.IssueDate = updateIssueDateTimePicker.Value;
            pbvm.DueToDate = updateDueToDateTimPicker.Value;
            string json = Json.JsonSerializer.Serialize(pbvm);

            using (HttpClient httpClient = new HttpClient())
            {
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage updatePaymentBillResponse = await _httpService.UpdateClientById($"http://localhost:5239/paymentbill/{id}", content);
                if (updatePaymentBillResponse.IsSuccessStatusCode)
                {
                    MessageBox.Show("Payment info was updated successfully", "Info", MessageBoxButtons.OKCancel);
                }
                else
                {
                    MessageBox.Show("Entered data is incorrect", "Error", MessageBoxButtons.OKCancel);
                }
            }
        }

        private void clientBillsTable_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = clientBillsTable.Rows[e.RowIndex];
            var dueDateCell = row.Cells[4];
            var paymentDateCell = row.Cells[5];

            if (paymentDateCell.Value != null)
            {
                DateTime dueToDate;
                DateTime paymentDate;

                if (DateTime.TryParse(dueDateCell.Value.ToString(), out dueToDate) &&
                    DateTime.TryParse(paymentDateCell.Value.ToString(), out paymentDate))
                {
                    if (paymentDate > dueToDate)
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 87, 87);
                    }
                }
            }
        }

        private void clientBillsTable_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                int columnIndex = e.ColumnIndex;
                DataGridViewColumn clickedColumn = clientBillsTable.Columns[columnIndex];
                string columnName = clickedColumn.DataPropertyName;
                FilterData(columnName);
            }
        }

        private async void FilterData(string columnName)
        {
            string user = clientDropDown.SelectedItem.ToString();
            var json = NewtonJson.JsonConvert.SerializeObject(user);
            using (HttpClient httpClient = new HttpClient())
            {
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage clientBillsOrderResponse = await httpClient.PostAsync($"http://localhost:5239/orderby/{columnName}", content);
                if (clientBillsOrderResponse.IsSuccessStatusCode)
                {
                    string responseContent = await clientBillsOrderResponse.Content.ReadAsStringAsync();
                    var clientBills = Json.JsonSerializer.Deserialize<IEnumerable<PaymentBillAccountantViewModel>>(responseContent);
                    clientBillsTable.DataSource = clientBills;
                }
            }
        }

        private async void deleteBillBtn_Click(object sender, EventArgs e)
        {
            if (clientBillsTable.SelectedRows.Count > 0)
            {
                var idToDelete = clientBillsTable.SelectedRows[0].Cells[0].Value;
                using (HttpClient httpClient=new HttpClient())
                {
                    HttpResponseMessage paymentBillDeleteResponse = await _httpService.DeletePaymentBill($"http://localhost:5239/paymentbill/{idToDelete}");
                    if (paymentBillDeleteResponse.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Payment Bill was successfully deleted", "Info", MessageBoxButtons.OKCancel);
                    }
                    else
                    {
                        MessageBox.Show("Payment Bill doesnt exist", "Info", MessageBoxButtons.OKCancel);
                    }
                }
                
            }
        }
    }
}

