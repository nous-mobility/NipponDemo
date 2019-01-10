using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Views;
using LifeBenefits.CustomControl;
using LifeBenefits.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.ExportRenderer(typeof(ViewCell), typeof(ExtendedViewCellRenderer))]
namespace LifeBenefits.Droid.Renderers
{
    public class ExtendedViewCellRenderer : ViewCellRenderer
    {
        private bool _selected;

        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, Android.Views.ViewGroup parent, Android.Content.Context context)
        {
            var cell = base.GetCellCore(item, convertView, parent, context);

            cell.SetBackgroundResource(Resource.Drawable.ViewCellBackground);

            return cell;
        }
    }
}