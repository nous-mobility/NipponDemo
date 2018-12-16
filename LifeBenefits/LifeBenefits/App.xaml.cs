﻿using LifeBenefits.View;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace LifeBenefits
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MasterDetailPage()
            {
                Master = new MasterPage() { Title = "Nippon",Icon = "slideout.png"},
                Detail = new NavigationPage(new MainMenuPage())
            };
        }

        protected override void OnStart()
        {
            // Handle the Analytics and Crash reports on Microsoft Visual studio app center
            AppCenter.Start("ios=5d0c5fb3-ff1d-48dc-9a98-74d15374a2db;" + "android=52d9953e-1d3a-4b2a-88db-f7ccbcc5f0fb;", typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
