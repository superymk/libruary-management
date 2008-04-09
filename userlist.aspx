<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userlist.aspx.cs" Inherits="userlist" %>
<%@ Register Src="navigator.ascx" TagName="navigator" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>上海交通大学 微软俱乐部 图书管理系统</title>
    <link href="style.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
    <uc2:navigator id="Navigator1" runat="server"></uc2:navigator>
    <div>
    
    
     <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="5" AutoGenerateColumns="False" 
     OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
            <Columns>
                <asp:BoundField DataField="idUser" HeaderText="IdUser" />
                <asp:BoundField DataField="userName" HeaderText="UserName" />
                <asp:BoundField DataField="trueName" HeaderText="TrueName" />
                <asp:BoundField DataField="college" HeaderText="college" />
                <asp:BoundField DataField="address" HeaderText="address" />
                <asp:BoundField DataField="birthday" HeaderText="birthday" />
                <asp:BoundField DataField="sex" HeaderText="sex" />
                <asp:BoundField DataField="email" HeaderText="email" />
                <asp:BoundField DataField="mark" HeaderText="mark" />
                <asp:BoundField DataField="telnumber" HeaderText="telnumber" />
                <asp:CommandField ShowSelectButton="True" />
                <asp:ButtonField ButtonType="Button" CommandName="delete" Text="删除" />
            </Columns>
        </asp:GridView>
        <br />
    
    <asp:Table ID="Table1" runat="server" Height="284px" Width="564px">
            <asp:TableRow ID="TableRow1" runat="server">
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
            <asp:TableRow ID="TableRow3" runat="server">
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
            <asp:TableRow ID="TableRow4" runat="server">
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
            <asp:TableRow ID="TableRow5" runat="server">
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
            <asp:TableRow ID="TableRow6" runat="server">
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
    <asp:Button ID="searchConfirm" Text="查找" runat="server" OnClick="search" />&nbsp;
    </div>
    </form>
</body>
</html>
