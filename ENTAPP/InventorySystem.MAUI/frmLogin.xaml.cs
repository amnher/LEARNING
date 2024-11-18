
using Microsoft.Maui.Controls;
using MySql.Data.MySqlClient;
using System.Data;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace InventorySystem.MAUI.Pages;

public partial class frmLogin : ContentPage
{
	public frmLogin()
	{
		InitializeComponent();
        Timer1_Tick();

	}
    MainPage main = new MainPage();

    private MySqlConnection con = new MySqlConnection("server=htionlinestore.com;port=3306;user id=htionlin_jr;password=Matthew6:33;database=htionlin_db_inventory;sslMode=none");
    private MySqlCommand cmd;
    private MySqlDataAdapter da;
    public DataTable dt;
    int result;
    string sql;
    //usableFunction funct = new usableFunction();
    private void Timer1_Tick()
    {
        lbltime.Text = DateTime.Now.ToShortTimeString();
        lbldate.Text = DateTime.Now.ToShortDateString();
    }

    async private void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    async private void btnlogin_Clicked(object sender, EventArgs e)
    {
        sql = " SELECT* FROM user WHERE user_name = '" + txtusername.Text + "' and pass = sha1('" + txtpass.Text + "')";
        singleResult(sql);
        if (dt.Rows.Count > 0)
        {
            await DisplayAlert("Notice", "WELCOME", "Continue");
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Notice", "Either Account does not exist or invalid username or password! Please contact administrator", "OK");
            
            
            //    MessageBox.Show("Account does not exist! Please contact administrator.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        
    }
    public void singleResult(string sql)

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
            //MessageBox.Show(ex.Message);
        }
        finally
        {
            da.Dispose();
            con.Close();
        }
    }
}