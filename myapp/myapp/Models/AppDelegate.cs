<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:d="http://xamarin.com/schemas/2014/forms/design"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
             mc:Ignorable="d"
             x:Class="app.MainPage">

    <StackLayout>
        <!-- Place new controls here -->
        <Label Text="Welcome to Xamarin.Forms!" 
           HorizontalOptions="Center"
           VerticalOptions="CenterAndExpand" />
        <ListView ItemsSource="{Binding tab.rates}">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <Grid>
                        <Grid.RowDefinitions>
                            <RowDefinition Height="*"/>
                            <RowDefinition Height="auto"/>
                 
                        </Grid.RowDefinitions>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="*"/>
                            <ColumnDefinition Width="auto"/>
                        </Grid.ColumnDefinitions>

                    </Grid>                  
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
    </StackLayout>

</ContentPage>




using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using app.Models;
namespace app.ViewModels
{
    public class MainVM : INotifyPropertyChanged
    {
        public MainVM()
        {
            Table a = new Table();
            this.tab = a;
        }
        private Table _tab { get; set; }
        public Table tab { get => _tab; set
            {
                this._tab = value;
                OnPropertyChanged(nameof(_tab));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name){
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


    }
}



using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using Newtonsoft;
using Newtonsoft.Json;

namespace app.Models
{
    public class Table
    {
        public string table { get; set; }
        public string no { get; set; }
        public string tradingDate { get; set; }
        public string effectiveDate { get; set; }
        public List<Rates> rates {get;set;}
        public Table()
        {
            RestClient client = new RestClient("https://api.nbp.pl/api/exchangerates/tables/c/");
            RestRequest request = new RestRequest();
            request.AddParameter("format", "json");
            var res=client.Execute(request);
            List<_Table> obj = JsonConvert.DeserializeObject<List<_Table>>(res.Content);
            this.table = obj[0].table;
            this.no = obj[0].no;
            this.tradingDate = obj[0].tradingDate;
            this.effectiveDate = obj[0].effectiveDate;
            this.rates= obj[0].rates;

        }
    }
    public class _Table
    {
        public string table { get; set; }
        public string no { get; set; }
        public string tradingDate { get; set; }
        public string effectiveDate { get; set; }
        public List<Rates> rates { get; set; }
    }
    public class Rates
    {
        public string currency { get; set; }
        public string code { get; set; }
        public float bid { get; set; }
        public float ask { get; set; }


    }
}
