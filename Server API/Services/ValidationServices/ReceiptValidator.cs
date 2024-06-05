using FluentValidation;
using System.Text.RegularExpressions;

namespace Server_API.Services.ValidationServices
{
    public class ReceiptValidator:AbstractValidator<string>
    {
        public ReceiptValidator()
        {
            RuleFor(receipt => receipt)
                .Cascade(CascadeMode.Stop)
                .Must(isValidReceiptFormat).WithMessage("Receipt is invalid")
                .Must(isValidReceiptNumber).WithMessage("Receipt should be in range of 0 to 99999");
            
        }

        private bool isValidReceiptNumber(string receiptNumber)
        {
            return Convert.ToInt32(receiptNumber) > 0 && Convert.ToInt32(receiptNumber) < 99999;
        }

        private bool isValidReceiptFormat(string receipt)
        {
            return Regex.IsMatch(receipt, "^[0-9]+$");
        }
    }
}
