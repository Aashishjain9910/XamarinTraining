using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using XamarinAndroidTraining.models;

namespace XamarinAndroidTraining.Activities
{
    [Activity(Label = "SplashScreenActivity", /*MainLauncher = true,*/ Theme = "@style/Theme.Splash",NoHistory =true)]
    public class SplashScreenActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Thread.Sleep(3000);
            ISharedPreferences pref = Application.Context.GetSharedPreferences("UserInfo", FileCreationMode.Private);
            string email = pref.GetString("Email", String.Empty);
            string password = pref.GetString("Password", String.Empty);

            if (email == String.Empty || password == String.Empty)
            {
                Intent intent = new Intent(this, typeof(LoginActivity));
                this.StartActivity(intent);
            }

            else
            {
                //There are saved credentials  

                if (email == "aashish@gmail.com" && password == "Jain@9910")
                {
                    //Successful take the user to application  
                    Intent intent = new Intent(this, typeof(DashboardActivity));

                    User user = new User()
                    {
                        Email = "aashish@gmail.com",
                        Password = "Jain@9910"
                    };

                    intent.PutExtra("User", JsonConvert.SerializeObject(user));

                    this.StartActivity(intent);
                }

                else
                {
                    //Unsuccesful, take user to login screen  
                    Intent intent = new Intent(this, typeof(LoginActivity));
                    this.StartActivity(intent);
                    this.Finish();
                }
            }



        }
    }
}