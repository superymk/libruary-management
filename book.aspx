<%@ Page Language="C#" AutoEventWireup="true" CodeFile="book.aspx.cs" Inherits="book" %>

<%@ Register Src="navigator.ascx" TagName="navigator" TagPrefix="uc2" %>

<%@ Register Src="Login.ascx" TagName="Login" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">

    <title>上海交通大学 微软俱乐部 图书管理系统</title>
    <link href="style.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
        <table style="width: 800px">
            
                        <tr>
                            <td colspan="2">
                    <uc2:navigator id="Navigator1" runat="server"></uc2:navigator>
                            </td>
                        </tr>
                        <tr>
                            <td>
        
        <table border="0"  style="width: 100%; height: 100%">
            <tr>
                <td>
                    书名</td>
                <td>
                    <asp:TextBox ID="txtBookName" runat="server" ></asp:TextBox></td>
                <td>
                    </td>
                <td>
                    <asp:TextBox ID="txtIdBook" runat="server" Visible="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    类别</td>
                <td>
                    <asp:TextBox ID="txtType" runat="server"></asp:TextBox></td>
                <td>
                    数量</td>
                <td>
                    <asp:TextBox ID="txtNumCopies" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    描述</td>
                <td>
                    <asp:TextBox ID="txtAbstract" runat="server"></asp:TextBox></td>
                <td>
                    作者</td>
                <td>
                    <asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    出版社</td>
                <td>
                    <asp:TextBox ID="txtPublishCompany" runat="server"></asp:TextBox></td>
                <td>
                    捐献人</td>
                <td>
                    <asp:TextBox ID="txtDonatePerson" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    状态</td>
                <td>
                    <asp:DropDownList ID="ddlState" runat="server">
                        <asp:ListItem Selected="True">FREE</asp:ListItem>
                        <asp:ListItem>BORROWED</asp:ListItem>
                        <asp:ListItem>MISSING</asp:ListItem>
                    </asp:DropDownList></td>
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td>
                    评论</td>
                <td colspan="3">
                    <asp:TextBox ID="txtComment" runat="server" Height="110px" TextMode="MultiLine" Width="400px"></asp:TextBox></td>
            </tr>
        </table>
        <asp:Button ID="btnAdd" runat="server" Text="添加" OnClick="register" />
        <asp:Button ID="btnUpdate" runat="server" Text="修改" OnClick="update" />&nbsp;
        <asp:Button ID="btnAddCart" runat="server" OnClick="btnAddCart_Click" Text="加至借书车" />&nbsp;
        </td>
     
          <td style="width: 100px" valign="top">
            
            <asp:Panel ID="panelComments" runat="server" Width="100%">
            <asp:Label ID="newCLabel" runat="server" Text="新评论"></asp:Label><br/>
            <asp:textbox ID="newCBox" runat="server" TextMode="MultiLine"></asp:textbox><br/>
            <asp:Button ID="newCButton" Text="添加评论" runat="server" OnClick="addComment"/><br/>
            <asp:Table ID="comments" runat="server">
                <asp:TableRow ID="newComment" runat="server">
                    <asp:TableCell ID="newCCell" runat="server">
                
                    </asp:TableCell>
                    </asp:TableRow>
            </asp:Table>            
            </asp:Panel>
            <br/>
        
        &nbsp;
        </td>
                </tr>
                </table>
    </form>
                        
                   
        
                
</body>
</html>
