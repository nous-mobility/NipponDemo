using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LifeBenefits.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FindProvider : ContentPage
    {
        private bool filterStatus;
        private string selectedFilterType = string.Empty;
        public FindProvider()
        {
            InitializeComponent();
            HideShowFilterPanel(false);
            allTick.IsVisible = true;
            medicalTick.IsVisible = false;
            dentalTick.IsVisible = false;
            filterPanel.IsVisible = false;
            selectedFilterType = "All";
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            HideShowFilterPanel(false);
            filterStatus = false;
            Navigation.PushAsync(new ListItemPage(selectedFilterType));
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            filterStatus = !filterStatus;
            HideShowFilterPanel(filterStatus);
        }
        private async void HideShowFilterPanel(bool show)
        {
            if (show)
            {
                await filterPanel.ScaleTo(1.0f, 100, Easing.CubicIn);
                //await filterPanel.FadeTo(1.0f, 100);
                filterPanel.IsVisible = true;
            }
            else
            {
                await filterPanel.ScaleTo(0.0f, 0, Easing.CubicOut);
                //await filterPanel.FadeTo(0.0f);
                filterPanel.IsVisible = false;
            }
        }
        private void AllFilter_Tapped(object sender, EventArgs e)
        {
            HideShowFilterPanel(false);
            allTick.IsVisible = true;
            medicalTick.IsVisible = false;
            dentalTick.IsVisible = false;
            selectedFilterType = "All";
        }
        private void MedicalFilter_Tapped(object sender, EventArgs e)
        {
            HideShowFilterPanel(false);
            allTick.IsVisible = false;
            medicalTick.IsVisible = true;
            dentalTick.IsVisible = false;
            selectedFilterType = "Medical";
        }
        private void DentalFilter_Tapped(object sender, EventArgs e)
        {
            HideShowFilterPanel(false);
            allTick.IsVisible = false;
            medicalTick.IsVisible = false;
            dentalTick.IsVisible = true;
            selectedFilterType = "Dental";
        }
    }
}