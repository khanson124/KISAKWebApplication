<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="HelpDeskApplicationWeb.Profile" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Profile</title>
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
            <a class="nav-link" href="ManageTickets.aspx">Manage Tickets</a>
          </li>
             <li class="nav-item">
            <a class="nav-link" href="AdminProfile">Profile</a>
          </li>
        </ul>
      </div>
    </nav>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Profile</h1>
            <div class="row">
                <div class="col-md-6">
                    <label for="username">Username:</label>
                    <asp:Label ID="usernameLabel" runat="server" CssClass="form-control"></asp:Label>
                </div>
                <div class="col-md-6">
                    <label for="email">Email:</label>
                    <asp:Label ID="emailLabel" runat="server" CssClass="form-control"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <label for="role">Role:</label>
                    <asp:Label ID="roleLabel" runat="server" CssClass="form-control"></asp:Label>
                </div>
            </div>
            <asp:Button ID="logoutButton" runat="server" Text="Logout" CssClass="btn btn-primary" OnClick="logoutButton_Click" />
        </div>
    </form>
</body>
</html>
