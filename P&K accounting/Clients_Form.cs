using P_K_accounting.Models;
using P_K_accounting.Service;
using System.Net;

namespace P_K_accounting
{
    public partial class Clients_Form : Form
    {
        private readonly ClientService _clientService;
        public Clients_Form()
        {
            _clientService = new ClientService(new HttpService_Clients());
            InitializeComponent();
        }

        private async void Clients_Form_Load(object sender, EventArgs e)
        {
            await LoadAllClients();    
        }

        private async void addBtn_Click(object sender, EventArgs e)
        {
            await AddClient();
        }

        private async void updateBtn_Click(object sender, EventArgs e)
        {
            ClientAccountantViewModel cvm = new ClientAccountantViewModel();
            int idToUpdate = Convert.ToInt32(clientIdUpdateText.Text);
            cvm.FirstName = clientFirstNameUpdateText.Text;
            cvm.LastName = clientLastNameUpdateText.Text;
            cvm.Phone = clientPhoneUpdateText.Text;
            cvm.Email = clientEmailUpdateText.Text;
            HttpResponseMessage responseMessage = await _clientService.UpdateClientAsync(idToUpdate, cvm);
            MessageBox.Show(responseMessage.IsSuccessStatusCode ? "Client was successfully updated" :
                (responseMessage.StatusCode == HttpStatusCode.BadRequest ? "Entered data is invalid" : "Client doesn't exist"), "Info", MessageBoxButtons.OK);
        }

        private async void deleteClientButton_Click(object sender, EventArgs e)
        {
            if (clientsTable.SelectedRows.Count == 0)
            {
                MessageBox.Show("No Client selected", "Info", MessageBoxButtons.OK);
                return;
            }
            var idDelete = Convert.ToInt32(clientsTable.SelectedRows[0].Cells[0].Value);
            var responseMessage = await _clientService.DeleteClientAsync(idDelete);
            MessageBox.Show(responseMessage.IsSuccessStatusCode ? "Client was successfully deleted" : "Client doesn't exist", "Info", MessageBoxButtons.OK);
        }

        private async void getClientsBtn_Click(object sender, EventArgs e)
        {
            await LoadAllClients();
        }

        private void clientsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PopulateFields(e.RowIndex);
        }

        private void addClientPanel_Click(object sender, EventArgs e)
        {
            TogglePanel(addingPanel, updatingPanel);
        }

        private void updateClientPanel_Click(object sender, EventArgs e)
        {
            TogglePanel(updatingPanel, addingPanel);
        }

        private void PopulateFields(int index)
        {
            if (index == -1) return;
            var row = clientsTable.Rows[index];
            clientIdUpdateText.Text = row.Cells[0].Value.ToString();
            clientFirstNameUpdateText.Text = row.Cells[1].Value.ToString();
            clientLastNameUpdateText.Text = row.Cells[2].Value.ToString();
            clientPhoneUpdateText.Text = row.Cells[3].Value.ToString();
            clientEmailUpdateText.Text = row.Cells[4].Value.ToString();
        }

        private void TogglePanel(Panel showPanel, Panel hidePanel)
        {
            showPanel.Visible = true;
            hidePanel.Visible = false;
            showPanel.Location = new Point(12, 75);
        }

        private async Task AddClient()
        {
            ClientAddViewModel cavm = new ClientAddViewModel();
            cavm.Login = loginText.Text;
            cavm.FirstName = clientFirstNameText.Text;
            cavm.LastName = clientLastNameText.Text;
            cavm.Phone = clientPhoneText.Text;
            cavm.Email = clientEmailText.Text;

            HttpResponseMessage responseMessage = await _clientService.AddClientAsync(cavm);
            switch (responseMessage.StatusCode)
            {
                case HttpStatusCode.OK:
                    MessageBox.Show("Client was added successfully", "Info", MessageBoxButtons.OK);
                    break;
                case HttpStatusCode.Conflict:
                    MessageBox.Show("Client with login already exist", "Error", MessageBoxButtons.OK);
                    break;
                case HttpStatusCode.BadRequest:
                    MessageBox.Show("Entered data is incorrect", "Warn", MessageBoxButtons.OK);
                    break;
                default:
                    MessageBox.Show("Unhandled error appears", "Error", MessageBoxButtons.OKCancel);
                    break;
            }

            
        }

        private async Task LoadAllClients()
        {
            var clients = await _clientService.ClientCredentialsLoadAsync();
            clientsTable.DataSource = clients;
        }

    }
}
