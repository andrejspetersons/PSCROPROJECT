using FluentValidation;
using System.Text.RegularExpressions;

namespace Server_API.Services.ValidationServices
{
    public class CompanyServiceValidator:AbstractValidator<string>
    {
        public CompanyServiceValidator()
        {
            RuleFor(name=>name)
                .Must(isValidServiceName);
        }

        private bool isValidServiceName(string name)
        {
            return Regex.IsMatch(name, @"^[a-zA-Z]+$");
        }
    }
}
