using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;

namespace BloodBank
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void confirmPasswordButton_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(CS))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string oldpassword = FormsAuthentication.HashPasswordForStoringInConfigFile(oldPassword.Text, "SHA1");

                SqlDataAdapter da = new SqlDataAdapter("select * from bloodBank where UserName = @uesername",conn);
                

                //da.SelectCommand.Parameters.AddWithValue("@username", Session["userName"]);
                //int value = da.SelectCommand.ExecuteNonQuery();

                DataSet ds = new DataSet();
                da.Fill(ds);
                string existingPassword = ds.Tables[0].Rows[0]["Password"].ToString();

                if (existingPassword.Equals(oldpassword))
                {
                    string newPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(newpassword.Text, "SHA1");

                    da.UpdateCommand.CommandText = "update bloodBank set Password = @newPassword where UserName = @userName";
                    da.UpdateCommand.Parameters.AddWithValue("@newPassword", newpassword.Text);
                    da.UpdateCommand.Parameters.AddWithValue("@userName", Session["userName"]);
                    da.UpdateCommand.ExecuteNonQuery();
                }

                else
                {

                }
            }
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {

        }
    }
}