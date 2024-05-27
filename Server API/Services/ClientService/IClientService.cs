using Server_API.Models.Entity;

namespace Server_API.Services.ClientService
{
    public interface IClientService
    {
        public void AddClient(Client client);
        public List<Client> GetAllClients();
        public bool UpdateClientById(int id, Client client);
        public bool DeleteClientById(int id);
    }
}
