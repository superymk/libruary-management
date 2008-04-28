<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user.aspx.cs" Inherits="UserManager" %>

<%@ Register Src="Broadcast.ascx" TagName="Broadcast" TagPrefix="uc1" %>
<%@ Register Src="navigator.ascx" TagName="navigator" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>上海交通大学 微软俱乐部 图书管理系统</title>
    <link href="style.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
        &nbsp;<div>
            &nbsp; &nbsp; &nbsp;
            <table>
                <tr>
                    <td colspan="2">
    <uc2:navigator id="Navigator1" runat="server"></uc2:navigator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
        <asp:Label ID="error" runat="server"/>
        <asp:Table ID="Table1" runat="server" Height="284px" Width="564px">
            <asp:TableRow runat="server">
                <asp:TableCell ID="TextCell0" runat="server">
                    <asp:Label id="Label0"  runat="server" text="用户名: " /> 
                </asp:TableCell>
                <asp:TableCell ID="TableCell0" runat="server">
                    <asp:textbox id="username" textmode="SingleLine" runat="server" cssclass="textbox" /> 
                </asp:TableCell>
                <asp:TableCell></asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="idUser" TextMode="SingleLine" runat="server" Visible="false"/>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell ID="TextCell1" runat="server" >
                    <asp:Label id="Label1"  runat="server" text="密码: " /> 
                </asp:TableCell>
                <asp:TableCell ID="TableCell1" runat="server">
                    <asp:textbox id="password" textmode="Password" runat="server" cssclass="textbox" /> 
                </asp:TableCell>
                <asp:TableCell ID="TextCell2" runat="server" >
                   <asp:Label id="Label2"  runat="server" text="确认密码: " /> 
                </asp:TableCell>
                <asp:TableCell ID="TableCell2" runat="server">
                    <asp:textbox id="password2" textmode="Password" runat="server" cssclass="textbox" /> 
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell ID="TextCell3" runat="server" >
                    <asp:Label id="Label3"  runat="server" text="真实姓名: " /> 
                </asp:TableCell>
                <asp:TableCell ID="TableCell3" runat="server">
                    <asp:textbox id="trueName" textmode="SingleLine" runat="server" cssclass="textbox" /> 
                </asp:TableCell>
                <asp:TableCell ID="TextCell4" runat="server" >
                    <asp:Label id="Label4"  runat="server" text="学院: " /> 
                </asp:TableCell>
                <asp:TableCell ID="TableCell4" runat="server">
                    <asp:textbox id="college" textmode="SingleLine" runat="server" cssclass="textbox" /> 
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell ID="TextCell5" runat="server" >
                    <asp:Label id="Label5"  runat="server" text="住址: " /> 
                </asp:TableCell>
                <asp:TableCell ID="TableCell5" runat="server">
                    <asp:textbox id="address" textmode="SingleLine" runat="server" cssclass="textbox" /> 
                </asp:TableCell>
                <asp:TableCell ID="TextCell6" runat="server" >
                    <asp:Label id="Label6"  runat="server" text="生日: " /> 
                </asp:TableCell>
                <asp:TableCell ID="TableCell6" runat="server">
                    <asp:textbox id="birthday" textmode="SingleLine" runat="server" cssclass="textbox" /> 
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell ID="TextCell7" runat="server" >
                    <asp:Label id="Label7"  runat="server" text="性别: " /> 
                </asp:TableCell>
                <asp:TableCell ID="TableCell7" runat="server">
                    <asp:DropDownList ID="sex" runat="server" >
                        <asp:ListItem Selected="True" Value="unselected"> 未选择</asp:ListItem>
                        <asp:ListItem Value="male">男</asp:ListItem>
                        <asp:ListItem Value="female">女</asp:ListItem>
                    </asp:DropDownList>
                    <%--<asp:textbox id="sex" textmode="SingleLine" runat="server" cssclass="textbox" /> --%>
                </asp:TableCell>
                <asp:TableCell ID="TextCell8" runat="server" >
                    <asp:Label id="Label8"  runat="server" text="Email: " /> 
                </asp:TableCell>
                <asp:TableCell ID="TableCell8" runat="server">
                    <asp:textbox id="email" textmode="SingleLine" runat="server" cssclass="textbox" /> 
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell ID="TextCell9" runat="server" >
                    <asp:Label id="Label9"  runat="server" text="电话: " /> 
                </asp:TableCell>
                <asp:TableCell ID="TableCell9" runat="server">
                    <asp:textbox id="telnumber" textmode="SingleLine" runat="server" cssclass="textbox" /> 
                </asp:TableCell>
                <asp:TableCell ID="TableCell11" runat="server" >
                    <asp:Label id="Label12"  runat="server" text="积分: " /> 
                </asp:TableCell>
                <asp:TableCell ID="TableCell12" runat="server">
                    <asp:textbox id="mark" textmode="SingleLine" runat="server" cssclass="textbox" /> 
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell ID="TextCell10" runat="server" >
                    <asp:Label id="Label10"  runat="server" text="描述: " /> 
                </asp:TableCell>
                <asp:TableCell ID="TableCell10" runat="server">
                    <asp:textbox id="description" textmode="MultiLine" runat="server" cssclass="textbox" /> 
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    <asp:Button ID="registerConfirm" Text="注册" runat="server" OnClick="register" />
    <asp:Button ID="updateConfirm" Text="修改" runat="server" OnClick="update" />
    
    <asp:Label id="Admin"  runat="server" text="" /> 
        <asp:Button ID="btnChangeAdmin" runat="server" OnClick="ChangeAdmin" Text="设置管理员" /></td>
                    <td style="width: 100px" valign="top">
                        &nbsp;<asp:Panel ID="panelComments" runat="server" Width="100%">
            <asp:Label ID="Label11" runat="server" Text="新评论"></asp:Label><br/>
            <asp:textbox ID="newCBox" runat="server" TextMode="MultiLine"></asp:textbox><br/>
            <asp:Button ID="Button1" Text="添加评论" runat="server" OnClick="addComment"/><br/>
            <asp:Table ID="comments" runat="server">
                <asp:TableRow ID="newComment" runat="server">
                    <asp:TableCell ID="newCCell" runat="server">
                
                    </asp:TableCell>
                    </asp:TableRow>
            </asp:Table>            
            </asp:Panel>
                        &nbsp;<br/>
                    </td>
                </tr>
            </table>

    
    </div>
    </form>
</body>
</html>
