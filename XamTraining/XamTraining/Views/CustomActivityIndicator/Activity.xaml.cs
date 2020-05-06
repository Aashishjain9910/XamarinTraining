using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamTraining.Models;

namespace XamTraining.Views.CustomActivityIndicator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Activity : ContentPage
    {
        public Activity()
        {
            InitializeComponent();
        }



        private async void buttonLoadingStyle1_clicked(object sender, EventArgs e)
        {
            DependencyService.Get<ILodingPageService>().InitLoadingPage(new LoadingIndicatorStyle_one());
            DependencyService.Get<ILodingPageService>().ShowLoadingPage();
            await Task.Delay(2000);
            DependencyService.Get<ILodingPageService>().HideLoadingPage();

        }

        private async void buttonLoadingStyle2_clicked(object sender, EventArgs e)
        {
            DependencyService.Get<ILodingPageService>().InitLoadingPage(new LoadingIndicatorStyle_two());
            DependencyService.Get<ILodingPageService>().ShowLoadingPage();
            await Task.Delay(2000);
            DependencyService.Get<ILodingPageService>().HideLoadingPage();

        }

        private async void buttonopensNextPage_clicked(object sender, EventArgs e)
        {
            DependencyService.Get<ILodingPageService>().ShowLoadingPage();
            await Task.Delay(2000);
            await Navigation.PushAsync(new LoaderNavigatedPage());
        }
    }
}