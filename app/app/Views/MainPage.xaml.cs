﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using app.ViewModels;
using app.Views;
using app.Models;
namespace app
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainVM();
        }
        public void Detail(Object sender, EventArgs e)
        {
            detailResponse a = new detailResponse("usd");
            //new DetailPage(e.);
        }
    }
}