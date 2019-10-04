using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using OrderMobileApp.Models;
using OrderMobileApp.Views;
using System.Linq;
using Xamarin.Forms.Internals;
using System.Windows.Input;
using System.Collections.Generic;
using OrderMobileApp.Services;

namespace OrderMobileApp.ViewModels
{
    public class OrderViewModel : BaseViewModel
    {
        public List<Client> Clients { get; set; }
        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public OrderViewModel()
        {
            Title = "New order";
            Clients =  DataStore.GetClientsAsync().Result.ToList();

            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Item;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });

            MessagingCenter.Subscribe<ItemsPage, Item>(this, "QuantityChanged", async (obj, item) =>
            {
                var newItem = item as Item;
                await DataStore.UpdateItemAsync(newItem);
                LoadItemsCommand.Execute(null);
            });

            MessagingCenter.Subscribe<ItemsPage, Item>(this, "DeleteItem", async (obj, item) =>
            {
                var newItem = item as Item;
                await DataStore.DeleteItemAsync(newItem.Id);
                LoadItemsCommand.Execute(null);
            });

            MessagingCenter.Subscribe<LogInPage, Distributor>(this, "LogIn", async (obj, dist) =>
            {
                var newDistibutor = dist as Distributor;
                await DataStore.AddDistributorAsync(newDistibutor);
                DataTransformer.SaveClientsToDB(DataRequester.MakeRequest(RequestTo.GetClients, newDistibutor.DistributorId.ToString()));
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}