using FluentValidation;
using Server_API.Models.Entity;
using System.Text.RegularExpressions;

namespace Server_API.Services.ValidationServices
{
    public class ClientValidator:AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(client => client.FirstName)
                .MaximumLength(50)
                .Must(isValidName);
            RuleFor(client => client.LastName)
                .MaximumLength(50)
                .Must(isValidSurname);
            RuleFor(client => client.Phone)
                .MinimumLength(7)
                .MaximumLength(15)
                .Must(isValidPhone);
            RuleFor(client => client.Email)
                .Must(isValidEmail);
            
        }
        private bool isValidName(string name)
        {
            //return Regex.IsMatch(name, @"^[^\\d\\W]+$");
            return Regex.IsMatch(name, @"^[a-zA-Z]+$");
        }

        private bool isValidSurname(string name)
        {
            //return Regex.IsMatch(name, @"^[^\\d\\W]+$");
            return Regex.IsMatch(name, @"^[a-zA-Z]+$");
        }

        private bool isValidPhone(string phone)
        {
            return Regex.IsMatch(phone, @"^\+?\d +$");
        }

        private bool isValidEmail(string email)
        {
            return Regex.IsMatch(email, @"\b[a-zA-Z0-9]+@\b(?:gmail\.com|@yahoo\.com|outlook\.com)\b");
        }
    }
}
