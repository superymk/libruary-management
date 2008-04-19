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
        username.Enabled = true;
        try
        {
            Int32 id = Int32.Parse(Request.QueryString["id"]);
            reload(id);
            SessionData sd = Session[SessionData.SessionName] as SessionData;
            if (sd == null || sd.CurrentUser == null)
            {
                Response.Redirect("default.aspx");
                return;
            }
            
            User u = sd.CurrentUser;
            btnChangeAdmin.Visible = DaoFactory.getUserDao().isAdmin(sd.CurrentUser.IdUser);

            if (!(u.Username == null || u.Username.Equals("") || u.Password == null || u.Password.Equals("")))
            {
                IUserDao dao = DaoFactory.getUserDao();
                int lid = dao.confirmUser(u.Username, u.Password);
                if (lid != -1)
                {
                    updateConfirm.Visible = dao.isAdmin(lid) || lid == id;
                    registerConfirm.Visible = false;
                    return;
                }
            }
            Response.Redirect("default.aspx");
            return;
        }
        catch (Exception)
        {
            SessionData sd = Session[SessionData.SessionName] as SessionData;
            if (sd == null || sd.CurrentUser == null)
            {
                Response.Redirect("default.aspx");
                return;                
            }
            User u = sd.CurrentUser;
            if (!(u.Username == null || u.Username.Equals("") || u.Password == null || u.Password.Equals("")))
            {
                IUserDao dao = DaoFactory.getUserDao();
                int id = dao.confirmUser(u.Username, u.Password);
                if (id != -1 && !dao.isAdmin(id))
                {
                    reload(id);

                }
                else if (id == -1)
                {
                    Response.Redirect("Default.aspx");
                }
                panelComments.Visible = false;
                updateConfirm.Visible = false;
                btnChangeAdmin.Visible = false;
                registerConfirm.Visible = dao.isAdmin(id);
                return;
            }
            else
                Response.Redirect("Default.aspx");
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
        catch (FormatException) { }
        u.Address = address.Text;
        u.Sex = sex.Text;
        u.Email = email.Text;
        u.Description = description.Text;
        u.Mark = DaoFactory.getBorrowDao().InitialMark;
        if (!DaoFactory.getUserDao().add(u)) 
        {
            Response.Write("<script>alert('用户添加错误,可能同名用户已存在')</script>");
            return;
        }
        
        Response.Redirect("user.aspx");
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
        registerConfirm.Visible = false;
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
        
        bool admin = dao.isAdmin(u.IdUser);
        if (admin)
        {
            panelComments.Visible = true;
            ToAdminComment tac = new ToAdminComment();
            tac.IdAdmin = id;
            IACommentDao acd = DaoFactory.getAdminCommentDao();
            IList<BaseObject> list = acd.find(tac);
            for (int i = 0; i < list.Count; i++)
            {
                ToAdminComment comment = (ToAdminComment)list[i];
                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                Label box = new Label();
                User cuser = (User)dao.getById(comment.IdUser);
                box.Text = "<a href=user.aspx?id=" + comment.IdUser + " >" + cuser.Username + "</a> :" + comment.Comment;
                cell1.Controls.Add(box);
                row.Controls.Add(cell1);
                comments.Controls.Add(row);
                
            }
            btnChangeAdmin.Text = "取消管理员";
        }
        else
        {
            btnChangeAdmin.Text = "设置管理员";
            panelComments.Visible = false;
            
        }
        username.Enabled = false;


    }



    protected void addComment(object sender, EventArgs e)
    {
        SessionData sd = Session[SessionData.SessionName] as SessionData;
        if (sd == null) sd = new SessionData();
        User u = sd.CurrentUser;
        IUserDao dao = DaoFactory.getUserDao();
        int uid = dao.confirmUser(u.Username, u.Password);
        int idAdmin = -1;
        try
        {
            idAdmin = Int32.Parse(idUser.Text);
        }
        catch (FormatException ee)
        {
            description.Text = ee.Message + idUser.Text;
            return;
        }
        DateTime now = DateTime.Now;
        ToAdminComment comment = new ToAdminComment();
        comment.IdUser = uid;
        comment.IdAdmin = idAdmin;
        comment.Comment = newCBox.Text;
        comment.CommentDate = now;
        DaoFactory.getAdminCommentDao().add(comment);
        reload(idAdmin);
    }


    protected void ChangeAdmin(object sender, EventArgs e)
    {
        int id =int.Parse( idUser.Text);
        DaoFactory.getUserDao().changeAdmin(id);
        Response.Redirect("userlist.aspx");
    }
}
