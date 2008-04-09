<%@ Control Language="C#" AutoEventWireup="true" CodeFile="navigator.ascx.cs" Inherits="navigator" %>
<style type="text/css">
<!--
.style1 {
	font-size: 16pt;
	font-weight: bold;
}
-->
</style>

<table>
    <tr>
        <td colspan="8">
            <p align="center"><img src="images/sjtulogo_2.png" width="181" height="57"> <img src="images/mstc_logo_1.jpg" width="190" height="65"></p>
            <p align="center" class="style1">图书管理系统</p></td>
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
            欢迎您<asp:LinkButton ID="btnLogout" runat="server" OnClick="btnLogout_Click">注销</asp:LinkButton></td>
    </tr>
</table>
