using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderMobileApp.Services
{
    public interface IClientDbOperator<Client>
    {
        Task<bool> AddClientAsync(Client client);
        Task<bool> InsertClientsAsync(Client[] item);
        Task<Client> GetClientAsync(int id);
        Task<IEnumerable<Client>> GetClientsAsync(bool forceRefresh = false);
    }
}
