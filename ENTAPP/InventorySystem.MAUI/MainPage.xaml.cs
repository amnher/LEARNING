using InventorySystem.MAUI.Pages;
using System.Linq;

namespace InventorySystem.MAUI
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            disabled_menu();
        }
        
        async private void OnCounterClicked(object sender, EventArgs e)
        {
            Button btn = new Button();
            btn = (Button)sender;
            string selected = btn.Text;
            
            await Navigation.PushAsync(new frmLogin());
            /*
            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
            */
        }
        public void enabled_menu()
        {
            DisplayAlert("", "", "OK");
            ts_ManageUsers.IsEnabled = true;
            ts_Report.IsEnabled = true;
            ts_Return.IsEnabled = true;
            ts_StockOut.IsEnabled = true;
            ts_stocks.IsEnabled = true;
            ts_Login.Text = "Logout";
            //ts_Login.Image = Resources.lock_open;
            ts_settings.IsEnabled = true;

        }
        public void disabled_menu()
        {
            ts_ManageUsers.IsEnabled = false;
            ts_Report.IsEnabled = false;
            ts_Return.IsEnabled = false;
            ts_StockOut.IsEnabled = false;
            ts_stocks.IsEnabled = false;
            ts_Login.Text = "Login";
            ts_settings.IsEnabled = false;
        }

    }

}
