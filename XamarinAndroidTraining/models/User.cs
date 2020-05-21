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

namespace XamarinAndroidTraining.models
{
    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ChangesMode { get; set; }
        public string StatusDate { get; set; }
        public string StatusChanged { get; set; }
        public string ByWillSmith { get; set; }
        public string UpdateTime { get; set; }


    }
}