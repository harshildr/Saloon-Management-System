using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace salonmanagement.view
{
    public partial class Appointments : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("select * from tblApointment"))
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
            int aid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string cid = (row.Cells[2].Controls[0] as TextBox).Text;
            string cname = (row.Cells[3].Controls[0] as TextBox).Text;
            string cnumber = (row.Cells[4].Controls[0] as TextBox).Text;
            DateTime adate = Convert.ToDateTime((row.Cells[5].Controls[0] as TextBox).Text);
            
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE tblApointment SET cid = @cid, cname = @cname, cnumber=@cnumber,adate=@adate WHERE aid = @aid"))
                {
                    cmd.Parameters.AddWithValue("@aid", aid);
                    cmd.Parameters.AddWithValue("@cid", cid);
                    cmd.Parameters.AddWithValue("@cname", cname);
                    cmd.Parameters.AddWithValue("@cnumber", cnumber);
                    cmd.Parameters.AddWithValue("@adate", adate);
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
            int aid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM tblApointment WHERE aid = @aid"))
                {
                    cmd.Parameters.AddWithValue("@aid", aid);
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
                using (SqlCommand cmd = new SqlCommand("insert into tblApointment(cid,cname,cnumber,adate) values(@cid,@cname,@cnumber,@adate)"))
                {
                    cmd.Parameters.AddWithValue("@cid", add_cid.Text);
                    cmd.Parameters.AddWithValue("@cname", add_cname.Text);
                    cmd.Parameters.AddWithValue("@cnumber", add_cnumber.Text);
                    cmd.Parameters.AddWithValue("@adate", add_adate.Text);
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