using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace HelpDeskApplicationWeb
{
    public partial class SupportDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable ticketData = GetTicketData();
                GridView1.DataSource = ticketData;
                GridView1.DataBind();
            }
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Clear the session data
            Session.Clear();

            // Redirect the user to the login page
            Response.Redirect("~/Login.aspx");

        }
        protected DataTable GetTicketData()
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=HELPDESK;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Tickets";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable data = new DataTable();
                        adapter.Fill(data);
                        return data;
                    }
                }
            }
        }
    }
}
