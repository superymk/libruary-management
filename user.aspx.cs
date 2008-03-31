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
            return;
        }
        string mode = Request.QueryString["mode"];
        if (mode!=null && mode.Equals("search"))
        {
            searchMode();
            return;
        } if (mode != null && mode.ToLower().Equals("searchall"))
        {
            searchMode();
            search(sender, e);
            return;

        }
        try{
            Int32 id = Int32.Parse(Request.QueryString["id"]);
            reload(id);
        }catch (Exception ee)
        {
            updateConfirm.Visible = false;
            searchConfirm.Visible = false;
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
        DaoFactory.getUserDao().register(u);
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
        DaoFactory.getUserDao().update(u);
        reload(u.IdUser);
        //Response.Redirect("default.aspx?name=" + u.Password);
    }

    private void reload(int id)
    {
        IUserDao dao = DaoFactory.getUserDao();
        User u = (User)dao.getById(id);
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
        searchConfirm.Visible = false;
    }

    private void searchMode()
    {
        updateConfirm.Visible = false;
        registerConfirm.Visible = false;
        password.Visible = false;
        password2.Visible = false;
        Label1.Visible = false;
        Label2.Visible = false;
    }

    protected void search(object sender, EventArgs e) {
        User u = new User();
        u.Username = username.Text;
        u.Password = password.Text;
        u.TrueName = trueName.Text;
        u.College = college.Text;
        u.Address = address.Text;
        u.Sex = sex.Text;
        u.Email = email.Text;
        u.Description = description.Text;
        try
        {
            u.Birthday = DateTime.Parse(birthday.Text);
        }
        catch (FormatException ee){}
        IUserDao dao = DaoFactory.getUserDao();
        IList<BaseObject> list = dao.find(u);
        //username.Text = list.Count+"";
        for(int i=0; i<list.Count; i++){
            User user = (User)list[i];
            TableRow row = new TableRow();
            TableCell cell1 = new TableCell();
            Label box = new Label();
            box.Text = "<a href=user.aspx?id="+user.IdUser+" >"+user.Username+"</a>";
            cell1.Controls.Add(box);
            row.Controls.Add(cell1);
            users.Controls.Add(row);
            //description.Text += u.ToString();
        }
        
    }
}
