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
    [Activity(Label = "GoogleWebViewActivity")]
    public class GoogleWebViewActivity : Activity
    {
        WebView webView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Google_WebView);
            webView = FindViewById<WebView>(Resource.Id.webview);
            webView.Settings.JavaScriptEnabled = true;
            webView.SetWebViewClient(new HybridWebViewClient());
            // Render the view from the type generated from RazorView.cshtml  
            webView.LoadUrl("https://tinyurl.com/yar6cw36");
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