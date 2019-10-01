using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using OrderMobileApp.Services;
using SQLite;
using SQLiteTraining.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Droid))]
namespace SQLiteTraining.Droid
{
    public class SQLite_Droid : ISQLite
    {
        public SQLite_Droid()
        {
        }

        #region ISQLite implementation

        public SQLiteConnection GetConnection()
        {
            var fileName = "RandomThought.db3";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, fileName);

            var connection = new SQLiteConnection(path);

            return connection;
        }

        #endregion
    }
}