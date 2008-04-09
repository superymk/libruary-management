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
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        OnSelectedIndexChanging="GridView1_SelectedIndexChanging" OnRowDeleting="GridView1_RowDeleting"
             PageSize="5">
            <Columns>
                <asp:BoundField DataField="idBook" HeaderText="IdBook" />
                <asp:BoundField HeaderText="BookName" />
                <asp:BoundField DataField="idUser" HeaderText="IdUser" />
                <asp:BoundField HeaderText="UserName" />
                <asp:BoundField DataField="deadLine" HeaderText="DeadLine" />
                <asp:ButtonField CommandName="select" Text="查看" />
                <asp:ButtonField ButtonType="Button" CommandName="delete" Text="还书" />
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
