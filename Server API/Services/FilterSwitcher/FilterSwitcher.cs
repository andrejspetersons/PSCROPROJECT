using Server_API.Models.WinFormsModels;
using Server_API.Services.FilterService;

namespace Server_API.Services.FilterSwitcher
{
    public class FilterSwitcher:IFilterSwitcher
    {
        private readonly IFilterService _filterService;
        public FilterSwitcher(IFilterService filterService)
        {
            _filterService = filterService;
        }
        public List<PaymentBillAccountantViewModel> SwitchColumnParameter(string columnName, string username)
        {
            var result = new List<PaymentBillAccountantViewModel>();
            switch (columnName.ToLower())
            {
                case "paymentbillid":
                    result = _filterService.OrderByPaymentBillId(username);
                    break;
                case "servicename":
                    result = _filterService.OrderByServiceName(username);
                    break;
                case "amount":
                    result = _filterService.OrderByAmount(username);
                    break;
                case "issuedate":
                    result = _filterService.OrderByIssueDate(username);
                    break;
                case "duetodate":
                    result = _filterService.OrderByIssueDate(username);
                    break;
                case "paymentdate":
                    result = _filterService.OrderByPaymentDate(username);
                    break;
                case "paymentstatus":
                    result = _filterService.OrderByPaymentStatus(username);
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}