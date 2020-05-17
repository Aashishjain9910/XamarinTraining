using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Webkit;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace XamarinAndroidTraining.Activities
{
    [Activity(Label = "FacebookWebViewActivity")]
    public class FacebookWebViewActivity : Activity
    {
        WebView webView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Facebook_WebView);
            webView = FindViewById<WebView>(Resource.Id.facebookWebview);
            webView.Settings.JavaScriptEnabled = true;
            webView.SetWebViewClient(new HybridWebViewClient());
         
            webView.LoadUrl("https://www.facebook.com/login/?next=https%3A%2F%2Fwww.facebook.com%2Ffacebookapp%2F");
        }


        public class HybridWebViewClient : WebViewClient
        {
            public override bool ShouldOverrideUrlLoading(WebView view, string url)
            {

                view.LoadUrl(url);
                return true;
            }
            public override void OnPageStarted(WebView view, string url, Android.Graphics.Bitmap favicon)
            {
                base.OnPageStarted(view, url, favicon);
            }
            public override void OnPageFinished(WebView view, string url)
            {
                base.OnPageFinished(view, url);
            }
            public override void OnReceivedError(WebView view, [GeneratedEnum] ClientError errorCode, string description, string failingUrl)
            {
                base.OnReceivedError(view, errorCode, description, failingUrl);
            }
        }
    }
}