using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderMobileApp.Services
{
    public interface IDistributorDbOperator<Distributor>
    {
        Task<bool> AddDistributorAsync(Distributor distributor);
        Task<Distributor> GetDistributorAsync(int id);
    }
}
