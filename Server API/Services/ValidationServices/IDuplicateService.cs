namespace Server_API.Services.ValidationServices
{
    public interface IDuplicateService
    {
        public bool LoginExist(string login);
        public bool PhoneNumberExist(string phone);
        public bool EmailExist(string email);
        public bool ServiceNameExist(string servicename);
    }
}
