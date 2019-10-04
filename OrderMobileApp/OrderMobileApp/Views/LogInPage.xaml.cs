using OrderMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrderMobileApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LogInPage : ContentPage
	{
        public Distributor Distributor { get; set; }

		public LogInPage ()
		{
			InitializeComponent ();

            Distributor = new Distributor { Id = 0 };

            BindingContext = this;
		}

        private void Log_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "LogIn", Distributor);
        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MainPage());
        }
    }
}