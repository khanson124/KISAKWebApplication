using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace HelpDeskApplicationWeb
{
    public partial class ManageTickets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=HELPDESK;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Tickets WHERE status = 'Pending'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        GridView1.DataSource = dataTable;
                        GridView1.DataBind();
                    }
                }
            }
        }

        protected void AddTicketBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateTicket.aspx");
        }

        protected void UpdateTicketBtn_Click(object sender, EventArgs e)
        {
            // Implement your update logic here
        }

        protected void DeleteTicketBtn_Click(object sender, EventArgs e)
        {
            // Implement your delete logic here
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Set the edit index.
            GridView1.EditIndex = e.NewEditIndex;
            // Bind data to the GridView control.
            BindData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Retrieve the row index stored in the CommandArgument property.
            int index = e.RowIndex;

            // Retrieve the row that contains the button from the Rows collection.
            GridViewRow row = GridView1.Rows[index];

            // Retrieve the updated data from the row.
            string ticketId = GridView1.DataKeys[index].Value.ToString();
            string subject = ((TextBox)row.Cells[1].Controls[0]).Text;
            string status = ((TextBox)row.Cells[2].Controls[0]).Text;
            string agentId = ((TextBox)row.Cells[3].Controls[0]).Text;

            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=HELPDESK;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Tickets SET subject = @Subject, status = @Status, agent_id = @AgentId WHERE ticket_id = @TicketId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Subject", subject);
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@AgentId", agentId);
                    command.Parameters.AddWithValue("@TicketId", ticketId);
                    command.ExecuteNonQuery();
                }
            }

            // Reset the edit index.
            GridView1.EditIndex = -1;

            // Bind data to the GridView control.
            BindData();
        }


        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Reset the edit index.
            GridView1.EditIndex = -1;
            // Bind data to the GridView control.
            BindData();
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=HELPDESK;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Tickets WHERE ticket_id = @TicketId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Get the ticket_id of the row being deleted
                    string ticketId = GridView1.DataKeys[e.RowIndex].Value.ToString();

                    command.Parameters.AddWithValue("@TicketId", ticketId);
                    command.ExecuteNonQuery();
                }
            }

            // Rebind the data to refresh the GridView
            BindData();
        }

    }
}
