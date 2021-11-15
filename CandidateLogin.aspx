<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CandidateLogin.aspx.cs" Inherits="DeloitteCandidateStatus.CandidateLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Deloitte Candidate Login</title>
    <link href="Style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
        <div class="content">
            <h2>Deloitte Candidate Login</h2>
            <asp:Label ID="lblUserName" runat="server" Text="User Name"></asp:Label>
            <asp:TextBox ID="txtUserName" runat="server" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqUserName" runat="server" ControlToValidate="txtUserName" ErrorMessage="*" ForeColor="Red" ></asp:RequiredFieldValidator>

            <br />
            <asp:Label ID="lblPassword" runat="server" Text="Password"  ></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />

            <asp:CheckBox ID="chkRememberMe" runat="server" />
            <asp:Label ID="lblRememberMe" runat="server" Text="Remember Me"></asp:Label>
            <br />
            <asp:Button ID="Submit" runat="server" Text="Login" OnClick="Submit_Click"  />
        </div>
        </div>
    </form>
</body>
</html>
