using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.Security;

namespace BloodBank
{
    public partial class BloodBank_SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(CS))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlDataAdapter da = new SqlDataAdapter("spInsertUserById", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                if (Page.IsValid)
                {
                    
                    da.SelectCommand.Parameters.AddWithValue("@firstName", firstName.Text);
                    da.SelectCommand.Parameters.AddWithValue("@lastName", lastName.Text);
                    da.SelectCommand.Parameters.AddWithValue("@userName", userName.Text);
                    da.SelectCommand.Parameters.AddWithValue("@address", address.Text);
                    da.SelectCommand.Parameters.AddWithValue("@gender", dropDownList.SelectedValue);
                    da.SelectCommand.Parameters.AddWithValue("@bloodGroup", bloodGroup.Text);
                    da.SelectCommand.Parameters.AddWithValue("@e_mail", email.Text);
                    da.SelectCommand.Parameters.AddWithValue("@contactNumber", contactNumber.Text);

                    string hashPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(password.Text,"SHA1");
                    string retypedHasPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(retypedPassword.Text, "SHA1");

                    da.SelectCommand.Parameters.AddWithValue("@password", hashPwd);
                    da.SelectCommand.Parameters.AddWithValue("@retypedPassword", retypedHasPwd);
                    

                    SqlParameter outPutParameter = new SqlParameter
                    {
                        ParameterName = "@id",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    };

                    da.SelectCommand.Parameters.Add(outPutParameter);

                    
                    int returnValue = (int)da.SelectCommand.ExecuteScalar();
                    
                    if (returnValue == -1)
                    {
                        lblStatus.Text = "This username is already taken, pls choose another one u piece of shit";
                        lblStatus.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        Response.Redirect("~/Login/Login.aspx");
                    }
                }
            }

        }
    }
}