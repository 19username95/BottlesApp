using Android.Content;
using Android.Graphics.Drawables;
using BottlesApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Entry), typeof(XEntryRenderer))]
namespace BottlesApp.Droid.Renderers
{
    public class XEntryRenderer : EntryRenderer
    {
        public XEntryRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
            }
        }
    }
}