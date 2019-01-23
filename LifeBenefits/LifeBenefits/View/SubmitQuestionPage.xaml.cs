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
	public partial class SubmitQuestionPage : ContentPage
	{
		public SubmitQuestionPage ()
		{
			InitializeComponent ();

            if (Device.Idiom == TargetIdiom.Tablet)
            {
                providerFrameSpacing.Padding = new Thickness(18, 18, 18, 20);
                editor.HeightRequest = 150;
            }
            else
            {
                providerFrameSpacing.Padding = new Thickness(12, 12, 12, 15);
                editor.HeightRequest = 80;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}