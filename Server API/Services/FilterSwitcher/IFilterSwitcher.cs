using Server_API.Models.WinFormsModels;

namespace Server_API.Services.FilterSwitcher
{
    public interface IFilterSwitcher
    {
        public List<PaymentBillAccountantViewModel> SwitchColumnParameter(string username, string columnName);
    }
}
