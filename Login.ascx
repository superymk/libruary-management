<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Login.ascx.cs" Inherits="Login" %>
<table>
    <tr>
        <td style="width: 100px">
            用户名</td>
        <td style="width: 100px">
            <asp:TextBox ID="txtUsername" runat="server">Guest</asp:TextBox></td>
        <td style="width: 100px">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername"
                ErrorMessage="请填写"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td style="width: 100px">
            密码：</td>
        <td style="width: 100px">
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password">guest</asp:TextBox></td>
        <td style="width: 100px">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                ErrorMessage="请填写"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td style="width: 100px; height: 26px">
            <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" /></td>
        <td style="width: 100px; height: 26px">
            <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="logout" CausesValidation="False" /></td>
        <td style="width: 100px; height: 26px">
            <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" Text="Register" CausesValidation="False" /></td>
    </tr>
</table>
