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
using System.Data.SqlClient;

public partial class test : System.Web.UI.Page
{
    protected void btnCounter_OnClick(object sender, EventArgs e)
    {
        btnCounter.Text = "Clicked";
        User u = new User();
        u.IdUser = 6;
        u.Username = "as";
        u.Password = "b";
        //u.Birthday = DateTime.Now;
        u.Sex = "female";
        IUserDao dao = new UserDaoImpl();
        String s = new String("a".ToCharArray());
        try
        {
            bool result = dao.updateUser(u,lblMessage);
            lblMessage.Text = result+"";
        }
        catch (SqlException ex) { lblMessage.Text += "\n" + ex.Message; }
    }
    protected void Page_Load()
    {
        lblMessage.Text += "Hello World!";
    }
}
