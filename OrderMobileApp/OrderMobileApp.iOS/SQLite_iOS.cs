using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using OrderMobileApp.iOS;
using OrderMobileApp.Services;
using SQLite;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_iOS))]

namespace OrderMobileApp.iOS
{
    public class SQLite_iOS : ISQLite
    {
        public SQLite_iOS()
        {
        }

        #region ISQLite implementation

        public SQLiteConnection GetConnection()
        {
            var fileName = "OrderMobileApp.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, fileName);

            var connection = new SQLiteConnection(path);

            return connection;
        }

        #endregion
    }
}