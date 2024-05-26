using FluentValidation;
using Server_API.Models.WinFormsModels;

namespace Server_API.Services.ValidationServices
{
    public class PaymentBillValidator:AbstractValidator<PaymentBillAccountantViewModel>
    {
        public PaymentBillValidator()
        {
            RuleFor(bill => bill.ServiceName).NotEmpty();
            RuleFor(bill => bill.Amount).GreaterThan(0);
            RuleFor(bill => bill.IssueDate).LessThan(bill => bill.DueToDate);
            RuleFor(bill => bill.DueToDate).GreaterThan(bill => bill.IssueDate);
        }
    }
}
