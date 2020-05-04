using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamTraining.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPage3 : ContentPage
    {
        public TestPage3()
        {
            InitializeComponent();

            localPath = Path.Combine(FileSystem.AppDataDirectory ,localFileName);
        }
        const string templateFineName = "FileSystemTemplate.txt";

        const string localFileName = "TheFile.txt";
        string localPath;

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            using(var stream = await FileSystem.OpenAppPackageFileAsync(templateFineName))
            {
                using (var reader= new StreamReader(stream))
                {
                    LabelOutput.Text = await reader.ReadToEndAsync();
                }
            }

            

        }

        private void Button_Clicked_1(object sender, System.EventArgs e)
        {
            loadingText.Text = File.ReadAllText(localPath);
        }

        private void Button_Clicked_2(object sender, System.EventArgs e)
        {
            
            File.WriteAllText(localPath,CurrentContext.Text);
        }

        private void logoutSession(object sender, System.EventArgs e)
        {
            SessionManager sm = new SessionManager();
            sm.DeleteSession();
            App.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }
    }
}