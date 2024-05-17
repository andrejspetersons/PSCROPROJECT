using FluentValidation;
using Server_API.Models.Entity;

namespace Server_API.Services.ValidationServices
{
    public class ReceiptValidator:AbstractValidator<int>
    {
        public ReceiptValidator()
        {
            RuleFor(x => x)
                .Must(isValidReceiptNumber)
                .GreaterThan(0)
                .LessThan(99999);             
        }

        private bool isValidReceiptNumber(int receiptNumber)
        {
            return receiptNumber > 0 && receiptNumber < 99999;
        }
    }
}
