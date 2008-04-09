<%@ Control Language="C#" AutoEventWireup="true" CodeFile="navigator.ascx.cs" Inherits="navigator" %>
<table>
    <tr>
        <td colspan="8">
            上海交通大学 微软俱乐部 图书管理系统</td>
    </tr>
    <tr>
        <td style="width: 100px">
            <asp:LinkButton ID="btnNewUser" runat="server" OnClick="btnNewUser_Click">新用户注册</asp:LinkButton></td>
        <td style="width: 100px">
            <asp:LinkButton ID="btnBookSearch" runat="server" OnClick="btnBookSearch_Click">图书察看</asp:LinkButton></td>
        <td style="width: 100px">
            <asp:LinkButton ID="btnShopingList" runat="server" OnClick="btnShopingList_Click">我的借书车</asp:LinkButton></td>
        <td style="width: 100px">
            <asp:LinkButton ID="btnBorrowList" runat="server" OnClick="btnBorrowList_Click">我的借书单</asp:LinkButton></td>
        <td style="width: 100px">
            <asp:LinkButton ID="btnUserList" runat="server" OnClick="btnUserList_Click">用户列表</asp:LinkButton></td>
        <td style="width: 100px">
            <asp:LinkButton ID="btnReturnBook" runat="server" OnClick="btnReturnBook_Click">用户还书</asp:LinkButton></td>
        <td style="width: 100px">
            <asp:Label ID="lblUsername" runat="server"></asp:Label></td>
        <td style="width: 100px">
            欢迎您</td>
    </tr>
</table>
