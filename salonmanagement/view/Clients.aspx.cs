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
    public partial class Clients : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                lblerrmsg.Text = "To Show Data Click Here";

            }
            else
            {
                lblname.Text = "Welcome " + Session["user"];
                lblerrmsg.Text = "";
                if (!this.IsPostBack)
                {
                    this.BindGrid();
                }
            }
            

        }
        private void BindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from tblClient"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }
                }
            }
        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            GridView1.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int cid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string cname = (row.Cells[2].Controls[0] as TextBox).Text;
            string cusername = (row.Cells[3].Controls[0] as TextBox).Text;
            string cemail = (row.Cells[4].Controls[0] as TextBox).Text;
            string cphone = (row.Cells[5].Controls[0] as TextBox).Text;
            DateTime cdob = Convert.ToDateTime((row.Cells[6].Controls[0] as TextBox).Text);
            //string cdob = (row.Cells[6].Controls[0] as TextBox).Text;
            string cpassword = (row.Cells[7].Controls[0] as TextBox).Text;
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE tblServices SET cname = @cname, cusername = @cusername, cemail = @cemail, cphone = @cphone, cdob = @cdob, cpassword = @cpassword WHERE cid = @cid"))
                {
                    cmd.Parameters.AddWithValue("@cid", cid);
                    cmd.Parameters.AddWithValue("@cname", cname);
                    cmd.Parameters.AddWithValue("@cusername", cusername);
                    cmd.Parameters.AddWithValue("@cemail", cemail);
                    cmd.Parameters.AddWithValue("@cphone", cphone);
                    cmd.Parameters.AddWithValue("@cdob", cdob);
                    cmd.Parameters.AddWithValue("@cpassword", cpassword);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            GridView1.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridView1.EditIndex)
            {
                (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int cid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM tblClient WHERE cid = @cid"))
                {
                    cmd.Parameters.AddWithValue("@cid", cid);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.BindGrid();
        }

        private void adddata()
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("insert into tblClient(cname,cusername,cemail,cphone,cdob,cpassword) values(@cname,@cusername,@cemail,@cphone,@cdob,@cpassword)"))
                {
                    cmd.Parameters.AddWithValue("@cname", add_name.Text);
                    cmd.Parameters.AddWithValue("@cusername", add_username.Text);
                    cmd.Parameters.AddWithValue("@cemail", add_email.Text);
                    cmd.Parameters.AddWithValue("@cphone", add_phone.Text);
                    cmd.Parameters.AddWithValue("@cdob", add_date.Text);
                    cmd.Parameters.AddWithValue("@cpassword", add_password.Text);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();

                    con.Close();

                }
            }
            this.BindGrid();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            adddata();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Response.Redirect("~/Login.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Response.Redirect("~/Login.aspx");
        }
    }
}