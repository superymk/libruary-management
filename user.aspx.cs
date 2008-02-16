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
using System.Collections.Generic;

public partial class UserManager : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            description.Text = "postBack";
            return;
        }
        try{
            Int32 id = Int32.Parse(Request.QueryString["id"]);
            reload(id);
        }catch (Exception ee)
        {
            updateConfirm.Visible = false;
        }
    }

    protected void register(object sender, EventArgs e)
    {
        User u = new User();
        u.Username = username.Text;
        u.Password = password.Text;
        u.TrueName = trueName.Text;
        u.College = college.Text;
        try {
            u.Birthday = DateTime.Parse(birthday.Text);
        }
        catch (FormatException ee) { }
        u.Address = address.Text;
        u.Sex = sex.Text;
        u.Email = email.Text;
        u.Description = description.Text;
        DaoFactory.getUserDao().registerUser(u);
        Response.Redirect("default.aspx?name="+u.Username);
    }

    protected void update(object sender, EventArgs e)
    {
        User u = new User();
        try
        {
            u.IdUser = Int32.Parse(idUser.Text);
        }
        catch (FormatException ee) {
            description.Text = ee.Message +idUser.Text;
            return;
        }
        u.Username = username.Text;
        u.Password = password.Text;
        u.TrueName = trueName.Text;
        u.College = college.Text;
        u.Address = address.Text;
        u.Sex = sex.Text;
        u.Email = email.Text;
        u.Description = description.Text;
        try {
            u.Birthday = DateTime.Parse(birthday.Text);
        }
        catch (FormatException ee){
            description.Text = ee.Message;
        }
        DaoFactory.getUserDao().updateUser(u);
        reload(u.IdUser);
        //Response.Redirect("default.aspx?name=" + u.Password);
    }

    private void reload(int id)
    {
        IUserDao dao = DaoFactory.getUserDao();
        User u = dao.getUser(id);
        idUser.Text = u.IdUser.ToString();
        username.Text = u.Username;
        //password.Text = password2.Text = u.Password;
        password.Attributes["value"] = password2.Attributes["value"] = u.Password;
        trueName.Text = u.TrueName;
        college.Text = u.College;
        birthday.Text = u.Birthday.ToString();
        address.Text = u.Address;
        sex.Text = u.Sex;
        email.Text = u.Email;
        description.Text = idUser.Text;
        registerConfirm.Visible = false;
    }
}
