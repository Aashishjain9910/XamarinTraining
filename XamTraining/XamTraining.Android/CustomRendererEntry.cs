using Android.Content;
using Android.Graphics.Drawables;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinEntry;
using XamarinEntry.Droid;
using XamTraining;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomRendererEntry))]
namespace XamarinEntry.Droid
{
    public class CustomRendererEntry : EntryRenderer
    {
        public CustomRendererEntry(Context context) : base(context)
        {
            AutoPackage = false;
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