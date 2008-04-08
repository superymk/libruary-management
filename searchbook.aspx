<%@ Page Language="C#" AutoEventWireup="true" CodeFile="searchbook.aspx.cs" Inherits="searchbook" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            OnPageIndexChanging="GridView1_PageIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
            PageSize="5">
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
    
    </div>
    </form>
</body>
</html>
