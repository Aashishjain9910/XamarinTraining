﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Plugin.CurrentActivity;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamTraining.Droid;
using XamTraining.Views.CustomActivityIndicator;
using Platform = Xamarin.Forms.Platform.Android.Platform;

[assembly: Xamarin.Forms.Dependency(typeof(XamTrainingDroid))]
namespace XamTraining.Droid
{
    public class XamTrainingDroid : ILodingPageService
    {
        private Android.Views.View _nativeView;

        private Dialog _dialog;

        private bool _isInitialized;



        public void InitLoadingPage(ContentPage loadingIndicatorPage = null)
        {
            if (loadingIndicatorPage != null)
            {
                // build the loading page with native base
                loadingIndicatorPage.Parent = Xamarin.Forms.Application.Current.MainPage;

                loadingIndicatorPage.Layout(new Rectangle(0, 0,
                    Xamarin.Forms.Application.Current.MainPage.Width,
                    Xamarin.Forms.Application.Current.MainPage.Height));

                var renderer = loadingIndicatorPage.GetOrCreateRenderer();

                _nativeView = renderer.View;

                _dialog = new Dialog(CrossCurrentActivity.Current.Activity);
                _dialog.RequestWindowFeature((int)WindowFeatures.NoTitle);
                _dialog.SetCancelable(false);
                _dialog.SetContentView(_nativeView);
                Window window = _dialog.Window;
                window.SetLayout(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
                window.ClearFlags(WindowManagerFlags.DimBehind);
                window.SetBackgroundDrawable(new ColorDrawable(Android.Graphics.Color.Transparent));

                _isInitialized = true;
            }
        }



        public void ShowLoadingPage()
        {
            if (!_isInitialized)
            {
                InitLoadingPage(new LoadingIndicatorStyle_one());

            }
            _dialog.Show();

        }


        private void XamFormsPage_Appearing(object sender, EventArgs e)
        {
            var animation = new Animation(callback: d => ((ContentPage)sender).Content.Rotation = d,
                                          start: ((ContentPage)sender).Content.Rotation,
                                          end: ((ContentPage)sender).Content.Rotation + 360,
                                          easing: Easing.Linear);
            animation.Commit(((ContentPage)sender).Content, "RotationLoopAnimation", 16, 800, null, null, () => true);
        }


        public void HideLoadingPage()
        {
            _dialog.Hide();
        }
    }

        internal static class PlatformExtension
        {
            public static IVisualElementRenderer GetOrCreateRenderer(this VisualElement bindable)
            {
                var renderer = Platform.GetRenderer(bindable);
                if (renderer == null)
                {
                         renderer = Platform.CreateRendererWithContext(bindable, CrossCurrentActivity.Current.Activity);
                         Platform.SetRenderer(bindable, renderer);
                }
                return renderer;
            }
        }


    
}