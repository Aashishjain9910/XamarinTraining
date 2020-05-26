using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamarinAndroidTraining.Adapter;
using XamarinAndroidTraining.models;

namespace XamarinAndroidTraining.Activities
{
    [Activity(Label = "ListViewAdapterActivity", MainLauncher = true)]
    public class ListViewAdapterActivity : Activity
    {
        ListView listview;
        AlertDialog.Builder dialogBuilder;
        ImageView ic_menu, ic_plus;
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            await TryToGetPermission();
            SetContentView(Resource.Layout.ListViewAdapterLayout);
            listview = FindViewById<ListView>(Resource.Id.listview);
            listview.Adapter = new MyCustomListAdapter(UserData.Users);
            dialogBuilder = new AlertDialog.Builder(this);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            ic_menu = FindViewById<ImageView>(Resource.Id.ic_menu);
            ic_plus = FindViewById<ImageView>(Resource.Id.ic_plus);

        }


        protected override void OnResume()
        {
            base.OnResume();
            listview.ItemClick += MyList_ItemClick;
            //ic_menu.Click += Ic_menu_Click;
            ic_plus.Click += Ic_plus_Click;

        }
        protected override void OnPause()
        {
            base.OnPause();

            listview.ItemClick -= MyList_ItemClick;
            //ic_menu.Click -= Ic_menu_Click;
            ic_plus.Click -= Ic_plus_Click;
        }
        private void Ic_plus_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ContactListActivity));
            StartActivity(intent);

        }

        //private void Ic_menu_Click(object sender, EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        async Task TryToGetPermission()
        {
            if ((int)Build.VERSION.SdkInt >= 23)
            {
                await GetPermission();
                return;
            }
        }
        const int RequestLocationId = 0;

        readonly string[] PermissionGroupLocation =
       {
            Manifest.Permission.AccessCoarseLocation,
            Manifest.Permission.AccessFineLocation
        };

        async Task GetPermission()
        {
            string permission = Manifest.Permission.AccessFineLocation;

            if (CheckSelfPermission(permission) == (int)Android.Content.PM.Permission.Granted)
            {
                Toast.MakeText(this, "Loaction Permission Granted", ToastLength.Short).Show();
                return;
            }

            if (ShouldShowRequestPermissionRationale(permission))
            {
                Android.App.AlertDialog.Builder alert = new Android.App.AlertDialog.Builder(this);
                alert.SetTitle("Permissions Needed");
                alert.SetMessage("The application need special permissions to continue");
                alert.SetPositiveButton("Request Permissions", (senderAlert, args) =>
                {
                    RequestPermissions(PermissionGroupLocation, RequestLocationId);
                });

                alert.SetNegativeButton("Cancel", (senderAlert, args) =>
                {
                    Toast.MakeText(this, "Cancelled!", ToastLength.Short).Show();
                });

                Dialog dialog = alert.Create();
                dialog.Show();


                return;
            }

            RequestPermissions(PermissionGroupLocation, RequestLocationId);
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            switch (requestCode)
            {
                case RequestLocationId:
                    {
                        if (grantResults[0] == (int)Android.Content.PM.Permission.Granted)
                        {
                            Toast.MakeText(this, "Special permissions granted", ToastLength.Short).Show();

                        }
                        else
                        {

                            Toast.MakeText(this, "Special permissions denied", ToastLength.Short).Show();

                        }
                    }
                    break;
            }
        }



        private void MyList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //Toast.MakeText(this,UserData.Users[e.Position].StatusChanged,ToastLength.Short);
            dialogBuilder.SetMessage(UserData.Users[e.Position].StatusChanged);
            AlertDialog alertDialog = dialogBuilder.Create();
            alertDialog.SetTitle("");
            alertDialog.SetCanceledOnTouchOutside(false);
            alertDialog.SetButton("Ok", (c, ev) =>
            {

            });

            alertDialog.Show();


        }
        // Create your application here

    }
}