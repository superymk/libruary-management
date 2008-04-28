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
        <asp:Label ID="lblMessage" runat="server"></asp:Label><br />
        <br />
    
    
     <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" 
     OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" Width="800px">
            <Columns>
                <asp:BoundField DataField="idUser" HeaderText="用户号" />
                <asp:BoundField DataField="userName" HeaderText="用户名" />
                <asp:BoundField DataField="trueName" HeaderText="真实姓名" />
                <asp:BoundField DataField="college" HeaderText="学院" />
                <asp:BoundField DataField="address" HeaderText="住址" />
                <asp:BoundField DataField="birthday" HeaderText="生日" />
                <asp:BoundField DataField="sex" HeaderText="性别" />
                <asp:BoundField DataField="email" HeaderText="Email" />
                <asp:BoundField DataField="mark" HeaderText="积分" />
                <asp:BoundField DataField="telnumber" HeaderText="电话" />
                <asp:BoundField HeaderText="管理员" />
                <asp:CommandField ShowSelectButton="True" />
                <asp:ButtonField ButtonType="Button" CommandName="delete" Text="删除" />
            </Columns>
        </asp:GridView>
        &nbsp;<br />
        &nbsp;
        <asp:Button ID="btnShowSearch" runat="server" OnClick="btnShowSearch_Click" Text="查找..." /><br />
        <asp:Panel ID="panelSearch" runat="server" Visible="False" Width="800px">
    
    <asp:Table ID="Table1" runat="server" Height="284px" Width="100%">
            <asp:TableRow ID="TableRow1" runat="server">
                <asp:TableCell ID="TextCell0" runat="server">
                    <asp:Label id="Label0"  runat="server" text="用户名: " /> 
                </asp:TableCell>
                <asp:TableCell ID="TableCell0" runat="server">
                    <asp:textbox id="username" runat="server" cssclass="textbox" /> 
                </asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="idUser" runat="server" Visible="False"/>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow3" runat="server">
                <asp:TableCell ID="TextCell3" runat="server" >
                    <asp:Label id="Label3"  runat="server" text="真实姓名: " /> 
                </asp:TableCell>
                <asp:TableCell ID="TableCell3" runat="server">
                    <asp:textbox id="trueName" runat="server" cssclass="textbox" /> 
                </asp:TableCell>
                <asp:TableCell ID="TextCell4" runat="server" >
                    <asp:Label id="Label4"  runat="server" text="学院: " /> 
                </asp:TableCell>
                <asp:TableCell ID="TableCell4" runat="server">
                    <asp:textbox id="college" runat="server" cssclass="textbox" /> 
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow4" runat="server">
                <asp:TableCell ID="TextCell5" runat="server" >
                    <asp:Label id="Label5"  runat="server" text="住址: " /> 
                </asp:TableCell>
                <asp:TableCell ID="TableCell5" runat="server">
                    <asp:textbox id="address" runat="server" cssclass="textbox" /> 
                </asp:TableCell>
                <asp:TableCell ID="TextCell6" runat="server" >
                    <asp:Label id="Label6"  runat="server" text="生日: " /> 
                </asp:TableCell>
                <asp:TableCell ID="TableCell6" runat="server">
                    <asp:textbox id="birthday" runat="server" cssclass="textbox" /> 
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow5" runat="server">
                <asp:TableCell ID="TextCell7" runat="server" >
                    <asp:Label id="Label7"  runat="server" text="性别: " /> 
                </asp:TableCell>
                <asp:TableCell ID="TableCell7" runat="server">
                    <asp:DropDownList ID="DropDownList1" runat="server" >
                        <asp:ListItem Value=""></asp:ListItem>
                        <asp:ListItem Value="MALE">男</asp:ListItem>
                        <asp:ListItem Value="FEMALE">女</asp:ListItem>
                    </asp:DropDownList>
                    <!--<asp:textbox id="sex" runat="server" cssclass="textbox" /> -->
                </asp:TableCell>
                <asp:TableCell ID="TextCell8" runat="server" >
                    <asp:Label id="Label8"  runat="server" text="Email: " /> 
                </asp:TableCell>
                <asp:TableCell ID="TableCell8" runat="server">
                    <asp:textbox id="email" runat="server" cssclass="textbox" /> 
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow6" runat="server">
                <asp:TableCell ID="TextCell9" runat="server" >
                    <asp:Label id="Label9"  runat="server" text="电话: " /> 
                </asp:TableCell>
                <asp:TableCell ID="TableCell9" runat="server">
                    <asp:textbox id="telnumber" runat="server" cssclass="textbox" /> 
                </asp:TableCell>
                <asp:TableCell ID="TextCell10" runat="server" >
                    <asp:Label id="Label10"  runat="server" text="描述: " /> 
                </asp:TableCell>
                <asp:TableCell ID="TableCell10" runat="server">
                    <asp:textbox id="description" textmode="MultiLine" runat="server" cssclass="textbox" /> 
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    <asp:Button ID="searchConfirm" Text="查找" runat="server" OnClick="search" /></asp:Panel>
    </div>
    </form>
</body>
</html>
