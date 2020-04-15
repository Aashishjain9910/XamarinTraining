using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamTraining.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContentViewPage : ContentView
    {
        public ContentViewPage()
        {
            InitializeComponent();
            frame1.Opacity = 0;
            frame2.Opacity = 0;
            frame3.Opacity = 0;
            frame4.Opacity = 0;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            frame1.Opacity = 1;
            frame2.Opacity = 0;
            frame3.Opacity = 0;
            frame4.Opacity = 0;

        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            frame1.Opacity = 0;
            frame2.Opacity = 1;
            frame3.Opacity = 0;
            frame4.Opacity = 0;
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            frame1.Opacity = 0;
            frame2.Opacity = 0;
            frame3.Opacity = 1;
            frame4.Opacity = 0;
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            frame1.Opacity = 0;
            frame2.Opacity = 0;
            frame3.Opacity = 0;
            frame4.Opacity = 1;
        }

        
    }
}