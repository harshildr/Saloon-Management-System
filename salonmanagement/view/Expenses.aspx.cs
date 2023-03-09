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
    public partial class Expenses : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("select * from tblExpenses"))
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
            int eid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string name = (row.Cells[2].Controls[0] as TextBox).Text;
            string description = (row.Cells[3].Controls[0] as TextBox).Text;
            string expense = (row.Cells[4].Controls[0] as TextBox).Text;
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE tblExpenses SET name = @name, description = @description,expense=@expense WHERE eid = @eid"))
                {
                    cmd.Parameters.AddWithValue("@eid", eid);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@expense", expense);
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
            int eid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM tblExpenses WHERE eid = @eid"))
                {
                    cmd.Parameters.AddWithValue("@eid", eid);
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
                using (SqlCommand cmd = new SqlCommand("insert into tblExpenses(name,description,expense) values(@name,@description,@expense)"))
                {
                    cmd.Parameters.AddWithValue("@name", add_name.Text);
                    cmd.Parameters.AddWithValue("@description", add_desc.Text);
                    cmd.Parameters.AddWithValue("@expense", add_ex.Text);
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