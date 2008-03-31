<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >


<head runat="server">
    <title>Hello World!</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        上海交通大学 微软俱乐部 图书管理系统<br />

    <asp:Label id="lblMessage"  runat="server" /> 
    
    <asp:textbox id="username" textmode="Password" runat="server" cssclass="textbox" /> 
    
    <asp:requiredfieldvalidator ID="Requiredfieldvalidator1" controltovalidate="username" display="dynamic" forecolor ="#ff0000" font-names="宋体" font-size="9pt" text="请填写" runat="server" />
    <asp:textbox id="password" textmode="Password" runat="server" cssclass="textbox" />
    
    <asp:requiredfieldvalidator ID="Requiredfieldvalidator2" controltovalidate="password" display="dynamic" forecolor ="#ff0000" font-names="宋体" font-size="9pt" text="请填写" runat="server" />  
    
    <asp:Button Text="Login" OnClick="Log_In" id="btnCounter" runat="server" />
    
    
<asp:Label id="nameserver"  runat="server" /> 
<asp:Label id="pswserver"  runat="server" /> 
        <asp:Button ID="btnOffline" runat="server" OnClick="offline" Text="Offline" /></div>
    </form>
</body>
</html>
