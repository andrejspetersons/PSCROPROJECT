using P_K_accounting.Models;
using P_K_accounting.Service.EntityService;
using P_K_accounting.Service.GridViewServices;
using P_K_accounting.Service.HttpServices;
using P_K_accounting.Service.UIServices;
using System.Net;

namespace P_K_accounting
{
    public partial class Clients_Form : Form
    {
        private readonly ClientService _clientService;
        private readonly UIHelper _helper;
        private readonly GridViewClientService _gridService;
        
        public Clients_Form()
        {
            _clientService = new ClientService(new HttpService_Clients());
            _helper = new UIHelper();
            _gridService = new GridViewClientService();
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
            await UpdateClient();
        }

        private async void deleteClientButton_Click(object sender, EventArgs e)
        {
            await DeleteClient();
        }

        private void clientsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PopulateFields(e.RowIndex);
        }

        private void addClientPanel_Click(object sender, EventArgs e)
        {
            _helper.TogglePanels(addingPanel, updatingPanel);
        }

        private void updateClientPanel_Click(object sender, EventArgs e)
        {
            _helper.TogglePanels(updatingPanel, addingPanel);
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

        private async Task AddClient()
        {
            ClientAddViewModel cavm = new ClientAddViewModel();
            cavm.Login = loginText.Text;
            cavm.FirstName = clientFirstNameText.Text;
            cavm.LastName = clientLastNameText.Text;
            cavm.Phone = clientPhoneText.Text;
            cavm.Email = clientEmailText.Text;

            HttpResponseMessage responseMessage = await _clientService.AddClientAsync(cavm);
            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                clientsTable.DataSource=await _gridService.AddRecordToGrid(responseMessage, clientsTable);
                clientsTable.Refresh();
            }

            await _helper.GetDialogByResponse(responseMessage);
        }

        private async Task UpdateClient()
        {
            ClientAccountantViewModel cvm = new ClientAccountantViewModel();
            int idToUpdate = Convert.ToInt32(clientIdUpdateText.Text);
            cvm.FirstName = clientFirstNameUpdateText.Text;
            cvm.LastName = clientLastNameUpdateText.Text;
            cvm.Phone = clientPhoneUpdateText.Text;
            cvm.Email = clientEmailUpdateText.Text;

            HttpResponseMessage responseMessage = await _clientService.UpdateClientAsync(idToUpdate, cvm);
            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                clientsTable.DataSource = await _gridService.UpgradeRecordInGrid(responseMessage, clientsTable);
                clientsTable.Refresh();
            }

            await _helper.GetDialogByResponse(responseMessage);
        }

        private async Task DeleteClient()
        {
            if (clientsTable.SelectedRows.Count == 0)
            {
                MessageBox.Show("No Client selected", "Info", MessageBoxButtons.OK);
                return;
            }

            var idDelete = Convert.ToInt32(clientsTable.SelectedRows[0].Cells[0].Value);
            var responseMessage = await _clientService.DeleteClientAsync(idDelete);
            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                clientsTable.DataSource = await _gridService.DeleteRecordFromGid(idDelete, clientsTable);
                clientsTable.Refresh();
            }

            await _helper.GetDialogByResponse(responseMessage);
        }

        private async Task LoadAllClients()
        {
            var clients = await _clientService.ClientCredentialsLoadAsync();
            clientsTable.DataSource = clients;
        }

    }
}
