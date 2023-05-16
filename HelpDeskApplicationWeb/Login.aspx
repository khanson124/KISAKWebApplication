<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HelpDeskApplicationWeb.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-md-6">
                    <div class="card mt-5">
                        <div class="card-header">
                            <h3>Login</h3>
                        </div>
                        <div class="card-body">
                            <div class="form-group">
                                <asp:Label ID="ErrorMessageLabel" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                <label for="txtUsername" runat="server">Username:</label>
                                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername" ErrorMessage="Username is required." ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtUsername" ErrorMessage="Invalid email." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>

                            <div class="form-group">
                                <label for="txtPassword" runat="server">Password:</label>
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is required." ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
