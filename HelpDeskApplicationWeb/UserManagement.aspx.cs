using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace HelpDeskApplicationWeb
{
    public partial class UserManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void UpdateUserBtn_Click(object sender, EventArgs e)
        {
            int userId;
            if (!int.TryParse(retrieveUserId.Text, out userId))
            {
                feedbackLabel.Text = "Invalid user ID.";
                return;
            }

            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=HELPDESK;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string updateUserQuery = "UPDATE users SET name = @name, email = @email, phone_number = @phone_number, role = @role WHERE user_id = @userId";
                using (SqlCommand command = new SqlCommand(updateUserQuery, connection))
                {
                    command.Parameters.AddWithValue("@name", name.Text);
                    command.Parameters.AddWithValue("@email", email.Text);
                    command.Parameters.AddWithValue("@phone_number", phone_number.Text);
                    command.Parameters.AddWithValue("@role", role.SelectedValue);
                    command.Parameters.AddWithValue("@userId", userId);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Refresh the GridView to reflect the update.
                        GridView1.DataBind();
                        feedbackLabel.ForeColor = System.Drawing.Color.Green;
                        feedbackLabel.Text = "User successfully updated.";
                    }
                    else
                    {
                        feedbackLabel.Text = "User not found.";
                    }
                }
            }
        }

        protected void RetrieveUserBtn_Click(object sender, EventArgs e)
        {
            int userId;
            if (!int.TryParse(retrieveUserId.Text, out userId))
            {
                // Handle invalid user ID (not a number)
                return;
            }

            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=HELPDESK;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM users WHERE user_id = @userId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Populate the form fields
                            name.Text = reader["name"].ToString();
                            email.Text = reader["email"].ToString();
                            phone_number.Text = reader["phone_number"].ToString();
                            role.SelectedValue = reader["role"].ToString();
                        }
                        else
                        {
                            // Handle user not found
                        }
                    }
                }
            }
        }

        protected void DeleteUserBtn_Click(object sender, EventArgs e)
        {
            int userId;
            if (!int.TryParse(retrieveUserId.Text, out userId))
            {
                feedbackLabel.Text = "Invalid user ID.";
                return;
            }

            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=HELPDESK;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string deleteUserQuery = "DELETE FROM users WHERE user_id = @userId";
                using (SqlCommand command = new SqlCommand(deleteUserQuery, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Refresh the GridView to reflect the deletion.
                        GridView1.DataBind();
                        feedbackLabel.ForeColor = System.Drawing.Color.Green;
                        feedbackLabel.Text = "User successfully deleted.";
                    }
                    else
                    {
                        feedbackLabel.Text = "User not found.";
                    }
                }
            }
        }


        protected void AddUserBtn_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=HELPDESK;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string addUserQuery = "INSERT INTO users (name, email, password, phone_number, role) VALUES (@name, @email, @password, @phone_number, @role)";

                using (SqlCommand command = new SqlCommand(addUserQuery, connection))
                {
                    command.Parameters.AddWithValue("@name", name.Text);
                    command.Parameters.AddWithValue("@email", email.Text);
                    command.Parameters.AddWithValue("@password", txtPassword.Text);
                    command.Parameters.AddWithValue("@phone_number", phone_number.Text);
                    command.Parameters.AddWithValue("@role", role.SelectedValue);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Refresh the GridView to show the new user.
                        GridView1.DataBind();
                    }
                }
            }
        }


    }
}
