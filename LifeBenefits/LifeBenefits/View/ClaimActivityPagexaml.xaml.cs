using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LifeBenefits.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ClaimActivityPagexaml : ContentPage
	{
        public string jsonData { get; set; }
        public List<Claim> tempdata;
        public ClaimActivityPagexaml ()
		{
			InitializeComponent ();
            DeserializeJsonData();
            list.ItemsSource = tempdata;
        }

        private void DeserializeJsonData()
        {
            string data = ReadJsonData();
            var collection = JsonConvert.DeserializeObject<List<Claim>>(data);
            tempdata = new List<Claim>(collection);
        }

        public string ReadJsonData()
        {
            var assembly = typeof(Claim).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("LifeBenefits.claims.json");
            using (var reader = new System.IO.StreamReader(stream))
            {
                jsonData = reader.ReadToEnd();
            }
            return jsonData;
        }
    }

    public class Claim
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("serviceDate")]
        public string ServiceDate { get; set; }

        [JsonProperty("provider")]
        public string Provider { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("resp")]
        public string Resp { get; set; }
    }
}