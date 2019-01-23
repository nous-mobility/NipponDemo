using Microsoft.AppCenter.Analytics;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LifeBenefits.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactUs : ContentPage
	{
		public ContactUs ()
		{
			InitializeComponent ();

            if (string.IsNullOrEmpty(App.UserId))
            {
                //Analytics to update user without login 

                Analytics.TrackEvent("Unregistered User Access", new Dictionary<string, string> {
                    { "Screen", "Contact Us" }
                });
            }
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(App.UserId))
            {
                Navigation.PushAsync(new SubmitQuestionPage());
            }
            else
                DisplayAlert("Alert", "Please Login to submit a question", "OK");
        }
    }
}