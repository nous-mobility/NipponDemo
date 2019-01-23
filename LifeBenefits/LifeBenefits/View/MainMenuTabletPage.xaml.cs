using LifeBenefits.ViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LifeBenefits.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainMenuTabletPage : ContentPage
	{
		public MainMenuTabletPage ()
		{
			InitializeComponent ();
            BindingContext = new MainMenuViewModel(this.Navigation);
        }
        private void SimulateCrashOnTablet(object sender, EventArgs e)
        {
            //Crashes.GenerateTestCrash();
        }

        private void SimulateErrorOnTablet(object sender, EventArgs e)
        {
            try
            {
                throw new System.NullReferenceException();
            }
            catch (NullReferenceException ex)
            {
                //Crashes.TrackError(ex);
            }
        }
    }
}