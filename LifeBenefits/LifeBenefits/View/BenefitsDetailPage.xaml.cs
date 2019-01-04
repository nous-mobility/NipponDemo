﻿using System;
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
        private bool isExpanded;
		public BenefitsDetailPage (string title)
		{
			InitializeComponent ();
            this.Title = title;
            isExpanded = true;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            isExpanded = !isExpanded;
            expandableList.IsVisible = isExpanded;
        }
    }
}