<%@ Page Language="C#" AutoEventWireup="true" CodeFile="borrowcart.aspx.cs" Inherits="borrowcart" %>

<%@ Register Src="navigator.ascx" TagName="navigator" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>上海交通大学 微软俱乐部 图书管理系统</title>
    <link href="style.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:navigator ID="Navigator1" runat="server" />
        <br />
        <asp:Label ID="lblMessage" runat="server"></asp:Label><br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting"
            PageSize="5">
            <Columns>
                <asp:BoundField DataField="idBook" HeaderText="IdBook" />
                <asp:BoundField DataField="bookName" HeaderText="BookName" />
                <asp:BoundField DataField="author" HeaderText="Author" />
                <asp:BoundField DataField="publishCompany" HeaderText="PublishCompany" />
                <asp:BoundField DataField="type" HeaderText="Type" />
                <asp:BoundField DataField="state" HeaderText="State" />
                <asp:BoundField DataField="numCopies" HeaderText="NumCopies" />
                <asp:BoundField DataField="donatePerson" HeaderText="DonatePerson" />
                <asp:BoundField DataField="abstract" HeaderText="Abstract" />
                <asp:ButtonField CommandName="select" Text="选择" />
                <asp:ButtonField ButtonType="Button" CommandName="delete" Text="取消" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="确认借书" /></div>
    </form>
</body>
</html>
