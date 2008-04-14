<%@ Page Language="C#" AutoEventWireup="true" CodeFile="borrowlist.aspx.cs" Inherits="borrowlist" %>

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
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  OnPageIndexChanging="GridView1_PageIndexChanging" 
        OnSelectedIndexChanging="GridView1_SelectedIndexChanging" OnRowDeleting="GridView1_RowDeleting" AllowPaging="True" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
            <Columns>
                <asp:BoundField DataField="idBook" HeaderText="书号" />
                <asp:BoundField HeaderText="书名" />
                <asp:BoundField DataField="idUser" HeaderText="用户号" />
                <asp:BoundField HeaderText="用户名" />
                <asp:BoundField DataField="deadLine" HeaderText="截止日期" />
                <asp:ButtonField CommandName="select" Text="查看" />
                <asp:ButtonField ButtonType="Button" CommandName="delete" Text="还书" />
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
