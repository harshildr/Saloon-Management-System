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
    public partial class AdminDashboard : System.Web.UI.Page
    {
        Models.Functions Con;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                lblerrmsg.Text = "To Show Data Click Here";

            }
            else
            {
                lblname.Text = "Welcome " + Session["user"] ;
                lblerrmsg.Text = "";
                Con = new Models.Functions();
                ShowApointment();
                totalApointmentCount();
                totalServicesCount();
                totalClientCount();
                totalExpenses();
                totalPurchases();
            }
                
        }
        private void ShowApointment()
        {
            string Query = "select cid, cname, cnumber, adate from tblApointment";
            GridView1.DataSource = Con.GetData(Query);
            GridView1.DataBind();
        }
        private void totalApointmentCount()
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT COUNT(*) As count from tblApointment";
                using (SqlCommand cmd = new SqlCommand(query,con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    object o = cmd.ExecuteScalar();
                    if (o != null)
                    {
                        lblTotalcCount.Text = o.ToString();
                    }
                    con.Close();
                }
            }
        }

        private void totalServicesCount()
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT COUNT(*) As count from tblServices";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    object o = cmd.ExecuteScalar();
                    if (o != null)
                    {
                        lblTotalServices.Text = o.ToString();
                    }
                    con.Close();
                }
            }
        }

        private void totalClientCount()
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT COUNT(*) As count from tblClient";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    object o = cmd.ExecuteScalar();
                    if (o != null)
                    {
                        lblTotalClients.Text = o.ToString();
                    }
                    con.Close();
                }
            }
        }

        private void totalExpenses()
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT SUM(expense) As sum from tblExpenses";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    object o = cmd.ExecuteScalar();
                    if (o != null)
                    {
                        lblTotalExpenses.Text = o.ToString();
                        lblTodayExpenses.Text = o.ToString();
                    }
                    con.Close();
                }
            }
        }

        private void totalPurchases()
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT SUM(pprice) As sum from tblPurchases";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    object o = cmd.ExecuteScalar();
                    if (o != null)
                    {
                        lblTotalPurchases.Text = o.ToString();
                    }
                    con.Close();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Response.Redirect("~/Login.aspx");
        }
    }
}