using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Redirect("index.aspx");


        //lblmessage.text = "hello world";
        //sessiondata sd = session[sessiondata.sessionname] as sessiondata;
        //if (sd != null)
        //{
        //    user u = sd.currentuser;
        //    username.text = u.username;
        //    password.text = u.password;
        //    lblmessage.text = "hello " + u.username;
        //}
        
    }
    protected void Log_In(object sender, EventArgs e)
    {
        string name = username.Text;
        string psw = password.Text;
        
        IUserDao dao = new UserDaoImpl();
        int id = dao.confirmUser(name, psw);


        User u = new User();
        u.Username = name;
        u.Password = psw;
        SessionData sd = Session[SessionData.SessionName] as SessionData;
        if(sd==null)sd = new SessionData();
        sd.CurrentUser = u;
        Session[SessionData.SessionName] = sd;

        if (id!=-1)
        {
            //Response.Redirect("user.aspx?id=" + id);
            Response.Redirect("user.aspx");
        }
        else
        {
            lblMessage.Text = "username or password wrong";
        }
        
    }
    protected void offline(object sender, EventArgs e)
    {
        Session["SectionData"] = null;
    }
}
