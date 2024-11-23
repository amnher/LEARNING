using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using ERPSystem.WINUI3.Inventory;
using ERPSystem.WINUI3.Includes;
using Microsoft.UI.Windowing;
using Windows.Graphics;
using System.Runtime.InteropServices;
// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ERPSystem.WINUI3
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            NavView.SelectedItem = NavView.FooterMenuItems[0];
            // Store the text in the shared property
            
            SharedDataModel.Instance.SharedPropertyBool = invent.IsEnabled;
            ContentFrame.Navigate(typeof(LoginPage));
        }

        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected) { ContentFrame.Navigate(typeof(SettingsPage)); }
            else
            {
                NavigationViewItem? selectedItem = args.SelectedItem as NavigationViewItem; switch (selectedItem.Tag)
                {
                    case "dashboard": ContentFrame.Navigate(typeof(SettingsPage)); break;
                    case "inventory": ContentFrame.Navigate(typeof(InventoryPage)); break;
                    case "production": ContentFrame.Navigate(typeof(SettingsPage)); break;
                    case "sales": ContentFrame.Navigate(typeof(SettingsPage)); break;
                    case "purchasing": ContentFrame.Navigate(typeof(SettingsPage)); break;
                    case "payroll": ContentFrame.Navigate(typeof(SettingsPage)); break;
                    case "loginpage": ContentFrame.Navigate(typeof(LoginPage)); break;
                }
            }
        }


        /*
private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
{
   if (args.IsSettingsSelected) { ContentFrame.Navigate(typeof(SettingsPage)); }
   else
   {
       NavigationViewItem selectedItem = args.SelectedItem as NavigationViewItem; switch (selectedItem.Tag)
       {
           case "dashboard": ContentFrame.Navigate(typeof(SettingsPage)); break;
           case "inventory": ContentFrame.Navigate(typeof(InventoryPage)); break;
           case "production": ContentFrame.Navigate(typeof(SettingsPage)); break;
           case "sales": ContentFrame.Navigate(typeof(SettingsPage)); break;
           case "purchasing": ContentFrame.Navigate(typeof(SettingsPage)); break;
           case "payroll": ContentFrame.Navigate(typeof(SettingsPage)); break;
       }
   }
}*/


    }
}
