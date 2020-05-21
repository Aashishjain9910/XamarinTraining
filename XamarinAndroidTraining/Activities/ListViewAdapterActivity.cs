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
using XamarinAndroidTraining.Adapter;
using XamarinAndroidTraining.models;

namespace XamarinAndroidTraining.Activities
{
    [Activity(Label = "ListViewAdapterActivity", MainLauncher =true)]
    public class ListViewAdapterActivity : Activity
    {
        ListView listview;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ListViewAdapterLayout);
            listview = FindViewById<ListView>(Resource.Id.listview);
            listview.Adapter=new MyCustomListAdapter(UserData.Users);

            // Create your application here
        }
    }
}