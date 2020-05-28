﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace XamarinAndroidTraining.Activities
{
    [Activity(Label = "ContactListActivity")]
    public class ContactListActivity : ListActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var uri = ContactsContract.CommonDataKinds.Phone.ContentUri;
            string[] projection = {
            ContactsContract.CommonDataKinds.Phone.InterfaceConsts.DisplayName,
            ContactsContract.CommonDataKinds.Phone.Number
        };
            var cursor = ManagedQuery(uri, projection, null, null, null);
            var contactList = new List<string>();
            if (cursor.MoveToFirst())
            {
                do
                {

                    contactList.Add(cursor.GetString(cursor.GetColumnIndex(projection[0])));
                    contactList.Add(cursor.GetString(cursor.GetColumnIndex(projection[1])));
                } while (cursor.MoveToNext());
            }
            ListAdapter = new ArrayAdapter<string>(this, Resource.Layout.ContactListLayout, contactList);


        }

    }
}