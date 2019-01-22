using LifeBenefits.View;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace LifeBenefits
{
    public partial class App : Application
    {
        public static int AndroidScreenWidth;
        public static int AndroidcreenHeight;
        public static int iOSScreenWidth;
        public static int iOSScreenHeight;

        public static string UserId = string.Empty;
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            // Handle the Analytics and Crash reports on Microsoft Visual studio app center
            AppCenter.Start("ios=f017d260-d2a6-428c-b057-cd8fd80b97fc;" + "android=01e09342-2170-4129-84df-c2c4f1cb7758;", typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
