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
    public partial class ActivityTestPage : ContentPage
    {
        public ActivityTestPage()
        {
            InitializeComponent();

            BindingContext = new ActivityIndicatorModel();
        }

        private ActivityIndicatorModel ViewModel => BindingContext as ActivityIndicatorModel;

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await ViewModel.LoadData();
        }


        //private async void Button_Clicked(object sender, EventArgs e)
        //{
        //    await PopupNavigation.PushAsync
        //}
        //private void loader_1(object sender, EventArgs e)
        //{

        //}

        //private void loader_2(object sender, EventArgs e)
        //{

        //}

        //private void loader_3(object sender, EventArgs e)
        //{

        //}

        //private void loader_4(object sender, EventArgs e)
        //{

        //}

    }
}