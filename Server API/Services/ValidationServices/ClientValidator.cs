using FluentValidation;
using Server_API.Context;
using Server_API.Models.Entity;
using System.Text.RegularExpressions;

namespace Server_API.Services.ValidationServices
{
    public class ClientValidator:AbstractValidator<Client>
    {
        private readonly IDuplicateService _duplicateService;
        public ClientValidator(IDuplicateService duplicateService)
        {
            _duplicateService = duplicateService;
        
            RuleFor(client => client.FirstName)
                .Length(2,50).WithMessage("Name length should be in range of {MinLength} to {MaxLength} symbols.\nYour name contains {TotalLength} symbols")
                .Must(isValidName).WithMessage("The name should only contain alphabet letters:\nYou enter {PropertyValue}");
            RuleFor(client => client.LastName)
                .Length(1,50).WithMessage("Surname length should be in range of {MinLength} to {MaxLength} symbols.\nYour surname contains {TotalLength} symbols")
                .Must(isValidSurname).WithMessage("The name should only contain alphabet letters:\nYou enter {PropertyValue}"); ;
            RuleFor(client => client.Phone)
                .Length(7,15).WithMessage("Phone length should be in range of {MinLength} to {MaxLength} symbols.\nYour phone contains {TotalLength} symbols")
                .Must(isValidPhone).WithMessage("Phone should have following format:+3712222222 or 2222222.\nYou enter {PropertyValue}");
            RuleFor(client => client.Email)
                .Must(isValidEmail).WithMessage("Invalid email format,should be XXXX@XXXX.XXXX contain letters,digits and special signs %\\-$_.\nYou enter {PropertyValue}");

            RuleSet("CheckDuplicates", () =>
            {
                RuleFor(client => client.Login)
                    .Must(isLoginUnique).WithMessage("Login {PropertyValue} already exist");
                RuleFor(client => client.Phone)
                    .Must(isPhoneUnique).WithMessage("Phone {PropertyValue} already exist");
                RuleFor(client => client.Email)
                    .Must(isEmailUnique).WithMessage("Email {PropertyValue} already exist");
            });


        }

        private bool isPhoneUnique(string phone)
        {
            return _duplicateService.PhoneNumberExist(phone) == false;
        }

        private bool isEmailUnique(string email)
        {
            return _duplicateService.EmailExist(email) == false;
        }

        private bool isLoginUnique(string login)
        {
            return _duplicateService.LoginExist(login) == false;
        }

        private bool isValidName(string name)
        {
            return Regex.IsMatch(name, @"^[a-zA-Z]+$");
        }

        private bool isValidSurname(string name)
        {
            return Regex.IsMatch(name, @"^[a-zA-Z]+$");
        }

        private bool isValidPhone(string phone)
        {
            return Regex.IsMatch(phone, @"^\+?\d+$");
        }

        private bool isValidEmail(string email)
        {
            return Regex.IsMatch(email, @"[a-zA-Z0-9%\-$_]+@\b[a-zA-Z0-9%\-$_]+\.\b[a-zA-Z0-9%\-$_]{2,}$");
        }
    }
}
