using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using XamTraining;
using XamTraining.UWP;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(EntryCustomRenderers))]
namespace XamTraining.UWP
{
    class EntryCustomRenderers: EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.BorderBrush.Opacity = 0;
                Control.Background = new SolidColorBrush(Colors.Red);
            }
        }
    }
}
