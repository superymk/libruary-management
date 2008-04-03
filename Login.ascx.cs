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

public partial class Login : System.Web.UI.UserControl
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        SessionData sd = Session[SessionData.SessionName] as SessionData;
        if (sd != null)
        {
            User u = sd.CurrentUser;
            txtUsername.Text = u.Username;
            txtUsername.Enabled = false;
            txtPassword.Text = u.Password;
            txtPassword.Attributes["value"] = u.Password;
            txtPassword.Enabled = false;
            btnLogin.Enabled = false;
            btnLogout.Enabled = true;
            return;
        }
        btnLogout.Enabled = false;
        btnLogin.Enabled = true;
     
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string name = txtUsername.Text;
        string psw = txtPassword.Text;
        User u = new User();
        u.Username = name;
        u.Password = psw;
        SessionData sd = SessionData.getInstance();
        sd.CurrentUser = u;
        Session[SessionData.SessionName] = sd;
        Response.Redirect(Request.RawUrl);
        
    }
    protected void logout(object sender, EventArgs e)
    {
        Session[SessionData.SessionName] = null;
        Response.Redirect(Request.RawUrl);   
        
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Session[SessionData.SessionName] = null;
        Response.Redirect("User.aspx");
    }
}
