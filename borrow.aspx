<%@ Page Language="C#" AutoEventWireup="true" CodeFile="borrow.aspx.cs" Inherits="borrow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        UserName：<br />
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox><br />
        BookName：<br />
        <asp:TextBox ID="txtBookName" runat="server"></asp:TextBox><br />
        <asp:Button ID="btnRegister" runat="server" OnClick="register" Text="Register" />
        <asp:Button ID="btnUpdate" runat="server" Text="Update" />
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="Search" /><br />
        <asp:Table ID="tblBorrow" runat="server">
        </asp:Table>
    </div>
    </form>
</body>
</html>
