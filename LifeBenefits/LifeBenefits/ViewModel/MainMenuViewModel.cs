using LifeBenefits.View;
using Microsoft.AppCenter.Analytics;
using System.Windows.Input;
using Xamarin.Forms;

namespace LifeBenefits.ViewModel
{
    public class MainMenuViewModel
    {
        private INavigation navigation;
        #region Commands
        public ICommand OnFindProviderClick => new Command(GoToProviderPage);
        public ICommand OnWellnessPortalClick => new Command(GoWellnessPortalPage);
        public ICommand OnClaimActivityClick => new Command(GoToClaimActivityPage);
        public ICommand OnBenefitsClick => new Command(GoToBenefitsPage);
        public ICommand OnIDCardClick => new Command(GoToIDCardPage);
        public ICommand OnContactUsClick => new Command(GoToContactUsPage);
        #endregion

        #region CommandMethods
        private void GoToProviderPage(object obj)
        {
            //Analytics.TrackEvent("Launch Provider");
            navigation.PushAsync(new FindProvider());
        }
        private void GoWellnessPortalPage(object obj)
        {
            //Analytics.TrackEvent("Launch Wellness Portal");
        }
        private void GoToClaimActivityPage(object obj)
        {
            //Analytics.TrackEvent("Launch Claim Activity");
            navigation.PushAsync(new ClaimActivityPagexaml());
        }
        private void GoToBenefitsPage(object obj)
        {
            //Analytics.TrackEvent("Launch Benfits");
            navigation.PushAsync(new BenefitsPage());
        }
        private void GoToIDCardPage(object obj)
        {
            //Analytics.TrackEvent("Launch ID Card");
            navigation.PushAsync(new IDCardPage());
        }
        private void GoToContactUsPage(object obj)
        {
            //Analytics.TrackEvent("Launch Contact Us");
            navigation.PushAsync(new ContactUs());
        }
        #endregion
        public MainMenuViewModel(INavigation navigation)
        {
            this.navigation = navigation;
        }
    }
}
