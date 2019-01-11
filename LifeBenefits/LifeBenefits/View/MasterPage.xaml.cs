using Microsoft.AppCenter.Analytics;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LifeBenefits.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : ContentPage
    {
        List<NavItems> NavigationListItem = new List<NavItems>()
        {
            new NavItems(){ Name = "Home", IconName = "listIcon" },
            new NavItems(){ Name = "Terms & Conditions", IconName = "infoIcon" },
            new NavItems(){ Name = "Settings", IconName = "contactIcon" },
            new NavItems(){ Name = "Logout", IconName = "logoutIcon" },
        };
        public MasterPage()
        {
            InitializeComponent();
            navListView.ItemsSource = NavigationListItem;
        }

        private void navListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var mdp = (Application.Current.MainPage as MasterDetailPage);
            var navPage = mdp.Detail as NavigationPage;

            var item = e.Item as NavItems;

            mdp.IsPresented = false;

            switch (item.Name)
            {
                case "Logout":
                    Application.Current.MainPage = new NavigationPage(new LoginPage());
                    Analytics.TrackEvent("Authentication", new Dictionary<string, string> {
                        { "Logout", "Sucess" }
                    });

                    App.UserId = string.Empty;
                    break;
            }
        }
    }

    public class NavItems
    {
        public string Name { get; set; }
        public string IconName { get; set; }
    }
}