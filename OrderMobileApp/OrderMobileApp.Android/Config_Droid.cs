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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OrderMobileApp.Droid;
using OrderMobileApp.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(Config_Droid))]
namespace OrderMobileApp.Droid
{
    public class Config_Droid : IConfig
    {
        public int DistributorId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public AddressBook GetAddressBook()
        {
            using (var readStream = Forms.Context.Assets.Open($"Resources/Config.json"))
            {
                using(var reader = new StreamReader(readStream))
                {
                    var config = reader.ReadToEnd().ToString();
                    return JsonConvert.DeserializeObject<AddressBook>(config);
                }
            }
        }

        //public bool SaveDistributorId(int distId)
        //{
        //    using (var readStream = Forms.Context.Assets.Open($"Resources/Config.json"))
        //    {
        //        using (var reader = new StreamReader(readStream))
        //        {
        //            var config = reader.ReadToEnd().ToString();

        //            reader.
        //        }
        //    }
        //}

        public string GetDirectory()
        {
            var documents = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return documents;
        }
    }
}