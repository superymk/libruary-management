using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class navigator : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SessionData sd = Session[SessionData.SessionName] as SessionData;
        if (sd == null || sd.CurrentUser == null)
        {
            string a = Request.Url.LocalPath;
            if (!a.ToLower().Equals("/libsys/user.aspx"))
            {
                Response.Redirect("Default.aspx");
            }
            
        }
        else
        {
            lblUsername.Text = "<a href=user.aspx?id=" + sd.CurrentUser.IdUser + ">"
                + sd.CurrentUser.Username + "</a>";
            IUserDao userdao = DaoFactory.getUserDao();
            if (userdao.isAdmin(sd.CurrentUser.IdUser))
            {
                
                btnReturnBook.Visible = true;
                btnAddBook.Visible = true;
                btnAddUser.Visible = true;
                lblUsername.Text += " 管理员";
                return;
            }
            else
            {
                
                btnReturnBook.Visible = false;
                btnAddBook.Visible = false;
                btnAddUser.Visible = false;
                lblUsername.Text += " 用户";
            }

        }
    }
    protected void btnNewUser_Click(object sender, EventArgs e)
    {
        Session[SessionData.SessionName] = null;
        Response.Redirect("User.aspx");
    }
    protected void btnBookSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("booklist.aspx");
    }
    protected void btnShopingList_Click(object sender, EventArgs e)
    {
        Response.Redirect("borrowcart.aspx");
    }
    protected void btnBorrowList_Click(object sender, EventArgs e)
    {
        SessionData sd = Session[SessionData.SessionName] as SessionData;
        User user = sd.CurrentUser;
        Response.Redirect("borrowlist.aspx?id="+user.IdUser);
    }
    protected void btnUserList_Click(object sender, EventArgs e)
    {
        Response.Redirect("Userlist.aspx");
    }
    protected void btnReturnBook_Click(object sender, EventArgs e)
    {
        Response.Redirect("borrowlist.aspx");
    }
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session[SessionData.SessionName] = null;
        Response.Redirect("Default.aspx");
    }
    protected void addBook(object sender, EventArgs e)
    {
        Response.Redirect("book.aspx");
    }
    protected void addUser(object sender, EventArgs e)
    {
        Response.Redirect("user.aspx");
    }
}
