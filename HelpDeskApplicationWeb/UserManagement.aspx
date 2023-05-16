<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserManagement.aspx.cs" Inherits="HelpDeskApplicationWeb.UserManagement" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Management</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"/>
    <link rel="stylesheet" type="text/css" href="~/CSS/usermanagement.css" />

</head>
<body>
     <nav class="navbar navbar-expand-lg navbar-light bg-light">
      <a class="navbar-brand" href="AdminDashboard.aspx">KISAK</a>
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
            <a class="nav-link" href="Login.aspx">Logout</a>
          </li>
        </ul>
      </div>
    </nav>
    <form id="form1" runat="server">
        <div class="container">
            <h1>User Management</h1>

            <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped" AutoGenerateColumns="False" DataKeyNames="user_id">
                <Columns>
                    <asp:BoundField DataField="user_id" HeaderText="User ID" ReadOnly="True" />
                    <asp:BoundField DataField="name" HeaderText="Name" />
                    <asp:BoundField DataField="email" HeaderText="Email" />
                    <asp:BoundField DataField="phone_number" HeaderText="Phone Number" />
                    <asp:BoundField DataField="role" HeaderText="Role" />
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Label ID="nameLabel" runat="server" Text="Name:" AssociatedControlID="name"></asp:Label>
            <asp:TextBox ID="name" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="emailLabel" runat="server" Text="Email:" AssociatedControlID="email"></asp:Label>
            <asp:TextBox ID="email" runat="server"></asp:TextBox>
            <br />

          <div class="form-group">
    <label for="txtPassword" runat="server">Password:</label>
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is required." ForeColor="Red"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password must be 8 to 15 characters long and contain at least one digit, one lowercase letter, one uppercase letter, and one special character." ValidationExpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*\W).{8,15}$" ForeColor="Red"></asp:RegularExpressionValidator>
</div>

<div class="form-group">
    <label for="txtConfirmPassword" runat="server">Confirm Password:</label>
    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="Confirm Password is required." ForeColor="Red"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtConfirmPassword" ControlToCompare="txtPassword" ErrorMessage="Passwords do not match." ForeColor="Red"></asp:CompareValidator>
</div>



            <asp:Label ID="phoneNumberLabel" runat="server" Text="Phone Number:" AssociatedControlID="phone_number"></asp:Label>
            <asp:TextBox ID="phone_number" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="roleLabel" runat="server" Text="Role:" AssociatedControlID="role"></asp:Label>
            <asp:DropDownList ID="role" runat="server" CssClass="form-control">
                <asp:ListItem Value="support">Support</asp:ListItem>
                <asp:ListItem Value="agent">Agent</asp:ListItem>
                <asp:ListItem Value="admin">Admin</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="retrieveUserIdLabel" runat="server" Text="Enter User ID to retrieve or delete:" AssociatedControlID="retrieveUserId"></asp:Label>
            <asp:TextBox ID="retrieveUserId" runat="server"></asp:TextBox>
            <asp:Label ID="feedbackLabel" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <asp:Button ID="AddUserBtn" runat="server" Text="Add User" CssClass="btn btn-primary" OnClick="AddUserBtn_Click" />
            <asp:Button ID="RetrieveUserBtn" runat="server" Text="Retrieve User" CssClass="btn btn-primary" OnClick="RetrieveUserBtn_Click" />
            <asp:Button ID="UpdateUserBtn" runat="server" Text="Update User" CssClass="btn btn-primary" OnClick="UpdateUserBtn_Click" />
            <asp:Button ID="DeleteUserBtn" runat="server" Text="Delete User" CssClass="btn btn-primary" OnClick="DeleteUserBtn_Click" />
        </div>
    </form>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
