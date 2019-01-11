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

            if (Device.Idiom == TargetIdiom.Tablet)
            {
                contactUsFrame.Margin = new Thickness(70, 0, 70, 0);
            }
            else
            {
                contactUsFrame.Margin = new Thickness(6, 0, 6, 0);
            }

            if (string.IsNullOrEmpty(App.UserId))
            {
                //Analytics to update user without login 

                Analytics.TrackEvent("Unregistered User Access", new Dictionary<string, string> {
                    { "Screen", "Contact Us" }
                });
            }
        }
	}
}