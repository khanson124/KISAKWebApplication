using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace HelpDeskApplicationWeb

{
    public partial class AgentDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int userID = GetLoggedInUserID(); // Get the user ID from the session.
                DataTable ticketData = GetUserTicketData(userID);
                GridView1.DataSource = ticketData;
                GridView1.DataBind();
            }
        }

        private int GetLoggedInUserID()
        {
            // Assuming you have stored the user ID in the session as "UserID".
            object userID = Session["UserID"];
            return userID != null ? Convert.ToInt32(userID) : -1;
        }

        protected DataTable GetUserTicketData(int userID)
        {
            if (userID < 0)
            {
                // Handle the case when no valid user ID is provided, for example, redirect to the login page.
                Response.Redirect("~/Login.aspx");
                return null;
            }

            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=HELPDESK;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Tickets WHERE user_id = @user_id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@user_id", userID);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable data = new DataTable();
                        adapter.Fill(data);
                        return data;
                    }
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
                // Clear the session data
                Session.Clear();

                // Redirect the user to the login page
                Response.Redirect("~/Login.aspx");

        }
    }
}
