<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="CrudApp.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student CRUD App</title>
    <link rel="stylesheet" href="style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="form-box">
                <asp:TextBox ID="txtname" runat="server" Placeholder="Enter Name"></asp:TextBox>
                <asp:TextBox ID="txtroll" runat="server" placeholder="Enter roll"></asp:TextBox>
                <asp:TextBox ID="txtmark" runat="server" placeholder="Enter mark"></asp:TextBox>
                <asp:Button ID="btnAddUser" runat="server" Text="Add User" OnClick="BtnAddUser_Click" />
            </div>

            <asp:GridView ID="GrdView1" AutoGenerateColumns="false"
                OnRowEditing="GrdView1_RowEditing"
                OnRowUpdating="GrdView1_RowUpdating"
                OnRowDeleting="GrdView1_RowDeleting"
                OnRowCancelingEdit="GrdView1_RowCancelingEdit"
                runat="server">
                <Columns>
                    <asp:BoundField DataField="rollno" HeaderText="Roll" ReadOnly="true" />
                    <asp:BoundField DataField="username" HeaderText="Name" />
                    <asp:BoundField DataField="marks" HeaderText="Mark" />
                    <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
