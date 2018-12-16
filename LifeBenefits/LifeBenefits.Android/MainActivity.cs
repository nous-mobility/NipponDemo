
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using ImageCircle.Forms.Plugin.Droid;
using Xamarin;

namespace LifeBenefits.Droid
{
    [Activity(Label = "LifeBenefits", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait, WindowSoftInputMode = SoftInput.AdjustResize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            FormsMaps.Init(this, savedInstanceState);
            XamEffects.Droid.Effects.Init();
            ImageCircleRenderer.Init();

            LoadApplication(new App());
        }
    }
}