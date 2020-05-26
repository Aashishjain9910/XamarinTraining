 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Transitions;
using Android.Views;
using Android.Widget;

namespace XamarinAndroidTraining.models
{
    public static class UserData
    {
        public static List<User> Users { get; set; }

        static UserData()
        {
            var temp = new List<User>();
            AddUser(temp);
            Users = temp.ToList();

        }
        static void AddUser(List<User> users)
        {
            users.Add(new User()
            {
                ChangesMode="Changes Mode:",
                StatusDate="19 JUL 2019",
                StatusChanged="Status changed from Not started to In progress",
                ByWillSmith="By: Will Smith",
                UpdateTime="02 hours ago"
            });
            users.Add(new User()
            {
                ChangesMode="Changes Mode:",
                StatusDate="19 JUL 2019",
                StatusChanged= "Status changed from In progress to Completed",
                ByWillSmith="By: Will Smith",
                UpdateTime="02 hours ago"
            });
            users.Add(new User()
            {
                ChangesMode="Changes Mode:",
                StatusDate="19 JUL 2019",
                StatusChanged= "Status changed from Not started to In progress",
                ByWillSmith="By: Will Smith",
                UpdateTime="02 hours ago"
            });
            users.Add(new User()
            {
                ChangesMode="Changes Mode:",
                StatusDate="19 JUL 2019",
                StatusChanged= "Status changed from Not started to In progress",
                ByWillSmith="By: Will Smith",
                UpdateTime="02 hours ago"
            });
            users.Add(new User()
            {
                ChangesMode="Changes Mode:",
                StatusDate="19 JUL 2019",
                StatusChanged= "Status changed from Not started to In progress",
                ByWillSmith="By: Will Smith",
                UpdateTime="02 hours ago"
            });
            users.Add(new User()
            {
                ChangesMode="Changes Mode:",
                StatusDate="19 JUL 2019",
                StatusChanged= "Status changed from Not started to On hold.",
                ByWillSmith="By: Will Smith",
                UpdateTime="02 hours ago"
            });
            users.Add(new User()
            {
                ChangesMode="Changes Mode:",
                StatusDate="19 JUL 2019",
                StatusChanged= "Status changed from Not started to In progress",
                ByWillSmith="By: Will Smith",
                UpdateTime="02 hours ago"
            });




        }

    }
}