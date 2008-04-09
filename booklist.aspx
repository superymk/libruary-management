﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="booklist.aspx.cs" Inherits="booklist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="0">
            <tr>
                <td style="width: 100px">
                    bookname</td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtBookName" runat="server" ></asp:TextBox></td>
                <td style="width: 100px">
                    </td>
                <td style="width: 102px">
                    <asp:TextBox ID="txtIdBook" runat="server" Visible="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    type</td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtType" runat="server"></asp:TextBox></td>
                <td style="width: 100px">
                    numCopies</td>
                <td style="width: 102px">
                    <asp:TextBox ID="txtNumCopies" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    abstract</td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtAbstract" runat="server"></asp:TextBox></td>
                <td style="width: 100px">
                    author</td>
                <td style="width: 102px">
                    <asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    publishCompany</td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtPublishCompany" runat="server"></asp:TextBox></td>
                <td style="width: 100px">
                    DonatePerson</td>
                <td style="width: 102px">
                    <asp:TextBox ID="txtDonatePerson" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    state</td>
                <td style="width: 100px">
                    <asp:DropDownList ID="ddlState" runat="server">
                        <asp:ListItem Selected="True">FREE</asp:ListItem>
                        <asp:ListItem>BORROWED</asp:ListItem>
                        <asp:ListItem>MISSING</asp:ListItem>
                    </asp:DropDownList></td>
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 105px">
                    comment</td>
                <td colspan="3" style="height: 105px">
                    <asp:TextBox ID="txtComment" runat="server" Height="109px" TextMode="MultiLine" Width="412px"></asp:TextBox></td>
            </tr>
        </table>
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="search" />
        
        
        
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnSelectedIndexChanging="GridView1_SelectedIndexChanging"
            OnPageIndexChanging="GridView1_PageIndexChanging"  OnRowDeleting="GridView1_RowDeleting"
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
                <asp:ButtonField ButtonType="Button" CommandName="delete" Text="删除" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>