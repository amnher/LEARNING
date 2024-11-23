using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility;


/*
Explanation
Replacing Controls:
-   Replaced Control with Layout<View> to iterate through children in a layout.
-   Replaced TextBox and RichTextBox with Entry and Editor, respectively, which are the MAUI equivalents.

Error Handling:
-   Replaced MessageBox.Show with Application.Current.MainPage.DisplayAlert for showing alerts in .NET MAUI.

Regex Validation:
-   The regular expression validation methods remain the same as they are independent of the UI framework.

DataGridView Adaptation:
-   Replaced DataGridView with CollectionView and adjusted its item sizing strategy.

This adaptation should cover the main functionality of your original code within the .NET MAUI framework. If you have more specific requirements or run into any issues, feel free to ask
*/
namespace ERPSystem.MAUI.Includes
{
    class usableFunction
    {
        [Obsolete]
        public void ClearTxt(Layout<View> container)
        {
            try
            {
                // Loop through each child control in the container
                foreach (var view in container.Children)
                {
                    // If the control is an Entry, clear its text
                    if (view is Entry entry)
                    {
                        entry.Text = string.Empty;
                    }
                    // If the control is an Editor, clear its text
                    else if (view is Editor editor)
                    {
                        editor.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        // Initialize the validating methods
        static Regex ValidName = StringOnly();
        static Regex ValidContact = NumbersOnly();
        static Regex ValidPwd = PasswordPattern();  // Renamed to avoid conflict
        static Regex ValidEmail = EmailAddress();

        // Method for validating email address
        private static Regex EmailAddress()
        {
            string emailPattern = @"^(?!\.)(""([^""\r\\]

|\

\[""\r\\]

)*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(emailPattern, RegexOptions.IgnoreCase);
        }

        // Method for string validation only
        private static Regex StringOnly()
        {
            string stringPattern = "^[a-zA-Z]+$";
            return new Regex(stringPattern, RegexOptions.IgnoreCase);
        }

        // Method for numbers validation only
        private static Regex NumbersOnly()
        {
            string numberPattern = "^[0-9]*$";
            return new Regex(numberPattern, RegexOptions.IgnoreCase);
        }

        // Method for password validation only
        private static Regex PasswordPattern()  // Renamed to avoid conflict
        {
            string passwordPattern = "(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,15})$";
            return new Regex(passwordPattern, RegexOptions.IgnoreCase);
        }

        public void ResponsiveDtg(CollectionView collectionView)
        {
            collectionView.ItemSizingStrategy = ItemSizingStrategy.MeasureAllItems;
        }
    }
}


