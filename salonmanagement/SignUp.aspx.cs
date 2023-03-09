using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace salonmanagement
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_signup_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            if (!FileUpload1.HasFile)
            {
                imagefail.Text = "Please Choose Image";
            }
            else
            {
                int length = FileUpload1.PostedFile.ContentLength;
                byte[] pic = new byte[length];
                FileUpload1.PostedFile.InputStream.Read(pic, 0, length);
                string query = "insert into tblRegister(name, username, email, mobile, dob, password,image) values(@name, @username, @email, @mobile, @dob, @password, @image)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", txt_name.Text);
                cmd.Parameters.AddWithValue("@username", txt_username.Text);
                cmd.Parameters.AddWithValue("@email", txt_eml.Text);
                cmd.Parameters.AddWithValue("@mobile", txt_mbl.Text);
                cmd.Parameters.AddWithValue("@dob", txt_dob.Text);
                cmd.Parameters.AddWithValue("@password", txt_password.Text);
                cmd.Parameters.AddWithValue("@image", pic);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("Login.aspx");
            }
            
        }
    }
}