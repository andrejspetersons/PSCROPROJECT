using Server_API.Context;
using Server_API.Models.Entity;

namespace Server_API.Services.ClientService
{
    public class ClientService : IClientService
    {
        private readonly PSICRODbContext _context;

        public ClientService(PSICRODbContext context)
        {
            _context = context;
        }

        public Client AddClient(Client client)
        {
            _context.Add(client);
            _context.SaveChanges();
            return client;
        }

        public Client UpdateClientById(int id,Client updatedClient)
        {
            var client = _context.Clients.FirstOrDefault(client => client.Id == id);
            if (client == null)
            {
                return null;
            }
            else
            {
                client.FirstName = updatedClient.FirstName;
                client.LastName = updatedClient.LastName;
                client.Phone = updatedClient.Phone;
                client.Email = updatedClient.Email;
                _context.SaveChanges();
                return client;
            }
        }

        public bool DeleteClientById(int id)
        {
            var client = _context.Clients.FirstOrDefault(client => client.Id == id);
            if (client == null)
            {
                return false;
            }
            else
            {
                _context.Remove(client);
                _context.SaveChanges();
                return true;
            }
        }

        public List<Client> GetAllClients()
        {
            return _context.Clients.ToList();
        }

    }
}
