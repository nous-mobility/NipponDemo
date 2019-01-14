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
	public partial class WellnessPortalPage : ContentPage
	{
		public WellnessPortalPage ()
		{
			InitializeComponent ();
		}

        void webviewNavigating(object sender, WebNavigatingEventArgs e)
        {
            loader.IsVisible = true;
            loader.IsRunning = true;
        }

        void webviewNavigated(object sender, WebNavigatedEventArgs e)
        {
            loader.IsVisible = false;
            loader.IsRunning = false;
        }
    }
}