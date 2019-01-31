using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;

namespace BloodBank
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

            protected void Login_Button_Click(object sender, EventArgs e)
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(CS))
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    SqlDataAdapter da = new SqlDataAdapter("spUserAuthentication", conn);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    string hashPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(password.Text, "SHA1");

                da.SelectCommand.Parameters.AddWithValue("@userName", userName.Text);
                da.SelectCommand.Parameters.AddWithValue("@password", hashPwd);

                //da.SelectCommand.Parameters.AddWithValue("@userName", userName.Text);
                //da.SelectCommand.Parameters.Add(hashPwd);
                
                //da.SelectCommand.Parameters.Add(hashPwd);

                    int returnValue = (int)da.SelectCommand.ExecuteScalar();

                    if (returnValue == 1)
                    {
                        Session["userName"] = userName.Text;
                        Response.Redirect("~/DashBoard.aspx");
                    }

                    else
                    {
                        lblstatus1.Text = "Uername or Password is not matched";
                    }


                    /*if (username == userName.Text && pwd == hashPwd)
                    {

                        
                        Response.Redirect("~/WebForm1.aspx");
                    }

                    */
                }
            }
        }
    }