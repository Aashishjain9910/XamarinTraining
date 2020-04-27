using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(XamTraining.Droid.RoundEffect), nameof(XamTraining.Droid.RoundEffect))]
namespace XamTraining.Droid
{
    class RoundEffect : PlatformEffect
    {
        ViewOutlineProvider originalProvider;
        Android.Views.View effectTarget;
        protected override void OnAttached()
        {
            try
            {
                effectTarget = Control ?? Container;
                originalProvider = effectTarget.OutlineProvider;
                effectTarget.OutlineProvider = new CornerRadiusOutlineProvider(Element);
                effectTarget.ClipToOutline = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to set corner radius: {ex.Message}");
            }
        }

        protected override void OnDetached()
        {
            if (effectTarget != null)
            {
                effectTarget.OutlineProvider = originalProvider;
                effectTarget.ClipToOutline = false;
            }
        }
    }
}