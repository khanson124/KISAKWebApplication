using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using LibraryHelpDesk;

namespace HelpDeskApplicationWeb
{
    public partial class CreateTicket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=HELPDESK;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Assuming your category table is named "Categories" and has fields "CategoryId" and "CategoryName"
                    string sql = "SELECT category_id, category_name FROM Categories";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        // Bind the data to the dropdown list
                        CategoryDropDown.DataSource = reader;
                        CategoryDropDown.DataTextField = "category_name"; // the name you want to display
                        CategoryDropDown.DataValueField = "category_id"; // the underlying value
                        CategoryDropDown.DataBind();
                    }
                }

                // Add a default item at the top of the dropdown.
                CategoryDropDown.Items.Insert(0, new ListItem("--Select Category--", "0"));
            }
        }


        protected void SubmitButton_Click(object sender, EventArgs e)
        {
        

     /*       HelpDesk.ProblemCategory category = (HelpDesk.ProblemCategory)Enum.Parse(typeof(HelpDesk.ProblemCategory), TypeDropDown.SelectedItem.Text);
            HelpDesk.ProblemSeverity severity = (HelpDesk.ProblemSeverity)Enum.Parse(typeof(HelpDesk.ProblemSeverity), SeverityDropDown.SelectedItem.Text);
            HelpDesk.PriorityLevel priority = HelpDesk.PriorityHelper.DeterminePriority(category, severity);*/
            string status = "Pending";
            int agentId = HelpDesk.GetNextSupportAgentId();
            int userID = -1;
            if (Session["UserID"] != null)
            {
                userID = (int)Session["UserID"];
            }
            else
            {
                // Handle the case where the userID is not available
                ErrorLabel.Text = "User is not logged in.";
                ErrorLabel.Visible = true;
                return;
            }


            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=HELPDESK;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int category_id = Convert.ToInt32(CategoryDropDown.SelectedIndex);
                connection.Open();
                string priority = PriorityDropDown.SelectedValue;

                string sql = "INSERT INTO Tickets (subject, description, priority, status, agent_id, user_id, date_created, date_updated, category_id) VALUES (@subject, @description, @priority, @status, @agent_id, @user_id, @date_created, @date_updated, @category_id)";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@subject", SubjectTextBox.Text);
                    cmd.Parameters.AddWithValue("@description", DescriptionTextBox.Text);
                    cmd.Parameters.AddWithValue("@priority", priority.ToString());
                    cmd.Parameters.AddWithValue("@agent_id", agentId);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@user_id", userID); 
                    cmd.Parameters.AddWithValue("@date_created", DateTime.Parse(DueDateTextBox.Text));
                    cmd.Parameters.AddWithValue("@date_updated", DateTime.Now);
                    cmd.Parameters.AddWithValue("@category_id", category_id);
                    cmd.ExecuteNonQuery();
                }
            }

            // Show success message
            // replace the MessageBox with a label on your form
            SuccessLabel.Text = "Ticket saved successfully!";
        }



        protected void TypeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProblemDropDown.Items.Clear();

            switch (TypeDropDown.SelectedValue)
            {
                case "Hardware":
                    ProblemDropDown.Items.Add(new ListItem("Computer won't turn on"));
                    ProblemDropDown.Items.Add(new ListItem("Monitor won't display an image"));
                    ProblemDropDown.Items.Add(new ListItem("Printer won't print"));
                    ProblemDropDown.Items.Add(new ListItem("Keyboard or mouse isn't working"));
                    break;
                case "Software":
                    ProblemDropDown.Items.Add(new ListItem("Application won't launch"));
                    ProblemDropDown.Items.Add(new ListItem("Error message appears when using an application"));
                    ProblemDropDown.Items.Add(new ListItem("File won't open or save"));
                    ProblemDropDown.Items.Add(new ListItem("Application is running slowly"));
                    break;

                case "Network":
                    ProblemDropDown.Items.Add(new ListItem("Unable to connect to the internet"));
                    ProblemDropDown.Items.Add(new ListItem("Slow internet speeds"));
                    ProblemDropDown.Items.Add(new ListItem("Can't access network resources"));
                    ProblemDropDown.Items.Add(new ListItem("Firewall is blocking access to a website or application"));  
                    break;
                case "Other":
                    ProblemDropDown.Items.Add(new ListItem("Account locked out or password reset needed"));
                    ProblemDropDown.Items.Add(new ListItem("Request for new software to be installed"));
                    ProblemDropDown.Items.Add(new ListItem("General IT questions or inquiries"));
                    ProblemDropDown.Items.Add(new ListItem("Request for new hardware to be purchased"));
                    break;
            }
        }
    }
}