
<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="test.aspx.cs" Inherits="test" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head><title>上海交通大学 微软俱乐部 图书管理系统</title></head> 
<body>
<form id="form2" runat="server">
<asp:Button Text="UnClicked" OnClick="btnCounter_OnClick" id="btnCounter" runat="server" />
<asp:Label id="lblMessage"  runat="server" /> 
<br/>
<asp:textbox id="password1" textmode="Password" runat="server" cssclass="textbox" /> 
<asp:requiredfieldvalidator controltovalidate="password1" display="dynamic" forecolor ="#ff0000" font-names="宋体" font-size="9pt" text="请填写" runat="server" />
<br/>
<asp:textbox id="password2" textmode="Password" runat="server" cssclass="textbox" /> 
<asp:requiredfieldvalidator ID="Requiredfieldvalidator1" controltovalidate="password2" display="dynamic" forecolor ="#ff0000" font-names="宋体" font-size="9pt" text="请填写" runat="server" /> 
<asp:comparevalidator controltovalidate="password2" controltocompare="password1" display ="dynamic" operator="equal" forecolor="#ff0000" font-names="宋体" font-size ="9pt" text="确认失败" runat="server"/>


</form>
</body>
</html>