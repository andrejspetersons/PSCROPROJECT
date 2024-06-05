using FluentValidation;
using System.Text.RegularExpressions;

namespace Server_API.Services.ValidationServices
{
    public class CompanyServiceValidator : AbstractValidator<string>
    {
        private readonly IDuplicateService _duplicateService;
        public CompanyServiceValidator(IDuplicateService duplicateService)
        {
            _duplicateService = duplicateService;
            RuleFor(name => name)
                .NotEmpty().WithMessage("Service name is empty")
                .Must(isValidServiceName).WithMessage("Service name should contain only alphabet letters");

            RuleSet("CheckDuplicates", () =>
            {
                RuleFor(name => name)
                    .Must(isServiceNameUniq).WithMessage("Service Name {PropertyValue} already exist");
            });
            _duplicateService = duplicateService;
        }

        private bool isServiceNameUniq(string servicename)
        {
            return _duplicateService.ServiceNameExist(servicename) == false;
        }

        private bool isValidServiceName(string name)
        {
            return Regex.IsMatch(name, @"^[a-zA-Z]+$");
        }

    }
}

        
    


