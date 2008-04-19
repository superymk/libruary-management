<%@ Control Language="C#" AutoEventWireup="true" CodeFile="navigator.ascx.cs" Inherits="navigator" %>
<%@ Register Src="Broadcast.ascx" TagName="Broadcast" TagPrefix="uc1" %>
<style type="text/css">
<!--
.style1 {
	font-size: 16pt;
	font-weight: bold;
}
-->
</style>

<table width="800">
    <tr>
        <td colspan="9">
            <p align="center"><img src="images/sjtulogo_2.png" width="181" height="57"> <img src="images/mstc_logo_1.jpg" width="190" height="65"/></p>
            <p align="center" class="style1">MSTC图书管理系统</p></td>
    </tr>
    <tr>
        <td>
            <asp:LinkButton ID="btnBookSearch" runat="server" OnClick="btnBookSearch_Click">图书察看</asp:LinkButton></td>
        <td>
            <asp:LinkButton ID="btnShopingList" runat="server" OnClick="btnShopingList_Click">我的借书车</asp:LinkButton></td>
        <td>
            <asp:LinkButton ID="btnBorrowList" runat="server" OnClick="btnBorrowList_Click">我的借书单</asp:LinkButton></td>
        <td>
            <asp:LinkButton ID="btnUserList" runat="server" OnClick="btnUserList_Click">用户列表</asp:LinkButton></td>
        <td>
            <asp:LinkButton ID="btnReturnBook" runat="server" OnClick="btnReturnBook_Click">用户还书</asp:LinkButton></td>
        <td>
            <asp:LinkButton ID="btnAddBook" runat="server" OnClick="addBook">添加图书</asp:LinkButton></td>
        <td>
            <asp:LinkButton ID="btnAddUser" runat="server" OnClick="addUser">添加用户</asp:LinkButton></td>
        <td>
            <asp:Label ID="lblUsername" runat="server"></asp:Label></td>
        <td>
            <asp:LinkButton ID="btnLogout" runat="server" OnClick="btnLogout_Click">注销</asp:LinkButton></td>
    </tr>
</table>
<uc1:Broadcast ID="Broadcast1" runat="server" />
