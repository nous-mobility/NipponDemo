using Microsoft.AppCenter.Analytics;
using Newtonsoft.Json;
using System;
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
        private bool filterStatus;
        public string jsonData { get; set; }
        public ListItemPage()
        {
            InitializeComponent();
            HideShowFilterPanel(false);
            DeserializeJsonData();
            list.ItemsSource = tempdata;
            allTick.IsVisible = true;
            medicalTick.IsVisible = false;
            dentalTick.IsVisible = false;
            filterPanel.IsVisible = false;
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
            HideShowFilterPanel(false);
            var selectedItem = e.Item as Items;

            if (selectedItem != null) {
                Analytics.TrackEvent("Provider selected", new Dictionary<string, string> {
                    { "Name", selectedItem.Name },
                    { "Type", selectedItem.Type}
                });
                Navigation.PushAsync(new ItemDetailPage(selectedItem));
            }

            ((ListView)sender).SelectedItem = null;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
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
            list.ItemsSource = tempdata;
            allTick.IsVisible = true;
            medicalTick.IsVisible = false;
            dentalTick.IsVisible = false;
        }
        private void MedicalFilter_Tapped(object sender, EventArgs e)
        {
            HideShowFilterPanel(false);
            allTick.IsVisible = false;
            medicalTick.IsVisible = true;
            dentalTick.IsVisible = false;

            var medicalData = from p in tempdata
                        where p.Type == "Medical"
                        select p;
            list.ItemsSource = medicalData;
        }
        private void DentalFilter_Tapped(object sender, EventArgs e)
        {
            HideShowFilterPanel(false);
            allTick.IsVisible = false;
            medicalTick.IsVisible = false;
            dentalTick.IsVisible = true;

            var dentalData = from p in tempdata
                              where p.Type == "Dental"
                             select p;
            list.ItemsSource = dentalData;
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