using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamTraining.Views.CustomActivityIndicator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoaderNavigatedPage : ContentPage
    {
        public LoaderNavigatedPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Device.StartTimer(TimeSpan.FromSeconds(3), () =>
            {
                DependencyService.Get<ILodingPageService>().HideLoadingPage();

                return false;
            });
        }

    }
}