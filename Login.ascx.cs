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
        if (sd != null&&sd.CurrentUser!=null)
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

        txtUsername.Enabled = true;
        txtPassword.Enabled = true;
        
        txtPassword.Attributes["value"] = "guest";
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

        IUserDao dao=DaoFactory.getUserDao();
        int id = dao.confirmUser(name, psw);
        if (id == -1)
        {
            Response.Write("<script>alert('用户名或密码错误')</script>");
            return;
        }
        u = dao.getById(id)as User;

        if (u.Mark < 0)
        {
            Response.Write("<script>alert('您的用户积分已低于0分，请与系统管理员联系！')</script>");
            return;
        }

        SessionData sd = Session[SessionData.SessionName] as SessionData;
        if (sd == null) sd = new SessionData();
        sd.CurrentUser = u;
        Session[SessionData.SessionName] = sd;
        Response.Redirect("booklist.aspx");
        
    }
    protected void logout(object sender, EventArgs e)
    {
        Session[SessionData.SessionName] = null;
        Response.Redirect(Request.RawUrl);   
        
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        
        Response.Redirect("User.aspx");
    }
}
