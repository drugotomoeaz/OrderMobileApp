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
                        var values = line.Split(';');

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

        public static void SaveClientsToDB(string data) { }

        public static void ToTxt(Order[] order) { }
    }
}
