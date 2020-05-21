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
using XamarinAndroidTraining.Fragment;
using XamarinAndroidTraining.Resources.layout;

namespace XamarinAndroidTraining.Activities
{
    [Activity(Label = "FragmentButtonActivity")]
    public class FragmentButtonActivity : Activity
    {
        Button page1, page2, page3, page4;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.FragmentButtonLayout);
            page1 = FindViewById<Button>(Resource.Id.fragmentOne);
            page2 = FindViewById<Button>(Resource.Id.fragmentTwo);
            page3 = FindViewById<Button>(Resource.Id.fragmentThree);
            page4 = FindViewById<Button>(Resource.Id.fragmentfour);


        }

        protected override void OnResume()
        {
            base.OnResume();
            page1.Click += Page1_Click;
            page2.Click += Page2_Click;
            page3.Click += Page3_Click;
            page4.Click += Page4_Click;

        }
        private void Page1_Click(object sender, EventArgs e)
        {
            //var trans = FragmentManager.BeginTransaction();
            //trans.Replace(Resource.Id.fragmentContainer,new FirstFragment(), "frag1");
            //trans.Commit();
        }

        private void Page2_Click(object sender, EventArgs e)
        { 
        //    var trans = FragmentManager.BeginTransaction();
        //    trans.Replace(Resource.Id.fragmentContainer, new SecondFragment(), "frag2");
        //    trans.Commit();
        }

        private void Page3_Click(object sender, EventArgs e)
        {
            //var trans = FragmentManager.BeginTransaction();
            //trans.Replace(Resource.Id.fragmentContainer, new ThirdFragment(), "frag3");
            //trans.Commit();
        }

       
        private void Page4_Click(object sender, EventArgs e)
        {
            //var trans = FragmentManager.BeginTransaction();
            //trans.Replace(Resource.Id.fragmentContainer, new FourthFragment(), "frag4");
            //trans.Commit();
        }

        protected override void OnPause()
        {
            base.OnPause();
            page1.Click -= Page1_Click;
            page2.Click -= Page2_Click;
            page3.Click -= Page3_Click;
            page4.Click -= Page4_Click;

        }


    }
}