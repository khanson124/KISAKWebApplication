using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.UI;

namespace HelpDeskApplicationWeb
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ErrorMessageLabel.Visible = false;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (ValidateUser(username, password))
            {
                string userRole = GetUserRole(username);
                int userID = GetUserID(username);
                Session["UserID"] = userID;

                // Generate a unique session token
                var sessionToken = Guid.NewGuid().ToString();
                Session["SessionToken"] = sessionToken;

                // Also store the session token in the user's cookie
                Response.Cookies.Add(new HttpCookie("SessionToken", sessionToken));

                if (userRole == "admin")
                {
                    // Redirect to admin dashboard
                    Response.Redirect("~/AdminDashboard.aspx");
                }
                else if (userRole == "agent")
                {
                    // Redirect to agent dashboard
                    Response.Redirect("~/AgentDashboard.aspx");
                }
                else if (userRole == "support")
                {
                    // Redirect to agent dashboard
                    Response.Redirect("~/SupportDashboard.aspx");
                }
                else
                {
                    ShowError("Invalid role. Please try again.");
                }
            }
            else
            {
                ShowError("Invalid username or password. Please try again.");
            }
        }


        private bool ValidateUser(string username, string password)
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=HELPDESK;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE email = @email AND password = @password";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@email", username);
                    command.Parameters.AddWithValue("@password", password);

                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private string GetUserRole(string username)
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=HELPDESK;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT role FROM Users WHERE email = @email";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@email", username);

                    object result = command.ExecuteScalar();
                    return result?.ToString();
                }
            }
        }

        private int GetUserID(string username)
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=HELPDESK;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT user_id FROM Users WHERE email = @email";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@email", username);

                    object result = command.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
        }


        private void ShowError(string message)
        {
            ErrorMessageLabel.Text = message;
            ErrorMessageLabel.Visible = true;
        }
    }
}
