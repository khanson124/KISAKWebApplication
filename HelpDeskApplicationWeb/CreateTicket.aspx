<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateTicket.aspx.cs" Inherits="HelpDeskApplicationWeb.CreateTicket" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Ticket</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
</head>
<body>
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <a class="navbar-brand" href="AgentDashboard.aspx">KISAK</a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNav">
            <ul class="navbar-nav">
                <li class="nav-item">
                    <a class="nav-link" href="#">My Tickets</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#">Profile</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#">About</a>
                </li>
            </ul>
        </div>
    </nav>
    <form id="form1" runat="server" class="container">
        <div class="row justify-content-center">
            <div class="col-sm-6">
                <h2>Create a New Ticket</h2>
                <div class="form-group">
                    <asp:Label ID="SubjectLabel" runat="server" Text="Subject:" AssociatedControlID="SubjectTextBox" class="form-control-label" />
                    <asp:TextBox ID="SubjectTextBox" runat="server" CssClass="form-control" />
                </div>
                <div class="form-group">
                    <asp:Label ID="DescriptionLabel" runat="server" Text="Description:" AssociatedControlID="DescriptionTextBox" class="form-control-label" />
                    <asp:TextBox ID="DescriptionTextBox" runat="server" TextMode="MultiLine" CssClass="form-control" />
                </div>
                <div class="form-group">
                    <asp:Label ID="TypeLabel" runat="server" Text="Request Type:" AssociatedControlID="TypeDropDown" class="form-control-label" />
                    <asp:DropDownList ID="TypeDropDown" runat="server" AutoPostBack="True" OnSelectedIndexChanged="TypeDropDown_SelectedIndexChanged" CssClass="form-control">
                        <asp:ListItem Value="Hardware">Hardware</asp:ListItem>
                        <asp:ListItem Value="Software">Software</asp:ListItem>
                        <asp:ListItem Value="Network">Network</asp:ListItem>
                        <asp:ListItem Value="Other">Other</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <asp:Label ID="ProblemLabel" runat="server" Text="Specific Problem:" AssociatedControlID="ProblemDropDown" class="form-control-label" />
                    <asp:DropDownList ID="ProblemDropDown" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <asp:Label ID="PriorityLabel" runat="server" Text="Priority:" AssociatedControlID="PriorityDropDown" class="form-control-label" />
                    <asp:DropDownList ID="PriorityDropDown" runat="server" CssClass="form-control">
                        <asp:ListItem Value="High">High</asp:ListItem>
                        <asp:ListItem Value="Medium">Medium</asp:ListItem>
                        <asp:ListItem Value="Low">Low</asp:ListItem>
                    </asp:DropDownList>
                </div>
                 <div class="form-group">
                    <asp:Label ID="SeverityLabel" runat="server" Text="Severity:" AssociatedControlID="SeverityDropDown" class="form-control-label" />
                    <asp:DropDownList ID="SeverityDropDown" runat="server" CssClass="form-control">
                        <asp:ListItem Value="High">High</asp:ListItem>
                        <asp:ListItem Value="Medium">Medium</asp:ListItem>
                        <asp:ListItem Value="Low">Low</asp:ListItem>
                    </asp:DropDownList>
                </div>
                 <div class="form-group">
                    <asp:Label ID="Category" runat="server" Text="Category:" AssociatedControlID="CategoryDropDown" class="form-control-label" />
                    <asp:DropDownList ID="CategoryDropDown" runat="server" CssClass="form-control">
                      
                    </asp:DropDownList>
                </div>
                <div class="form-group">
    <asp:Label ID="DueDateLabel" runat="server" Text="Due Date:" AssociatedControlID="DueDateTextBox" class="form-control-label" />
    <asp:TextBox ID="DueDateTextBox" runat="server" CssClass="form-control" />
</div>

                <div class="form-group">
    <asp:Label ID="SuccessLabel" runat="server" CssClass="alert alert-success" Visible="false" />
</div>
<div class="form-group">
    <asp:Label ID="ErrorLabel" runat="server" CssClass="alert alert-danger" Visible="false" />
</div>

                <div class="form-group">
                    <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" CssClass="btn btn-primary btn-sm" />
                </div>
            </div>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

    <script>
    $( function() {
        $('#<%= DueDateTextBox.ClientID %>').datepicker();
    } );
    </script>

</body>
</html>
