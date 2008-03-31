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
        
        lblMessage.Text = "Hello World";
        
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
        Session["user"] = u;

        if (id!=-1)
        {
            
            Response.Redirect("user.aspx?id=" + id);
        }
        else
        {
            lblMessage.Text = "username or password wrong";
        }
        
    }
    protected void offline(object sender, EventArgs e)
    {
        Session["user"] = null;
    }
}
