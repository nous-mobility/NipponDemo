using Xamarin.Forms;

namespace LifeBenefits.CustomControl
{
    public class ExtendedViewCell : ViewCell
    {
        public static readonly BindableProperty SelectedBackgroundColorProperty =
            BindableProperty.Create("SelectedBackgroundColor", typeof(Color), typeof(ExtendedViewCell), Color.FromHex("#FFFFFF"));

        public Color SelectedBackgroundColor
        {
            get { return (Color)GetValue(SelectedBackgroundColorProperty); }
            set { SetValue(SelectedBackgroundColorProperty, value); }
        }
    }
}
