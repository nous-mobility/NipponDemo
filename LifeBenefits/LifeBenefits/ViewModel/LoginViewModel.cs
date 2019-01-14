using LifeBenefits.View;
using Microsoft.AppCenter.Analytics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace LifeBenefits.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private INavigation navigation;

        public LoginViewModel(INavigation navigation)
        {
            this.navigation = navigation;
        }

        #region Properties
        private bool isBusy;
        public bool IsBusy
        {
            get
            {
                return isBusy;
            }
            set
            {
                if (isBusy != value)
                {
                    isBusy = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private bool isPinViewVisible;
        public bool IsPinViewVisible
        {
            get
            {
                return isPinViewVisible;
            }
            set
            {
                if (isPinViewVisible != value)
                {
                    isPinViewVisible = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string userId= "john.doe@info.com";
        public string UserId
        {
            get
            {
                return userId;
            }
            set
            {
                if (userId != value)
                {
                    userId = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion

        #region Commands
        public ICommand OnFindProviderClick => new Command(GoToProviderPage);
        public ICommand OnContactUsClick => new Command(GoToContactUsPage); 
        public ICommand OnLoginButtonClick => new Command(DoLogin);
        public ICommand OnConfirmButtonClick => new Command(ConfirmPinCode);
        public ICommand OnBackButtonClick => new Command(GoBackToLoginFrame);
        #endregion

        #region CommandsMethod
        private void GoToProviderPage(object obj)
        {
            navigation.PushAsync(new FindProvider());
        }
        private void GoToContactUsPage(object obj)
        {
            navigation.PushAsync(new ContactUs());
        }
        async private void DoLogin(object obj)
        {
            IsBusy = true;
            await Task.Delay(3000);
            IsBusy = false;

            //Navigate to MainPage without Pin Code Authentication
            NavigateToMainPage();

            //Navigate to MainPage with Pin Code Authentication
            //IsPinViewVisible = true;

            Analytics.TrackEvent("Authentication", new Dictionary<string, string> {
                    { "Login", "Sucess" }
                });
        }
        private void ConfirmPinCode(object obj)
        {
            NavigateToMainPage();
            Analytics.TrackEvent("Authentication", new Dictionary<string, string> {
                    { "PIN Verification", "Sucess" }
                });
        }

        private void NavigateToMainPage()
        {
            var mainPage = new MasterDetailPage()
            {
                Master = new MasterPage() { Title = "Nippon", Icon = "slideout.png" },
                Detail = new NavigationPage(new MainMenuPage())
            };
            Application.Current.MainPage = mainPage;

            App.UserId = UserId;
        }
        private void GoBackToLoginFrame(object obj)
        {
            IsPinViewVisible = false;
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
