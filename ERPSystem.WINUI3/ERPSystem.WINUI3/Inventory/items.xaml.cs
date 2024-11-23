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
using static Org.BouncyCastle.Math.EC.ECCurve;
using System.Xml.Linq;
using ERPSystem.WINUI3.Includes;
using CommunityToolkit.WinUI.UI.Controls;
using System.Data;
using System.Collections.ObjectModel;
using MySql.Data.MySqlClient;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ERPSystem.WINUI3.Inventory
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class items : Page
    {
        public ObservableCollection<Item> Items { get; set; }
        public items()
        {
            this.InitializeComponent();
            Items = new ObservableCollection<Item>(); 
            ItemDataGrid.ItemsSource = Items; 
            LoadData();
        }

        private void LoadData() 
        { 
            string connectionString = "server=htionlinestore.com;port=3306;user id=htionlin_jr;password=Matthew6:33;database=htionlin_db_inventory;sslMode=none"; using (MySqlConnection conn = new MySqlConnection(connectionString)) { conn.Open(); string query = "SELECT * FROM tblitems"; using (MySqlCommand cmd = new MySqlCommand(query, conn)) { using (MySqlDataReader reader = cmd.ExecuteReader()) { while (reader.Read()) { Items.Add(new Item { ItemID = reader["ITEMID"].ToString(), Name = reader["NAME"].ToString(), Description = reader["DESCRIPTION"].ToString(), Price = reader.GetDouble("PRICE"), Type = reader["TYPE"].ToString(), Quantity = reader.GetInt32("QTY"), Unit = reader["UNIT"].ToString() }); } } } } }
    }
}
