﻿using PocDevelops.Activity_Indicator;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocDevelops
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

           // MainPage = new MainPage();
            MainPage = new NavigationPage(new ActivityIndicatorPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
