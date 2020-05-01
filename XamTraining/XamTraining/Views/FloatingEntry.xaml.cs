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
    public partial class FloatingEntry : ContentView
    {
        public FloatingEntry()
        {
            InitializeComponent();
            EntryField.BindingContext = this;
            EntryField.Focused += (s, a) =>
            {
                HiddenLabel.IsVisible = true;
                if (string.IsNullOrEmpty(EntryField.Text))
                {
                    EntryField.Placeholder = null;
                }

            };
            EntryField.Unfocused += (s, a) =>
            {
                if (string.IsNullOrEmpty(EntryField.Text))
                {
                    HiddenLabel.IsVisible = false;
                    EntryField.Placeholder = Placeholder;
                }
            };
        }
        public static BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(FloatingEntry), defaultBindingMode: BindingMode.TwoWay);

        public static BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(FloatingEntry), defaultBindingMode: BindingMode.TwoWay, propertyChanged: (bindable, oldVal, newval) =>
        {
            var matEntry = (FloatingEntry)bindable;
            matEntry.EntryField.Placeholder = (string)newval;
            matEntry.HiddenLabel.Text = (string)newval;
        });
        public static BindableProperty SideImageProperty = BindableProperty.Create(nameof(SideImage), typeof(string), typeof(FloatingEntry), defaultBindingMode: BindingMode.TwoWay, propertyChanged: (bindable, oldVal, newval) =>
        {
            var matEntry = (FloatingEntry)bindable;
            matEntry.img.Source = (string)newval;
        });

        public static BindableProperty IsPasswordProperty = BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(FloatingEntry), defaultValue: false, propertyChanged: (bindable, oldVal, newVal) =>
        {
            var matEntry = (FloatingEntry)bindable;
            matEntry.EntryField.IsPassword = (bool)newVal;
        });




        public bool IsPassword
        {
            get => (bool)GetValue(IsPasswordProperty);
            set => SetValue(IsPasswordProperty, value);
        }
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        public string SideImage
        {
            get => (string)GetValue(SideImageProperty);
            set => SetValue(SideImageProperty, value);
        }

    }
}