using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace salonmanagement.view
{
    public partial class Profile : System.Web.UI.Page
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection();
        SqlDataAdapter sda = new SqlDataAdapter();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                con.ConnectionString = @"Data Source=HARSHIL;Initial Catalog=saloon;User ID=sa;Password=Admin@123";
                con.Open();
                shoedata();
            }

        }
        private void shoedata()
        {
            lblerrmsg.Text = "";
            cmd.CommandText = "select * from tblRegister where username='" + Session["user"] + "' ";
            cmd.Connection = con;
            sda.SelectCommand = cmd;
            sda.Fill(ds);

            lblprofile.Text = ds.Tables[0].Rows[0]["name"].ToString();

            txt_name.Text = ds.Tables[0].Rows[0]["name"].ToString();
            txt_username.Text = ds.Tables[0].Rows[0]["username"].ToString();
            txt_email.Text = ds.Tables[0].Rows[0]["email"].ToString();
            txt_mno.Text = ds.Tables[0].Rows[0]["mobile"].ToString();


            DateTime dob = Convert.ToDateTime(ds.Tables[0].Rows[0]["dob"]);
            //txt_dob.Text = Convert.ToString(xdob);
            //string xdob  = ((Datetime)ds.Tables[0].Rows[0]["dob"]).ToString("dd/MM/yyyy");

            Label1.Text = string.Format("{0:mm/dd/yyyy}", Convert.ToDateTime(ds.Tables[0].Rows[0]["dob"]).ToShortDateString());

            string formate = dob.ToString("dd-MM-yyyy");
            txt_dob.Text = formate;
            //txt_dob.Text = ds.Tables[0].Rows[0]["dob"].ToString();
            //string cdob = Convert.ToString(dob);
            //txt_dob.Text = Convert.ToString(dob);
            //Response.Write(dob);

            //txt_dob.Text = DateTime.Parse();


            txt_password.Text = ds.Tables[0].Rows[0]["password"].ToString();

            cmd.CommandText = "select image from tblRegister where username='" + Session["user"] + "' ";
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    byte[] img = (byte[])dr["image"];
                    string image = Convert.ToBase64String(img, 0, img.Length);
                    Image1.ImageUrl = "data:image/png;base64," + image;
                }
            }
            else
            {

            }



        }

        





        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Response.Redirect("~/Login.aspx");
        }


        protected void upadte_register_Click(object sender, EventArgs e)
        {
            //string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(constr))
            //{
            //    con.Open();
            //    SqlCommand cmd = new SqlCommand("UpdateProfile", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@Action", "Update");
            //    cmd.Parameters.AddWithValue("@username", txt_username.Text);
            //    cmd.Parameters.AddWithValue("@name", txt_name.Text);
            //    cmd.Parameters.AddWithValue("@email", txt_email.Text);
            //    cmd.Parameters.AddWithValue("@mobile", txt_mno.Text);
            //    cmd.Parameters.AddWithValue("@dob", txt_dob.Text);
            //    cmd.Parameters.AddWithValue("@password", txt_password.Text);
            //    cmd.ExecuteNonQuery();
            //    con.Close();
            //    Response.Redirect("~/view/Profile.aspx");
            //}

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
           
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "new";
            cmd.Parameters.AddWithValue("@username", txt_username.Text);
            cmd.Parameters.AddWithValue("Action", "Update");
            cmd.Parameters.AddWithValue("@name", txt_name.Text);
            cmd.Parameters.AddWithValue("@email", txt_email.Text);
            cmd.Parameters.AddWithValue("@mobile", txt_mno.Text);
            cmd.Parameters.AddWithValue("@dob", txt_dob.Text);
            cmd.Parameters.AddWithValue("@password", txt_password.Text);
            cmd.Connection = con;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Response.Redirect("~/view/Profile.aspx");
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            //cmd.ExecuteNonQuery();
            //con.Close();
            //Response.Redirect("~/view/Profile.aspx");
            
        }

        protected void newupdate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/view/update.aspx");
        }
    }
}