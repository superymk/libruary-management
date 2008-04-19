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

public partial class Broadcast : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        SessionData sd = Session[SessionData.SessionName] as SessionData;
        if (sd == null || sd.CurrentUser == null)
            Response.Redirect("default.aspx");
        
        string s = DaoFactory.getBoardDao().BoardCast;
        txtContext.Text = s==null?"":s;
        bool isAdmin = DaoFactory.getUserDao().isAdmin(sd.CurrentUser.IdUser);

        txtContext.BorderStyle = isAdmin ? BorderStyle.NotSet : BorderStyle.None;
        txtContext.Enabled = isAdmin;
        btnSet.Visible = isAdmin;
    }
    protected void btnSet_Click(object sender, EventArgs e)
    {
        DaoFactory.getBoardDao().BoardCast = txtContext.Text;
    }
}
