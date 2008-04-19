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
            PageSize="5" Width="800px">
            <Columns>
                <asp:BoundField DataField="idBook" HeaderText="书籍编号" />
                <asp:BoundField DataField="bookName" HeaderText="书名" />
                <asp:BoundField DataField="author" HeaderText="作者" />
                <asp:BoundField DataField="publishCompany" HeaderText="出版社" />
                <asp:BoundField DataField="type" HeaderText="类型" />
                <asp:BoundField DataField="state" HeaderText="状态" />
                <asp:BoundField DataField="numCopies" HeaderText="数量" />
                <asp:BoundField DataField="donatePerson" HeaderText="捐献人" />
                <asp:BoundField DataField="abstract" HeaderText="描述" />
                <asp:ButtonField ButtonType="Button" CommandName="delete" Text="取消" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="确认借书" /></div>
    </form>
</body>
</html>
