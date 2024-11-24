using Windows.UI.Popups;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using ERPSystem.WINUI3.Includes;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ERPSystem.WINUI3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }
        SQLConfig config = new SQLConfig();
        string sql;
        private async void btnlogin_Click(object sender, RoutedEventArgs e)
        {
            sql = " SELECT* FROM user WHERE user_name = '" + txtusername.Text + "' and pass = sha1('" + txtpass.Text + "')";
            config.singleResult(sql);
            if(btnlogin.Content == "Login")
            {
                if (config.dt.Rows.Count > 0)
                {
                    btnlogin.Content = "Logout";
                    txtusername.IsEnabled = false;
                    txtpass.IsEnabled = false;
                    SharedDataModel.Instance.SharedPropertyBool = true;
                }
                else
                {
                    var dialog = new ContentDialog 
                    { 
                        Title = "Error", 
                        Content = "Invalid credentials", 
                        CloseButtonText = "OK" 
                    };
                    var messageDialog = new MessageDialog("This is a message dialog", "Title"); 
                    messageDialog.Commands.Add(new UICommand("OK")); 
                    messageDialog.Commands.Add(new UICommand("Cancel")); 
                    await messageDialog.ShowAsync();
                    txtusername.Text = "";
                    txtpass.Text = "";
                }
            } else {
                btnlogin.Content = "Login";
                txtusername.IsEnabled = true;
                txtpass.IsEnabled = true;
            }


           

        }
    }
}
