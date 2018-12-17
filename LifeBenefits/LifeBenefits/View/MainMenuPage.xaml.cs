using LifeBenefits.ViewModel;
using Microsoft.AppCenter.Crashes;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LifeBenefits.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainMenuPage : ContentPage
	{
		public MainMenuPage ()
		{
			InitializeComponent ();
            BindingContext = new MainMenuViewModel(this.Navigation);
		}

        void SimulateCrash(object sender, System.EventArgs e)
        {
            Crashes.GenerateTestCrash();
        }

        void SimulateError(object sender, System.EventArgs e)
        {
            try
            {
                throw new System.NullReferenceException();
            }
            catch (NullReferenceException ex)
            {
                Crashes.TrackError(ex);
            }
        }
    }
}