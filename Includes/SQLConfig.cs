using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ERPSystem.MAUI.Includes;
using Microsoft.Maui.Controls;
/*
xplanation
Display Alerts:
-   Replace MessageBox.Show with Application.Current.MainPage.DisplayAlert for displaying alerts in .NET MAUI.

Replace Windows Forms Controls:
-   Convert TextBox to Entry.
-   Convert DataGridView to CollectionView.
-   Convert ComboBox to Picker.

SQL Operations:
-   The database operations remain the same but ensure the MySQL connector is installed and configured for your project.
*/

namespace ERPSystem.MAUI.Includes
{
    class SQLConfig
    {
        private MySqlConnection con = new MySqlConnection("server=htionlinestore.com;port=3306;user id=htionlin_jr;password=Matthew6:33;database=htionlin_db_inventory;sslMode=none");
        private MySqlCommand? cmd;
        private MySqlDataAdapter? da;
        public DataTable? dt;
        int result;
        usableFunction funct = new usableFunction();

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
                    await Application.Current.MainPage.DisplayAlert("Success", msg_true, "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Failure", msg_false, "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
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
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                con.Close();
            }
        }

        public async void Load_DTG(string sql, CollectionView collectionView)
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
                collectionView.ItemsSource = dt.Rows;
                funct.ResponsiveDtg(collectionView);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                da.Dispose();
                con.Close();
            }
        }

        public async void Fill_CBO(string sql, Picker picker)
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

                picker.ItemsSource = dt.Rows.Cast<DataRow>().Select(r => r[0].ToString()).ToList();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                da.Dispose();
                con.Close();
            }
        }

        public async void SingleResult(string sql)
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
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                da.Dispose();
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
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                da.Dispose();
                con.Close();
            }
        }

        public async void Autocomplete(string sql, Entry entry)
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
                entry.ClearValue(Entry.TextProperty);
                entry.ClearValue(Entry.TextTransformProperty);
                // MAUI doesn't support autocomplete natively, might need a custom control
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                da.Dispose();
                con.Close();
            }
        }

        public async void Autonumber(string sql, Entry entry)
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

                entry.Text = dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                // Suppressing the exception handling here as in the original code
            }
            finally
            {
                da.Dispose();
                con.Close();
            }
        }

        public void Update_Autonumber(string id)
        {
            Execute_Query("UPDATE `tblautonumber` SET `END`=`END`+`INCREMENT` WHERE `DESCRIPTION`='" + id + "'");
        }
    }
}




