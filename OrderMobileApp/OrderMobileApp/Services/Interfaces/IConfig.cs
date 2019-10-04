using System;
using System.Collections.Generic;
using System.Text;

namespace OrderMobileApp.Services
{
    public interface IConfig: IDistributor
    {
        AddressBook GetAddressBook();
        string GetDirectory();
    }
}
