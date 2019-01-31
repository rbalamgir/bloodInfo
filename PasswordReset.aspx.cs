using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;

namespace BloodBank
{
    public partial class PasswordReset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void resetPasswordButton_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(CS))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlDataAdapter da = new SqlDataAdapter("spResetPassword", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                da.SelectCommand.Parameters.AddWithValue("@email", email.Text);

                int checkedValue = (int)da.SelectCommand.ExecuteScalar();
                if (checkedValue == -1)
                {
                    lblStatus1.Text = "Incorrect Email address";
                    lblStatus1.ForeColor = System.Drawing.Color.Red;
                }

                else
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    string password = ds.Tables[0].Rows[0]["Password"].ToString();
                    sendPassword(password,email.Text);
                    lblStatus1.Text = "An email has been sent to your email address";
                    lblStatus1.ForeColor = System.Drawing.Color.Green;
                }

            }
        }

        protected void sendPassword(string password, string email)
        {
            MailMessage mailMessage = new MailMessage();

            mailMessage.From = new MailAddress("rakib538alamgir@gmail.com");    //developer mail
            mailMessage.To.Add(email);  //user mail id, provided into registration form
            mailMessage.Subject = "Send Mail via SMTP";
            mailMessage.Body = "Dear user your password is " + password;


            SmtpClient smtp = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new System.Net.NetworkCredential("rakib538alamgir@gmail.com", "password"),
                EnableSsl = true,
            };

            smtp.Send(mailMessage);
            
        }
    }
}