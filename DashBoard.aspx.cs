using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace BloodBank
{
    public partial class DashBoard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userName"] == null)
            {
                Response.Redirect("~/Login/Login.aspx");
            }
            
            else
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(CS))
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    SqlDataAdapter da = new SqlDataAdapter("select FirstName,LastName,Address,Gender,BloodGroup,E_mail,ContactNumber from bloodBank", conn);
                    DataSet ds = new DataSet();

                    da.Fill(ds);

                    DashboardGridView.DataSource = ds;
                    DashboardGridView.DataBind();
                }
            }
        }
        

        protected void Search_Button_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(CS))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlDataAdapter da = new SqlDataAdapter("spSearchBy", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                da.SelectCommand.Parameters.AddWithValue("@bloodGroupSearch", search.Text + "%");

                DataSet ds = new DataSet();
                da.Fill(ds);

                DashboardGridView.DataSource = ds;
                DashboardGridView.DataBind();
            }
        }

        
    } 
}