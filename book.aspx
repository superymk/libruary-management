<%@ Page Language="C#" AutoEventWireup="true" CodeFile="book.aspx.cs" Inherits="book" %>

<%@ Register Src="Login.ascx" TagName="Login" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Login ID="Login1" runat="server" />
        <asp:Button ID="btnBorrow" runat="server" OnClick="borrow" Text="Borrow" /><br />
        <br />
        <table border="0">
            <tr>
                <td style="width: 100px">
                    bookname</td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtBookName" runat="server" ></asp:TextBox></td>
                <td style="width: 100px">
                    </td>
                <td style="width: 102px">
                    <asp:TextBox ID="txtIdBook" runat="server" Visible="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    type</td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtType" runat="server"></asp:TextBox></td>
                <td style="width: 100px">
                    numCopies</td>
                <td style="width: 102px">
                    <asp:TextBox ID="txtNumCopies" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    abstract</td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtAbstract" runat="server"></asp:TextBox></td>
                <td style="width: 100px">
                    author</td>
                <td style="width: 102px">
                    <asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    publishCompany</td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtPublishCompany" runat="server"></asp:TextBox></td>
                <td style="width: 100px">
                    DonatePerson</td>
                <td style="width: 102px">
                    <asp:TextBox ID="txtDonatePerson" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    state</td>
                <td style="width: 100px">
                    <asp:DropDownList ID="ddlState" runat="server">
                        <asp:ListItem Selected="True">FREE</asp:ListItem>
                        <asp:ListItem>BORROWED</asp:ListItem>
                        <asp:ListItem>MISSING</asp:ListItem>
                    </asp:DropDownList></td>
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 105px">
                    comment</td>
                <td colspan="3" style="height: 105px">
                    <asp:TextBox ID="txtComment" runat="server" Height="109px" TextMode="MultiLine" Width="412px"></asp:TextBox></td>
            </tr>
        </table>
        <asp:Button ID="btnAdd" runat="server" Text="Register" OnClick="register" />
        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="update" />
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="search" />
        <br />
        <asp:Table ID="comments" runat="server">
        <asp:TableRow ID="newComment" runat="server">
            <asp:TableCell ID="newCCell" runat="server">
                <asp:Label ID="newCLabel" runat="server" Text="new comment<BR>"></asp:Label>
                <asp:textbox ID="newCBox" runat="server"></asp:textbox>
                <asp:Label ID="newCLabel2" runat="server" Text="<BR>"></asp:Label>
                <asp:Button ID="newCButton" Text="Add Comment" runat="server" OnClick="addComment"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
        
        
        <asp:Table ID="books" runat="server">
        </asp:Table>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="5" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="idBook" HeaderText="IdBook" />
                <asp:BoundField DataField="type" HeaderText="Type" />
                <asp:BoundField DataField="numCopies" HeaderText="NumCopies" />
                <asp:BoundField DataField="bookName" HeaderText="BookName" />
                <asp:BoundField DataField="abstract" HeaderText="Abstract" />
                <asp:BoundField DataField="author" HeaderText="Author" />
                <asp:BoundField DataField="publishCompany" HeaderText="PublishCompany" />
                <asp:BoundField DataField="donatePerson" HeaderText="DonatePerson" />
                <asp:BoundField DataField="state" HeaderText="State" />
                <asp:BoundField DataField="comment" HeaderText="Comment" />
                <asp:ButtonField ButtonType="Button" Text="删除" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
