using OrderMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderMobileApp.Services
{
    public interface IDataBase: IDataStore<Item>, IClientDbOperations<Client>
    {
    }
}
