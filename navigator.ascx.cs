﻿using System;
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
        if (sd == null||sd.CurrentUser==null)
        {
            Response.Redirect("index.aspx");
        }
        lblUsername.Text = sd.CurrentUser.Username;

        IUserDao userdao=DaoFactory.getUserDao();
        if (userdao.isAdmin(sd.CurrentUser.IdUser) == 1)
        {
            btnUserList.Visible = true;
            btnReturnBook.Visible = true;
            return;
        }
        else
        {
            btnUserList.Visible = false;
            btnReturnBook.Visible = false;
        }
    }
    protected void btnNewUser_Click(object sender, EventArgs e)
    {
        SessionData sd = Session[SessionData.SessionName] as SessionData;
        if (sd == null) sd = new SessionData();
        sd.CurrentUser = null;
        Session[SessionData.SessionName] = sd;
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
        Response.Redirect("index.aspx");
    }
}
