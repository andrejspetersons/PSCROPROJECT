using System.Collections.Generic;
using System.Linq;


public class UIHelper
{
    public IEnumerable<PaymentBillUserViewModel> SortData(IEnumerable<PaymentBillUserViewModel> data,string expression,string direction)
    {
        switch (expression.ToLower())
        {
            case "servicename":
                data = direction == "ASC"
                    ? data.OrderBy(item => item.ServiceName)
                    : data.OrderByDescending(item => item.ServiceName);
                break;
            case "amount":
                data = direction == "ASC"
                    ? data.OrderBy(item => item.Amount)
                    : data.OrderByDescending(item => item.Amount);
                break;
            case "issuedate":
                data = direction == "ASC"
                    ? data.OrderBy(item => item.IssueDate)
                    : data.OrderByDescending(item => item.IssueDate);
                break;
            case "duetodate":
                data = direction == "ASC"
                    ? data.OrderBy(item => item.DueToDate)
                    : data.OrderByDescending(item => item.DueToDate);
                break;
            case "paymentdate":
                data = direction == "ASC"
                    ? data.OrderBy(item => item.PaymentDate)
                    : data.OrderByDescending(item => item.PaymentDate);
                break;
            case "paymentstatus":
                data = direction == "ASC"
                    ? data.OrderBy(item => item.PaymentStatus)
                    : data.OrderByDescending(item => item.PaymentStatus);
                break;
            default:
                break;
        }

        return data;
    }

}