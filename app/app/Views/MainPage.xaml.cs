using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using app.ViewModels;
using app.Views;
using app.Models;
using Newtonsoft.Json;
namespace app
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            BindingContext = new MainVM();
        }
        public async void Detail(Object sender, ItemTappedEventArgs e)
        {
            Rates a = e.Item as Rates;
            
            await Navigation.PushAsync(new DetailPage(a));
        }
    }
}
