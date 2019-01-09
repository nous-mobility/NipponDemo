﻿using LifeBenefits.View;
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
            //Analytics.TrackEvent("Launch Provider from Login View");
            navigation.PushAsync(new FindProvider());
        }
        private void GoToContactUsPage(object obj)
        {
            //Analytics.TrackEvent("Launch Contact Us from Login View");
            navigation.PushAsync(new ContactUs());
        }
        async private void DoLogin(object obj)
        {
            IsBusy = true;
            await Task.Delay(3000);
            IsBusy = false;
            IsPinViewVisible = true;
        }
        private void ConfirmPinCode(object obj)
        {
            //var mainPage = new MasterDetailPage()
            //{
            //    Master = new MasterPage() { Title = "Nippon", Icon = "slideout.png" },
            //    Detail = new NavigationPage(new MainMenuPage())
            //};
            //Application.Current.MainPage = mainPage;
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