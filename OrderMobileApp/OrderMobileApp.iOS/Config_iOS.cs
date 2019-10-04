using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using Newtonsoft.Json;
using OrderMobileApp.iOS;
using OrderMobileApp.Services;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(Config_iOS))]

namespace OrderMobileApp.iOS
{
    public class Config_iOS : IConfig
    {
        public int DistributorId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string GetDirectory()
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            return Path.Combine(documents, "..", "Library");
        }

        public Services.AddressBook GetAddressBook()
        {
            var path = Path.Combine(NSBundle.MainBundle.BundlePath,"Config.json");
            using(var stream = File.Open(path, FileMode.Open))
            {
                using(var reader = new StreamReader(stream))
                {
                    var config = reader.ReadToEnd().ToString();
                    return JsonConvert.DeserializeObject<Services.AddressBook>(config);
                }
            }
        }
    }
}