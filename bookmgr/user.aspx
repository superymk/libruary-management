<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user.aspx.cs" Inherits="UserManager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table ID="Table1" runat="server" Height="284px" Width="564px">
            <asp:TableRow runat="server">
                <asp:TableCell ID="TextCell0" runat="server">
                    <asp:Label id="Label0"  runat="server" text="username: " /> 
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
                    <asp:Label id="Label1"  runat="server" text="password: " /> 
                </asp:TableCell>
                <asp:TableCell ID="TableCell1" runat="server">
                    <asp:textbox id="password" textmode="Password" runat="server" cssclass="textbox" /> 
                </asp:TableCell>
                <asp:TableCell ID="TextCell2" runat="server" >
                   <asp:Label id="Label2"  runat="server" text="confirm password: " /> 
                </asp:TableCell>
                <asp:TableCell ID="TableCell2" runat="server">
                    <asp:textbox id="password2" textmode="Password" runat="server" cssclass="textbox" /> 
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell ID="TextCell3" runat="server" >
                    <asp:Label id="Label3"  runat="server" text="trueName: " /> 
                </asp:TableCell>
                <asp:TableCell ID="TableCell3" runat="server">
                    <asp:textbox id="trueName" textmode="SingleLine" runat="server" cssclass="textbox" /> 
                </asp:TableCell>
                <asp:TableCell ID="TextCell4" runat="server" >
                    <asp:Label id="Label4"  runat="server" text="college: " /> 
                </asp:TableCell>
                <asp:TableCell ID="TableCell4" runat="server">
                    <asp:textbox id="college" textmode="SingleLine" runat="server" cssclass="textbox" /> 
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell ID="TextCell5" runat="server" >
                    <asp:Label id="Label5"  runat="server" text="address: " /> 
                </asp:TableCell>
                <asp:TableCell ID="TableCell5" runat="server">
                    <asp:textbox id="address" textmode="SingleLine" runat="server" cssclass="textbox" /> 
                </asp:TableCell>
                <asp:TableCell ID="TextCell6" runat="server" >
                    <asp:Label id="Label6"  runat="server" text="birthday: " /> 
                </asp:TableCell>
                <asp:TableCell ID="TableCell6" runat="server">
                    <asp:textbox id="birthday" textmode="SingleLine" runat="server" cssclass="textbox" /> 
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell ID="TextCell7" runat="server" >
                    <asp:Label id="Label7"  runat="server" text="sex: " /> 
                </asp:TableCell>
                <asp:TableCell ID="TableCell7" runat="server">
                    <asp:textbox id="sex" textmode="SingleLine" runat="server" cssclass="textbox" /> 
                </asp:TableCell>
                <asp:TableCell ID="TextCell8" runat="server" >
                    <asp:Label id="Label8"  runat="server" text="email: " /> 
                </asp:TableCell>
                <asp:TableCell ID="TableCell8" runat="server">
                    <asp:textbox id="email" textmode="SingleLine" runat="server" cssclass="textbox" /> 
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell ID="TextCell9" runat="server" >
                    <asp:Label id="Label9"  runat="server" text="telnumber: " /> 
                </asp:TableCell>
                <asp:TableCell ID="TableCell9" runat="server">
                    <asp:textbox id="telnumber" textmode="SingleLine" runat="server" cssclass="textbox" /> 
                </asp:TableCell>
                <asp:TableCell ID="TextCell10" runat="server" >
                    <asp:Label id="Label10"  runat="server" text="description: " /> 
                </asp:TableCell>
                <asp:TableCell ID="TableCell10" runat="server">
                    <asp:textbox id="description" textmode="MultiLine" runat="server" cssclass="textbox" /> 
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    <asp:Button ID="registerConfirm" Text="Register" runat="server" OnClick="register" />
    <asp:Button ID="updateConfirm" Text="Update" runat="server" OnClick="update" />
    <asp:Button ID="searchConfirm" Text="Search" runat="server" OnClick="search" />
    
    
    
    <asp:Table ID="users" runat="server"></asp:Table>
    </div>
    </form>
</body>
</html>
