<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageTickets.aspx.cs" Inherits="HelpDeskApplicationWeb.ManageTickets" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Tickets</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
</head>
<body>
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
      <a class="navbar-brand" href="#">KISAK</a>
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarNav">
        <ul class="navbar-nav">
          <li class="nav-item">
            <a class="nav-link" href="UserManagement.aspx">Manage Users</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="#">Manage Tickets</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="#">Reports</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="#">Settings</a>
          </li>
             <li class="nav-item">
            <a class="nav-link" href="Profile">Profile</a>
          </li>
        </ul>
      </div>
    </nav>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Manage Tickets</h1>

          <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped" AutoGenerateColumns="False" DataKeyNames="ticket_id"
            OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting">
            <Columns>
                <asp:BoundField DataField="ticket_id" HeaderText="Ticket ID" ReadOnly="True" />
                <asp:BoundField DataField="subject" HeaderText="Subject" />
                <asp:BoundField DataField="status" HeaderText="Status" />
                <asp:BoundField DataField="agent_id" HeaderText="Assigned To" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>

            <br />
   
            <asp:Label ID="statusLabel" runat="server" Text="Status:" AssociatedControlID="status"></asp:Label>
            <asp:DropDownList ID="status" runat="server" CssClass="form-control">
                <asp:ListItem Value="open">Open</asp:ListItem>
                <asp:ListItem Value="in_progress">In Progress</asp:ListItem>
                <asp:ListItem Value="closed">Closed</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="assignedToLabel" runat="server" Text="Agent ID:" AssociatedControlID="agent_id"></asp:Label>
            <asp:TextBox ID="agent_id" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="AddTicketBtn" runat="server" Text="Add Ticket" CssClass="btn btn-primary" OnClick="AddTicketBtn_Click" />
        </div>
    </form>
</body>
</html>
