using Microsoft.AppCenter.Analytics;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LifeBenefits.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListItemPage : ContentPage
    {
        public List<Items> tempdata;
        public string jsonData { get; set; }
        public ListItemPage(string filterType)
        {
            InitializeComponent();

            if (Device.Idiom == TargetIdiom.Tablet)
            {
                refineSearchButton.Margin = new Thickness(0,0,0,15);
                providerSearchResultFrame.Padding = new Thickness(18, 15, 18, 0);
            }
            else
            {
                refineSearchButton.Margin = new Thickness(0, 0, 0, 5);
                providerSearchResultFrame.Padding = new Thickness(12, 10, 12, 0);
            }

            DeserializeJsonData();

            switch(filterType)
            {
                case "All":
                    list.ItemsSource = tempdata;
                    providerType.Text = ": All";
                    break;

                case "Medical":
                    var medicalData = from p in tempdata
                                      where p.Type == "Medical"
                                      select p;
                    list.ItemsSource = medicalData;
                    providerType.Text = ": Medical";
                    break;
                case "Dental":
                    var dentalData = from p in tempdata
                                     where p.Type == "Dental"
                                     select p;
                    list.ItemsSource = dentalData;
                    providerType.Text = ": Dental";
                    break;
            }
        }

        private void DeserializeJsonData()
        {
            string data = ReadJsonData();
            var collection = JsonConvert.DeserializeObject<List<Items>>(data);
            tempdata = new List<Items>(collection);
        }

        public string ReadJsonData()
        {
            var assembly = typeof(Items).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("LifeBenefits.providers.json");
            using (var reader = new System.IO.StreamReader(stream))
            {
                jsonData = reader.ReadToEnd();
            }
            return jsonData;
        }

        private void list_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedItem = e.Item as Items;

            if (selectedItem != null) {
                Analytics.TrackEvent("Provider selected", new Dictionary<string, string> {
                    { "Name", selectedItem.Name },
                    { "Type", selectedItem.Type},
                    { "Network", "Aetna Signature Administration (ASA)"}
                });
                Navigation.PushAsync(new ItemDetailPage(selectedItem));
            }

            ((ListView)sender).SelectedItem = null;
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
    public class Items
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("lat")]
        public string Lat { get; set; }
        [JsonProperty("long")]
        public string Long { get; set; }
    }

}