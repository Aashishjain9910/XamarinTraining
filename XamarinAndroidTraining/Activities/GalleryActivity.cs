
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Net;


namespace XamarinAndroidTraining.Activities
{
    [Activity(Label = "GalleryActivity")]
    public class GalleryActivity : Activity
    {
       ImageView imageFromGallery;
        Button pickImage;
        public static readonly int PickImageId = 1000;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.GalleryLayout);

            imageFromGallery = FindViewById<ImageView>(Resource.Id.selectedFromGallery);
           pickImage = FindViewById<Button>(Resource.Id.pickImage);
           

        }
        protected override void OnResume()
        {
            base.OnResume();
            pickImage.Click += PickImage_Click;
        }

        private void PickImage_Click(object sender, EventArgs e)
        {
            Intent = new Intent();
            Intent.SetType("image/*");
            Intent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(Intent, "Select Picture"), PickImageId);

        }


        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if ((requestCode == PickImageId) && (resultCode == Result.Ok) && (data != null))
            {
                Android.Net.Uri uri = data.Data;
                imageFromGallery.SetImageURI(uri);
            }
        }

        protected override void OnPause()
        {
            base.OnPause();
            pickImage.Click -= PickImage_Click;
        }




    }
}