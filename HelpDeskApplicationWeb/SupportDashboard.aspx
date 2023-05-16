<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupportDashboard.aspx.cs" Inherits="HelpDeskApplicationWeb.SupportDashboard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Dashboard</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"/>
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
            <a class="nav-link" href="ManageTickets.aspx">Manage Tickets</a>
          </li>
             <li class="nav-item">
            <a class="nav-link" href="Profile">Profile</a>
          </li>
        </ul>
      </div>
    </nav>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Welcome to the Tech Support Dashboard</h1>
            
            <h2>Recent Tickets</h2>
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="ticket_id" HeaderText="Ticket ID" />
                    <asp:BoundField DataField="subject" HeaderText="Title" />
                    <asp:BoundField DataField="description" HeaderText="Description" />
                    <asp:BoundField DataField="status" HeaderText="Status" />
                    <asp:BoundField DataField="date_created" HeaderText="Created Date" />
                    <asp:BoundField DataField="date_updated" HeaderText="Updated Date" />
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="btn btn-primary"/>
        </div>
    </form>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
