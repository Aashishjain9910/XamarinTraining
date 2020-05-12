using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocDevelops.Buttons
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageButtons : ContentView
    {


        // Button's Text
        public static readonly BindableProperty ButtonTextProperty = BindableProperty.Create(nameof(ButtonText), typeof(string), typeof(ImageButtons), default(string));
        public string ButtonText
        {
            get
            {
                return (string)GetValue(ButtonTextProperty);
            }
            set
            {
                SetValue(ButtonTextProperty, value);
            }
        }
        


        // Font Color Of Button's Text
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(ColorOfText), typeof(Color), typeof(ImageButtons), default(Color));
        public Color ColorOfText
        {
            get
            {
                return (Color)GetValue(TextColorProperty);
            }
            set
            {
                SetValue(TextColorProperty, value);
            }
        }



        // Font Size of Button's Text
        public static readonly BindableProperty TextFontSizeProperty = BindableProperty.Create(nameof(TextFontSize), typeof(string), typeof(ImageButtons), default(string));
        public string TextFontSize
        {
            get
            {
                return (string)GetValue(TextFontSizeProperty);
            }
            set
            {
                SetValue(TextFontSizeProperty, value);
            }
        }
        

        
        // Font Family of Button's Text
        public static readonly BindableProperty TextFontFamilyProperty = BindableProperty.Create(nameof(TextFontFamily), typeof(string), typeof(ImageButtons), default(string));
        public string TextFontFamily
        {
            get
            {
                return (string)GetValue(TextFontFamilyProperty);
            }
            set
            {
                SetValue(TextFontFamilyProperty, value);
            }
        }
        

        
        // Font Attribute of Button's Text
        public static readonly BindableProperty TextFontAttributeProperty = BindableProperty.Create(nameof(TextFontAttribute), typeof(FontAttributes), typeof(ImageButtons), default(FontAttributes));
        public FontAttributes TextFontAttribute
        {
            get
            {
                return (FontAttributes)GetValue(TextFontAttributeProperty);
            }
            set
            {
                SetValue(TextFontAttributeProperty, value);
            }
        }



        // opacity of text
        public static readonly BindableProperty TextOpacityProperty = BindableProperty.Create(nameof(TextOpacity), typeof(string), typeof(ImageButtons), default(string));
        public string TextOpacity
        {
            get
            {
                return (string)GetValue(TextOpacityProperty);
            }
            set
            {
                SetValue(TextOpacityProperty, value);
            }
        }




        // Source of Image
        public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(nameof(SourceOfImage), typeof(string), typeof(ImageButtons), default(string));
        public string SourceOfImage
        {
            get
            {
                return (string)GetValue(ImageSourceProperty);
            }
            set
            {
                SetValue(ImageSourceProperty, value);
            }
        }


        
        
        // Background Color of Button
        public static readonly BindableProperty BtnBackgroundColorProperty = BindableProperty.Create(nameof(ButtonBackgroundColor), typeof(Color), typeof(ImageButtons), default(Color));
        public Color ButtonBackgroundColor
        {
            get
            {
                return (Color)GetValue(BtnBackgroundColorProperty);
            }
            set
            {
                SetValue(BtnBackgroundColorProperty, value);
            }
        }




        // Border color of Button
        public static readonly BindableProperty BtnBorderColorProperty = BindableProperty.Create(nameof(ButtonBorderColor), typeof(Color), typeof(ImageButtons), default(Color));
        public Color ButtonBorderColor
        {
            get
            {
                return (Color)GetValue(BtnBorderColorProperty);
            }
            set
            {
                SetValue(BtnBorderColorProperty, value);
            }
        }




        // Layout Orientation of button i.e. Vertical or horizontal
        public static readonly BindableProperty StackOrientationProperty = BindableProperty.Create(nameof(LayoutOrientation), typeof(StackOrientation), typeof(ImageButtons), default(StackOrientation));
        public StackOrientation LayoutOrientation
        {
            get
            {
                return (StackOrientation)GetValue(StackOrientationProperty);
            }
            set
            {
                SetValue(StackOrientationProperty, value);
            }
        }




        // Corner Radius of Button
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadiusOfButton), typeof(string), typeof(ImageButtons), default(string));
        public string CornerRadiusOfButton
        {
            get
            {
                return (string)GetValue(CornerRadiusProperty);
            }
            set
            {
                SetValue(CornerRadiusProperty, value);
            }
        }
        
        
        
        


        // opacity of Button
        public static readonly BindableProperty ButtonOpacityProperty = BindableProperty.Create(nameof(ButtonOpacity), typeof(string), typeof(ImageButtons), default(string));
        public string ButtonOpacity
        {
            get
            {
                return (string)GetValue(ButtonOpacityProperty);
            }
            set
            {
                SetValue(ButtonOpacityProperty, value);
            }
        }





        // Corner radius of Image
        public static readonly BindableProperty ImageCornerRadiusProperty = BindableProperty.Create(nameof(ImageCornerRadius), typeof(string), typeof(ImageButtons), default(string));
        public string ImageCornerRadius
        {
            get
            {
                return (string)GetValue(ImageCornerRadiusProperty);
            }
            set
            {
                SetValue(ImageCornerRadiusProperty, value);
            }
        }





        //  Background Color Of Image
        public static readonly BindableProperty ImageBackgroundColorProperty = BindableProperty.Create(nameof(ImageBackgroundColor), typeof(Color), typeof(ImageButtons), default(Color));
        public Color ImageBackgroundColor
        {
            get
            {
                return (Color)GetValue(ImageBackgroundColorProperty);
            }
            set
            {
                SetValue(ImageBackgroundColorProperty, value);
            }
        }





        //  Border Color Of Image
        public static readonly BindableProperty ImageBorderColorProperty = BindableProperty.Create(nameof(ImageBorderColor), typeof(Color), typeof(ImageButtons), default(Color));
        public Color ImageBorderColor
        {
            get
            {
                return (Color)GetValue(ImageBorderColorProperty);
            }
            set
            {
                SetValue(ImageBorderColorProperty, value);
            }
        }

        


        
        //  visibility Of Image
        public static readonly BindableProperty ImageVisibilityrProperty = BindableProperty.Create(nameof(ImageVisibility), typeof(bool), typeof(ImageButtons), default(bool));
        public bool ImageVisibility
        {
            get
            {
                return (bool)GetValue(ImageVisibilityrProperty);
            }
            set
            {
                SetValue(ImageVisibilityrProperty, value);
            }
        }




        // opacity of Image
        public static readonly BindableProperty ImageOpacityProperty = BindableProperty.Create(nameof(ImageOpacity), typeof(string), typeof(ImageButtons), default(string));
        public string ImageOpacity
        {
            get
            {
                return (string)GetValue(ImageOpacityProperty);
            }
            set
            {
                SetValue(ImageOpacityProperty, value);
            }
        }




         // opacity of Image's Background
        public static readonly BindableProperty ImageBackgroundOpacityProperty = BindableProperty.Create(nameof(ImageBackgroundOpacity), typeof(string), typeof(ImageButtons), default(string));
        public string ImageBackgroundOpacity
        {
            get
            {
                return (string)GetValue(ImageBackgroundOpacityProperty);
            }
            set
            {
                SetValue(ImageBackgroundOpacityProperty, value);
            }
        }





        //Border Padding or width of Button
        public static readonly BindableProperty FramePaddingProperty = BindableProperty.Create(nameof(BorderPadding), typeof(Thickness), typeof(ImageButtons), default(Thickness));
        public Thickness BorderPadding
        {
            get
            {
                return (Thickness)GetValue(FramePaddingProperty);
            }
            set
            {
                SetValue(FramePaddingProperty, value);
            }
        }


        

        //Shadow of Button
        public static readonly BindableProperty ButtonShadowProperty = BindableProperty.Create(nameof(ButtonShadow), typeof(bool), typeof(ImageButtons), default(bool));
        public bool ButtonShadow
        {
            get
            {
                return (bool)GetValue(ButtonShadowProperty);
            }
            set
            {
                SetValue(ButtonShadowProperty, value);
            }
        }

        
        //Flow Direction of Button
        public static readonly BindableProperty ButtonFlowDirectionProperty = BindableProperty.Create(nameof(ButtonDirectionFlow), typeof(FlowDirection), typeof(ImageButtons), default(FlowDirection));
        public FlowDirection ButtonDirectionFlow
        {
            get
            {
                return (FlowDirection)GetValue(ButtonFlowDirectionProperty);
            }
            set
            {
                SetValue(ButtonFlowDirectionProperty, value);
            }
        }





        //Enable or Disable Property 
        public static readonly BindableProperty BtnEnablingProperty = BindableProperty.Create(nameof(IsButtonEnable), typeof(bool), typeof(ImageButtons), default(bool));
        public bool IsButtonEnable
        {
            get
            {
                return (bool)GetValue(BtnEnablingProperty);
            }
            set
            {
                SetValue(BtnEnablingProperty, value);
            }
        }

        
        
        //Visibility Property of Button 
        public static readonly BindableProperty ButtonVisibilityProperty = BindableProperty.Create(nameof(IsButtonVisible), typeof(bool), typeof(ImageButtons), default(bool));
        public bool IsButtonVisible
        {
            get
            {
                return (bool)GetValue(ButtonVisibilityProperty);
            }
            set
            {
                SetValue(ButtonVisibilityProperty, value);
            }
        }



        



        //public event EventHandler Click;
        public static readonly BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(ICommand), typeof(ImageButtons), null);
        public ICommand Command
        {
            get
            {
                return (ICommand)GetValue(CommandProperty);
            }
            set
            {
                SetValue(CommandProperty, value);
            }
        }

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create("CommandParameter", typeof(object), typeof(ImageButtons), null);
        public object CommandParameter
        {
            get
            {
                return (object)GetValue(CommandParameterProperty);
            }
            set
            {
                SetValue(CommandParameterProperty, value);
            }
        }




        public ImageButtons()
        {
            InitializeComponent();

            innerLabel.SetBinding(Label.TextProperty, new Binding("ButtonText", source: this)); //text of button
            
            innerLabel.SetBinding(Label.TextColorProperty, new Binding("ColorOfText", source: this));   // color of button's text
            
            innerLabel.SetBinding(Label.FontSizeProperty, new Binding("TextFontSize", source: this));   // Size of Button's Text

            innerLabel.SetBinding(Label.FontFamilyProperty, new Binding("TextFontFamily", source: this));   // Font Family of Button's Text

            innerLabel.SetBinding(Label.FontAttributesProperty, new Binding("TextFontAttribute", source: this));   // Font Attribute of Button's Text

            innerLabel.SetBinding(Label.OpacityProperty, new Binding("TextOpacity", source: this));   // opacity of Button's Text
            
            innerImage.SetBinding(Image.SourceProperty, new Binding("SourceOfImage", source: this));    // Source of Button's Image
            
            innerImage.SetBinding(Image.OpacityProperty, new Binding("ImageOpacity", source: this));    // opacity of Button's Image 
            
            innerFrame.SetBinding(Frame.OpacityProperty, new Binding("ImageBackgroundOpacity", source: this));    //Background opacity of Button's Image

            innerFrame.SetBinding(Frame.BackgroundColorProperty, new Binding("ImageBackgroundColor", source: this));    //Background Color of Button's Image
            
            innerFrame.SetBinding(Frame.BorderColorProperty, new Binding("ImageBorderColor", source: this));    //Border Color of Button's Image or Icon
            
            innerFrame.SetBinding(Frame.CornerRadiusProperty, new Binding("ImageCornerRadius", source: this));  //Corner Radius of Button's Image
            
            innerFrame.SetBinding(Frame.IsVisibleProperty, new Binding("ImageVisibility", source: this));  //Visibility of Button's Image
            
            btn_Stack.SetBinding(StackLayout.OrientationProperty, new Binding("LayoutOrientation", source: this));  // Layout orientation of Button
            
            btn_Frame.SetBinding(Frame.BackgroundColorProperty, new Binding("ButtonBackgroundColor", source: this));    //Background Color of Button
            
            btn_Frame.SetBinding(Frame.BorderColorProperty, new Binding("ButtonBorderColor", source: this));    //Border Color of Button
            
            btn_Frame.SetBinding(Frame.PaddingProperty, new Binding("BorderPadding", source: this));    //Padding of Border for the Width of Button
            
            btn_Frame.SetBinding(Frame.CornerRadiusProperty, new Binding("CornerRadiusOfButton", source: this));     //Corner Radius of Button

            btn_Frame.SetBinding(Frame.OpacityProperty, new Binding("ButtonOpacity", source: this));     //Opacity of Button
            
            btn_Frame.SetBinding(Frame.HasShadowProperty, new Binding("ButtonShadow", source: this));     //Shadow of Button
            
            btn_Frame.SetBinding(Frame.FlowDirectionProperty, new Binding("ButtonDirectionFlow", source: this));     //Shadow of Button

            VirtualButton.SetBinding(Button.IsEnabledProperty, new Binding("IsButtonEnable", source: this));     //Enable or disable function of button
            
            btn_Frame.SetBinding(Frame.IsVisibleProperty, new Binding("IsButtonVisible", source: this));     //Visibility function of button

            //this.GestureRecognizers.Add(new TapGestureRecognizer
            //{
            //    Command = new Command(() =>
            //    {
            //        Click?.Invoke(this, EventArgs.Empty);
            //        if (Command != null)
            //        {
            //            if (Command.CanExecute(CommandParameter))
            //                Command.Execute(CommandParameter);
            //        }
            //    })
                
            //});

        }
    }
}