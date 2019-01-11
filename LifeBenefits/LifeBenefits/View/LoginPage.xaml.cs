using LifeBenefits.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LifeBenefits.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
            BindingContext = new LoginViewModel(this.Navigation);

            if (Device.Idiom == TargetIdiom.Tablet)
            {
                loginFrame.Margin = new Thickness(98, 0, 98, 0);
                pinCodeFrame.Margin = new Thickness(98, 0, 98, 0);
            }
            else
            {
                loginFrame.Margin = new Thickness(20, 0, 20, 0);
                pinCodeFrame.Margin = new Thickness(20, 0, 20, 0);
            }
        }
	}
}