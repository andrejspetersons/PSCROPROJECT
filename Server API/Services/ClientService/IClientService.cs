using Server_API.Models.Entity;

namespace Server_API.Services.ClientService
{
    public interface IClientService
    {
        public Client AddClient(Client client);
        public List<Client> GetAllClients();
        public Client UpdateClientById(int id, Client client);
        public bool DeleteClientById(int id);
    }
}
