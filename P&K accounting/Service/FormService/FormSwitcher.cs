namespace P_K_accounting.Service.FormService
{
    public class FormSwitcher
    {
        private Form _clientsForm;
        private Form _companyServiceForm;

        public void ShowClientsForm()
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

        public void ShowCompanyServiceForm()
        {
            if (_companyServiceForm == null || _companyServiceForm.IsDisposed)
            {
                _companyServiceForm = new CompanyService_Form();
                _companyServiceForm.FormClosed += (s, args) => _companyServiceForm = null;
                _companyServiceForm.Show();
            }
            else
            {
                _companyServiceForm.BringToFront();
            }
        }
    }
}
