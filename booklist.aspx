<%@ Page Language="C#" AutoEventWireup="true" CodeFile="booklist.aspx.cs" Inherits="booklist" %>
<%@ Register Src="navigator.ascx" TagName="navigator" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>上海交通大学 微软俱乐部 图书管理系统</title>
    <link href="style.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
    <uc2:navigator id="Navigator1" runat="server"></uc2:navigator>
        <br />
    <div>
        <asp:Label ID="lblMessage" runat="server"></asp:Label><br />
        
        
        
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnSelectedIndexChanging="GridView1_SelectedIndexChanging"
            OnPageIndexChanging="GridView1_PageIndexChanging"  OnRowDeleting="GridView1_RowDeleting" Width="800px">
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
                <asp:ButtonField CommandName="select" Text="选择" />
                <asp:ButtonField ButtonType="Button" CommandName="delete" Text="删除" />
            </Columns>
        </asp:GridView>
        &nbsp;<br />
        &nbsp;
        <asp:Button ID="showSearch" runat="server" Text="查找..." OnClick="showSearch_Click" />
        <asp:Panel ID="panelSearch" runat="server" Visible="False">
    <table border="0" width="800">
            <tr>
                <td style="width: 100px">
                    书名</td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtBookName" runat="server" ></asp:TextBox></td>
                <td style="width: 100px">
                    </td>
                <td style="width: 102px">
                    <asp:TextBox ID="txtIdBook" runat="server" Visible="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    类型</td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtType" runat="server"></asp:TextBox></td>
                <td style="width: 100px">
                    数量</td>
                <td style="width: 102px">
                    <asp:TextBox ID="txtNumCopies" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    描述</td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtAbstract" runat="server"></asp:TextBox></td>
                <td style="width: 100px">
                    作者</td>
                <td style="width: 102px">
                    <asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    出版社</td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtPublishCompany" runat="server"></asp:TextBox></td>
                <td style="width: 100px">
                    捐献人</td>
                <td style="width: 102px">
                    <asp:TextBox ID="txtDonatePerson" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    状态</td>
                <td style="width: 100px">
                    <asp:DropDownList ID="ddlState" runat="server">
                        <asp:ListItem Selected="True"></asp:ListItem>
                        <asp:ListItem>FREE</asp:ListItem>
                        <asp:ListItem>BORROWED</asp:ListItem>
                        <asp:ListItem>MISSING</asp:ListItem>
                    </asp:DropDownList></td>
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 105px">
                    评论</td>
                <td colspan="3" style="height: 105px">
                    <asp:TextBox ID="txtComment" runat="server" Height="109px" TextMode="MultiLine" Width="412px"></asp:TextBox></td>
            </tr>
        </table>
        <asp:Button ID="btnSearch" runat="server" Text="查找" OnClick="search" /></asp:Panel>
    </div>
    </form>
</body>
</html>
