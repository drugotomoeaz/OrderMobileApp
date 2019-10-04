using OrderMobileApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace OrderMobileApp.Services
{
    public static class DataTransformer
    {
        private static char _splitSymbol = ',';
        public static IDataBase Database => DependencyService.Get<IDataBase>() ?? new SQLiteDataBase();

        public static void SaveItemsToDb(string data)
        {
            using (var reader = new StreamReader(data))
            {
                var counter = 0;

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (counter > 0)
                    {
                        var values = line.Split(_splitSymbol);

                        Database.AddItemAsync(new Item
                        {
                            ItemId = values[0],
                            Name = values[1],
                            Measure = values[2]
                        });
                    }
                    counter++;
                }
            }
        }

        public static void SaveClientsToDB(string data)
        {
            using (var reader = new StreamReader(data))
            {
                var counter = 0;

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (counter > 0)
                    {
                        var values = line.Split(_splitSymbol);

                        Database.AddClientAsync(new Client
                        {
                            NameBG = values[0],
                            NameEN = values[1],
                            Address = values[2],
                            Town = values[3],
                            Email = values[4],
                            PhoneNumber = values[5],
                            Bulstat = Int32.Parse(values[6]),
                        });
                    }
                    counter++;
                }
            }
        }

        public static void ToTxt(Order[] order) { }
    }
}
