using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using CommunityToolkit.WinUI.UI.Controls;
using ERPSystem.WINUI3.Includes;

namespace ERPSystem.WINUI3.Includes
{
    class usableFunction
    {
        public void ClearTxt(Panel container)
        {
            try
            {
                foreach (var child in container.Children)
                {
                    if (child is TextBox textBox)
                    {
                        textBox.Text = string.Empty;
                    }
                    else if (child is RichEditBox richEditBox)
                    {
                        richEditBox.Document.SetText(Microsoft.UI.Text.TextSetOptions.None, string.Empty);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessageDialog("Error", ex.Message);
            }
        }

        static Regex ValidName = StringOnly();
        static Regex ValidContact = NumbersOnly();
        static Regex ValidPwd = PasswordPattern();  // Renamed to avoid conflict
        static Regex ValidEmail = EmailAddress();

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

        private static Regex StringOnly()
        {
            string stringPattern = "^[a-zA-Z]+$";
            return new Regex(stringPattern, RegexOptions.IgnoreCase);
        }

        private static Regex NumbersOnly()
        {
            string numberPattern = "^[0-9]*$";
            return new Regex(numberPattern, RegexOptions.IgnoreCase);
        }

        private static Regex PasswordPattern()  // Renamed to avoid conflict
        {
            string passwordPattern = "(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,15})$";
            return new Regex(passwordPattern, RegexOptions.IgnoreCase);
        }

        public void ResponsiveDtg(DataGrid dataGrid)
        {
            foreach (var column in dataGrid.Columns)
            {
                if (column is DataGridTextColumn textColumn)
                {
                    textColumn.ElementStyle = new Microsoft.UI.Xaml.Style(typeof(TextBlock))
                    {
                        Setters = {
                            new Setter(TextBlock.TextWrappingProperty, TextWrapping.Wrap)
                        }
                    };
                }
            }
            dataGrid.UpdateLayout();
        }

        private async void ShowMessageDialog(string title, string message)
        {
            var dialog = new ContentDialog
            {
                Title = title,
                Content = message,
                CloseButtonText = "OK"
            };

            await dialog.ShowAsync();
        }
    }
}
