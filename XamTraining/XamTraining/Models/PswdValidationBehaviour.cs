using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace XamTraining.Models
{
    public class PswdValidationBehaviour : Behavior<Entry>
    {
        const string pswdRegex = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$";
        
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }
        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
            

        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            bool IsValid = false;
            IsValid = (Regex.IsMatch(e.NewTextValue, pswdRegex));
            if ( IsValid)
            {
                ((Entry)sender).TextColor = Color.Green;
            }
            else
                ((Entry)sender).TextColor = Color.Red;
            

        }
    }
}
