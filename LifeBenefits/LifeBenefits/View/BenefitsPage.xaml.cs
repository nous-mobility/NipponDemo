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
	public partial class BenefitsPage : ContentPage
	{
		public BenefitsPage ()
		{
			InitializeComponent ();

            if (Device.Idiom == TargetIdiom.Tablet)
            {
                benefitsFrame.Margin = new Thickness(70, 0, 70, 0);
            }
            else
            {
                benefitsFrame.Margin = new Thickness(6, 0, 6, 0);
            }
        }

        private void MedicalPharmacy_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BenefitsDetailPage("Medical/Pharmacy"));
        }
        private void Dental_Tapped(object sender, EventArgs e)
        {

        }
        private void HRA_Tapped(object sender, EventArgs e)
        {

        }
    }
}