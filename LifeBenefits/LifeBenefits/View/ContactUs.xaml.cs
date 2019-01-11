using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                //Analytics.TrackEvent("Launch Contact us without Logged in User");
            }
            else
            {
                //Analytics to update user with login 

                //Analytics.TrackEvent("Launch Contact us with Logged in User: "+App.UserId);
            }
        }
	}
}