using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using OrderMobileApp.Models;
using OrderMobileApp.Views;
using OrderMobileApp.ViewModels;
using System.Windows.Input;

namespace OrderMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }


        async void OnItemTapped(object sender, ItemTappedEventArgs args)
        {
            var item = args.Item as Item;
            if (item == null)
                return;
            var answer = await DisplayAlert("Alert","Would you like to delete that item?","Yes","No");
            if (answer)
            {
                MessagingCenter.Send(this, "DeleteItem", item);
            }
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        private void Decrease_Quantity_Clicked(object sender, EventArgs args)
        {
            var button = (Button)sender;
            var item = (Item)button.Parent.BindingContext;
            item.Quantity--;
            MessagingCenter.Send(this, "QuantityChanged", item);
        }

        private void Increase_Quantity_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var item = (Item)button.Parent.BindingContext;
            item.Quantity++;
            MessagingCenter.Send(this, "QuantityChanged", item);
        }

        //private void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
        //{
        //    var label = (Label)sender;
        //    var item = (Item)label.Parent.BindingContext;
        //    MessagingCenter.Send(this, "DeleteItem", item);
        //}
    }
}