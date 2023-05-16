using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace HelpDeskApplicationWeb
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProfileData();
            }
        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("LoginPage.aspx");
        }

        private void LoadProfileData()
        {
            int userID = (int)Session["UserID"];
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=HELPDESK;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT name, email, role FROM Users WHERE user_id = @userID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userID", userID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usernameLabel.Text = reader["name"].ToString();
                            emailLabel.Text = reader["email"].ToString();
                            roleLabel.Text = reader["role"].ToString();
                        }
                    }
                }
            }
        }
    }
}