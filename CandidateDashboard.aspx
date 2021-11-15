<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CandidateDashboard.aspx.cs" Inherits="DeloitteCandidateStatus.CandidateDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Candidate Dashboard</title>
    <link href="Dashboard.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="content">
            <h2>Candidate Dashboard</h2>
            <div>
                <h3><asp:Label runat="server" ID="lblUser" ></asp:Label></h3>
                <asp:Button ID="btnLogOut" runat="server"  Text="LogOut" OnClick="btnLogOut_Click" />
            </div>
            <asp:TextBox ID="txtList" runat="server" placeholder="To Do Task..."></asp:TextBox>
            <asp:TextBox ID="txtDescription" runat="server" placeholder="Description About Task..."></asp:TextBox>
            

            <asp:Button ID="btnAddTask" runat="server"  Text="Add Task" OnClick="btnAddTask_Click" />
        </div>
        <div>
            <asp:GridView ID="grvTaskList" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="chkList" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="TaskId" HeaderText="ID"  />
                    <asp:BoundField  DataField="Task" HeaderText="Task List"/>
                    <asp:BoundField  DataField="Description" HeaderText="Description"/>
                    <asp:BoundField  DataField="LastUpdatedDate" HeaderText="Last Updated"/>
                    
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
        </div>
        <div class="content">
            <asp:Button ID="btnDelete" runat="server" Text="Delete Task" OnClick="btnDelete_Click" Visible="false" />
        </div>
    </form>
</body>
</html>
