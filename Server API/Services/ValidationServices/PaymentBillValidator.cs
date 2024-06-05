using FluentValidation;
using Server_API.Models.WinFormsModels;

namespace Server_API.Services.ValidationServices
{
    public class PaymentBillValidator:AbstractValidator<PaymentBillAccountantViewModel>
    {
        public PaymentBillValidator()
        {
            RuleFor(bill => bill.ServiceName).NotEmpty().WithMessage("Service Name can't be empty");
            RuleFor(bill => bill.Amount).GreaterThan(0).WithMessage("Amount must be positive");
            RuleFor(bill => bill.IssueDate).LessThan(bill => bill.DueToDate).WithMessage("Issue Date must occured before the Due Date");
        }
    }
}
