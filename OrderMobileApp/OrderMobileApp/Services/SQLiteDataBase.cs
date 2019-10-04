using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderMobileApp.Models;
using SQLite;
using Xamarin.Forms;

namespace OrderMobileApp.Services
{
    public class SQLiteDataBase : IDataBase
    {
        private SQLiteConnection _connection;

        public SQLiteDataBase()
        {
            //Creates connection to the DB and creates the table with items
            _connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection.CreateTable<Item>();
            _connection.CreateTable<Client>();
            _connection.CreateTable<Distributor>();

        }

        public async Task<bool> AddItemAsync(Item item)
        {
            _connection.Insert(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            _connection.Update(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            _connection.Delete<Item>(id);
            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(int id)
        {
            return await Task.FromResult(_connection.Get<Item>(id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult((from t in _connection.Table<Item>()
                                          select t).ToList());
        }

        public async Task<bool> InsertClientsAsync(Client[] clients)
        {
            _connection.InsertAll(clients);
            return await Task.FromResult(true);
        }

        public async Task<Client> GetClientAsync(int id)
        {
            return await Task.FromResult(_connection.Get<Client>(id));
        }

        public async Task<IEnumerable<Client>> GetClientsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult((from t in _connection.Table<Client>()
                                          select t).ToList());
        }

        public async Task<bool> AddClientAsync(Client client)
        {
            _connection.Insert(client);
            return await Task.FromResult(true);
        }

        public async Task<bool> AddDistributorAsync(Distributor distributor)
        {
            _connection.InsertOrReplace(distributor);
            return await Task.FromResult(true);
        }

        public async Task<Distributor> GetDistributorAsync(int id = 0)
        {
            return await Task.FromResult(_connection.Get<Distributor>(id));
        }
    }
}