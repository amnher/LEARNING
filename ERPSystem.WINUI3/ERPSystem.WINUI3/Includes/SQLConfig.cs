using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ERPSystem.WINUI3.Includes;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using CommunityToolkit.WinUI.UI.Controls;


namespace ERPSystem.WINUI3.Includes
{
    class SQLConfig
    {
        private MySqlConnection con = new("server=htionlinestore.com;port=3306;user id=htionlin_jr;password=Matthew6:33;database=htionlin_db_inventory;sslMode=none");
        private MySqlCommand? cmd;
        private MySqlDataAdapter? da;
        public DataTable? dt;
        int result;
        usableFunction funct = new();

        public async void Execute_CUD(string sql, string msg_false, string msg_true)
        {
            try
            {
                con.Open();
                cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;
                result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    await new ContentDialog
                    {
                        Title = "Success",
                        Content = msg_true,
                        CloseButtonText = "OK"
                    }.ShowAsync();
                }
                else
                {
                    await new ContentDialog
                    {
                        Title = "Failure",
                        Content = msg_false,
                        CloseButtonText = "OK"
                    }.ShowAsync();
                }
            }
            catch (Exception ex)
            {
                await new ContentDialog
                {
                    Title = "Error",
                    Content = ex.Message,
                    CloseButtonText = "OK"
                }.ShowAsync();
            }
            finally
            {
                con.Close();
            }
        }

        public async void Execute_Query(string sql)
        {
            try
            {
                con.Open();
                cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                await new ContentDialog
                {
                    Title = "Error",
                    Content = ex.Message,
                    CloseButtonText = "OK"
                }.ShowAsync();
            }
            finally
            {
                con.Close();
            }
        }

        public async void Load_DTG(string sql, DataGrid dataGrid)
        {
            try
            {
                con.Open();
                cmd = new MySqlCommand();
                da = new MySqlDataAdapter();
                dt = new DataTable();

                cmd.Connection = con;
                cmd.CommandText = sql;
                da.SelectCommand = cmd;
                da.Fill(dt);
                dataGrid.ItemsSource = dt.DefaultView;

                dataGrid.AutoGenerateColumns = true;
            }
            catch (Exception ex)
            {
                await new ContentDialog
                {
                    Title = "Error",
                    Content = ex.Message,
                    CloseButtonText = "OK"
                }.ShowAsync();
            }
            finally
            {
                da?.Dispose();
                con.Close();
            }
        }

        public async void Fill_CBO(string sql, ComboBox comboBox)
        {
            try
            {
                con.Open();
                cmd = new MySqlCommand();
                da = new MySqlDataAdapter();
                dt = new DataTable();

                cmd.Connection = con;
                cmd.CommandText = sql;
                da.SelectCommand = cmd;
                da.Fill(dt);

                comboBox.ItemsSource = dt.Rows.Cast<DataRow>().Select(r => r[0].ToString()).ToList();
            }
            catch (Exception ex)
            {
                await new ContentDialog
                {
                    Title = "Error",
                    Content = ex.Message,
                    CloseButtonText = "OK"
                }.ShowAsync();
            }
            finally
            {
                da?.Dispose();
                con.Close();
            }
        }

        public async void singleResult(string sql)
        {
            try
            {
                con.Open();
                cmd = new MySqlCommand();
                da = new MySqlDataAdapter();
                dt = new DataTable();

                cmd.Connection = con;
                cmd.CommandText = sql;
                da.SelectCommand = cmd;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                await new ContentDialog
                {
                    Title = "Error",
                    Content = ex.Message,
                    CloseButtonText = "OK"
                }.ShowAsync();
            }
            finally
            {
                da?.Dispose();
                con.Close();
            }
        }

        public async void LoadReports(string sql)
        {
            try
            {
                con.Open();
                cmd = new MySqlCommand();
                da = new MySqlDataAdapter();
                dt = new DataTable();

                cmd.Connection = con;
                cmd.CommandText = sql;
                da.SelectCommand = cmd;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                await new ContentDialog
                {
                    Title = "Error",
                    Content = ex.Message,
                    CloseButtonText = "OK"
                }.ShowAsync();
            }
            finally
            {
                da?.Dispose();
                con.Close();
            }
        }

        public async void Autocomplete(string sql, AutoSuggestBox autoSuggestBox)
        {
            try
            {
                con.Open();
                cmd = new MySqlCommand();
                da = new MySqlDataAdapter();
                dt = new DataTable();

                cmd.Connection = con;
                cmd.CommandText = sql;
                da.SelectCommand = cmd;
                da.Fill(dt);

                var suggestions = dt.Rows.Cast<DataRow>().Select(r => r[0].ToString()).ToList();
                autoSuggestBox.ItemsSource = suggestions;
            }
            catch (Exception ex)
            {
                await new ContentDialog
                {
                    Title = "Error",
                    Content = ex.Message,
                    CloseButtonText = "OK"
                }.ShowAsync();
            }
            finally
            {
                da?.Dispose();
                con.Close();
            }
        }

        public async void Autonumber(string sql, TextBox textBox)
        {
            try
            {
                con.Open();
                cmd = new MySqlCommand();
                da = new MySqlDataAdapter();
                dt = new DataTable();

                cmd.Connection = con;
                cmd.CommandText = sql;
                da.SelectCommand = cmd;
                da.Fill(dt);

                textBox.Text = dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                await new ContentDialog
                {
                    Title = "Error",
                    Content = ex.Message,
                    CloseButtonText = "OK"
                }.ShowAsync();
            }
            finally
            {
                da?.Dispose();
                con.Close();
            }
        }

        public void Update_Autonumber(string id)
        {
            Execute_Query("UPDATE `tblautonumber` SET `END`=`END`+`INCREMENT` WHERE `DESCRIPTION`='" + id + "'");
        }
    }
}
