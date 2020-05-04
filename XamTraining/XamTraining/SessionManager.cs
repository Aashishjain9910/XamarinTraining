using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace XamTraining
{
    public class SessionManager
    {
        private const string USER_LOGGED_IN_KEY = "l_key";

        public bool isUserLoggedIn()
        {
            string val = GetData(USER_LOGGED_IN_KEY);
            return val == "true";
        }

        public void setUserLoggedIn()
        {
            AddValue(USER_LOGGED_IN_KEY, "true");
        }

        public string GetData(string key)
        {
            return Preferences.Get(key, "");
        }

        public void AddValue(string key, string value)
        {
            Preferences.Set(key, value);
        }

        public void DeleteSession()
        {
            DeleteData(USER_LOGGED_IN_KEY);
        }

        private void DeleteData(string key)
        {
            Preferences.Remove(key, "");
        }
    }

}
