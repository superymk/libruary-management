<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Index" %>

<%@ Register Src="Login.ascx" TagName="Login" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>上海交通大学 微软俱乐部 图书管理系统</title>
    <link href="style.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <br />
        <br />
        <br />
    <img src="images/sjtulogo_1.png" width="80" height="85" alt="" title="Shanghai Jiao Tong University"/><br />
        <img src="images/sjtulogo_2.png" width="181" height="57" alt="" title="Shanghai Jiao Tong University"/>&nbsp;<br />
        <img src="images/mstc_logo_1.jpg" width="190" height="65" alt="" title="Shanghai Jiao Tong University"/><br />
        <br />
        <br />
        <br />
        <span style="font-size: 32pt; font-family: 宋体"><span style="font-size: 16pt">
        图书管理系统<br />
        </span>
            <br />
        </span>
        <uc1:Login ID="Login1" runat="server" OnLoad="Login1_Load" />
    
    </div>
    </form>
</body>
</html>
