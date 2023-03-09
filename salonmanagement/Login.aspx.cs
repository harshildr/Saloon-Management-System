using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace salonmanagement
{
    public partial class Login : System.Web.UI.Page
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection();
        SqlDataAdapter sda = new SqlDataAdapter();
        DataSet ds = new DataSet();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Response.Redirect("~/view/AdminDashboard.aspx");
            }
            else
            con.ConnectionString = @"Data Source=HARSHIL;Initial Catalog=saloon;User ID=sa;Password=Admin@123";
            con.Open();
            
        }

        protected void btn_signin_Click(object sender, EventArgs e)
        {
            string user = txt_uname.Text.Trim();
            cmd.CommandText = "select username,password from tblRegister where username='" + txt_uname.Text + "' and password='" + txt_password.Text + "'  ";
            cmd.Connection = con;
            sda.SelectCommand = cmd;
            sda.Fill(ds, "tblRegister");
            if(ds.Tables[0].Rows.Count > 0)
            {
                Session["user"] = user;
                Response.Redirect("~/view/AdminDashboard.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert{'Something gone wrong'};", true);
            }
        }
    }
}