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
	public partial class BenefitsDetailPage : ContentPage
	{
        private bool isExpanded=true;
		public BenefitsDetailPage (string title)
		{
			InitializeComponent ();
            this.Title = title;
            isExpanded = true;
            expnandImage.Source = "minus";

            if (Device.Idiom == TargetIdiom.Tablet)
            {
                benefitsDetailFrame.Margin = new Thickness(70, 0, 70, 0);
            }
            else
            {
                benefitsDetailFrame.Margin = new Thickness(6, 0, 6, 0);
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            isExpanded = !isExpanded;
            expandableList.IsVisible = isExpanded;
            expnandImage.Source = isExpanded ? "minus" : "plus";
        }
    }
}