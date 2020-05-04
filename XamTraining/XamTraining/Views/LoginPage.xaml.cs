using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamTraining.Models;

namespace XamTraining.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {

        LoginModel loginModel = new LoginModel();
        public LoginPage()
        {

            InitializeComponent();
            loginModel.Show += Model_Show;
            BindingContext = loginModel;
            localPath = Path.Combine(FileSystem.AppDataDirectory, localFileName);
            localPath1 = Path.Combine(FileSystem.AppDataDirectory, localFileName1);

        }

        private void Model_Show(object sender, EventArgs e)
        {
            var str = (string)sender;
            App.Current.MainPage.DisplayAlert("Error", str, "OK");
        }

        const string localFileName = "TheFile.txt";
        const string localFileName1 = "TheFile1.txt";
        
        

        string localPath;
        string localPath1;
        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                File.WriteAllText(localPath, mailId.Text);
                File.WriteAllText(localPath1, pass.Text);
                
            }

        }

        private void loadEmail(object sender, EventArgs e)
        {
            EmailContext.Text = File.ReadAllText(localPath1);
            PassContext.Text = File.ReadAllText(localPath);
        }
    }
}