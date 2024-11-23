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
using Windows.Devices.Enumeration;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ERPSystem.WINUI3.Inventory
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class InventoryPage : Page
    {
        public InventoryPage()
        {
            this.InitializeComponent();
            MyTabView.Loaded += MyTabView_Loaded;
        }
        private void MyTabView_Loaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e) 
        { 
            NavigateToPage("items", items); 
            NavigateToPage("stockout", stockout);
            NavigateToPage("stockreturn", stockreturn);
            NavigateToPage("stocksettings", stocksettings);
            NavigateToPage("stockreport", stockreport);
        }
        private static void NavigateToPage(string pageTag, Frame frame) { switch (pageTag) 
            { 
                case "items": frame.Navigate(typeof(items)); 
                    break; 
                case "stockout": frame.Navigate(typeof(stockout)); 
                    break; 
                case "stockreturn": frame.Navigate(typeof(stockreturn)); 
                    break;
                case "stocksettings": frame.Navigate(typeof(stocksettings));
                    break;
                case "stockreport": frame.Navigate(typeof(stockreport));
                    break;
            } 
        }
    }
}
