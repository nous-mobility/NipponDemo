using Xamarin.UITest;

namespace LifeBenefits.UITests
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp.Android.ApkFile("../../../LifeBenefits/LifeBenefits.Android/bin/Debug/com.nous.nippondemo.apk").StartApp();
            }

            return ConfigureApp.iOS.StartApp();
        }
    }
}
