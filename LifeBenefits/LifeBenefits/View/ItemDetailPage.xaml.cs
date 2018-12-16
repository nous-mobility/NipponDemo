using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace LifeBenefits.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemDetailPage : ContentPage
	{
        private Items selectedItem;
		public ItemDetailPage (Items item)
		{
			InitializeComponent ();
            selectedItem = item;
            lblName.Text = selectedItem.Name;
            lblType.Text = selectedItem.Type;
            lblPhone.Text = selectedItem.Phone;
            lblAddress.Text = selectedItem.Address;

            map.MoveToRegion(
                MapSpan.FromCenterAndRadius(new Xamarin.Forms.Maps.Position(Convert.ToDouble(selectedItem.Lat), Convert.ToDouble(selectedItem.Long))
                , Distance.FromMiles(1)));

            var pin = new Pin()
            {
                Position = new Position(Convert.ToDouble(selectedItem.Lat), Convert.ToDouble(selectedItem.Long)),
                Label = selectedItem.Address
            };

            map.Pins.Add(pin);
        }
	}
}