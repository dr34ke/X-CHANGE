using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.Models;
using app.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microcharts;
namespace app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public DetailPage(Rates rates)
        {
            InitializeComponent();
            BindingContext = new DetailVM(rates);
        }
    }
}