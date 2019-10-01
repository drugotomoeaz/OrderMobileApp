using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderMobileApp.Services
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
