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
        try
        {
            Int32 id = Int32.Parse(Request.QueryString["id"]);
            reload(id);
        }
        catch (Exception ee)
        {
            SessionData sd = Session[SessionData.SessionName] as SessionData;
            if (sd != null && sd.CurrentUser != null)
            {
                //User u =(User) Session["user"];
                //Response.Write(u.Username+"<br/>");
                //Response.Write(u.Password);

                User u = sd.CurrentUser;
                if (!(u.Username == null || u.Username.Equals("") || u.Password == null || u.Password.Equals("")))
                {
                    IUserDao dao = DaoFactory.getUserDao();
                    int id = dao.confirmUser(u.Username, u.Password);
                    if (id != -1)
                    {
                        reload(id);
                    }
                    return;
                }

            }
            else
            {
                updateConfirm.Visible = false;
                searchConfirm.Visible = false;
            }
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
        DaoFactory.getUserDao().add(u);

        SessionData sd = Session[SessionData.SessionName] as SessionData;
        sd.CurrentUser = u;
        Session[SessionData.SessionName] = sd;
        Response.Redirect("default.aspx");
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
        int admin = dao.isAdmin(u.IdUser);
        if (admin != 0)
        {
            comments.Visible = true;
            ToAdminComment tac = new ToAdminComment();
            tac.IdAdmin = id;
            IACommentDao acd = DaoFactory.getIACommentDao();
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
                //description.Text += u.ToString();
            }
        }
        else
        {
            comments.Visible = false;
        }
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
        for(int i=0; i<list.Count; i++){
            User user = (User)list[i];
            TableRow row = new TableRow();
            TableCell cell1 = new TableCell();
            Label box = new Label();
            box.Text = "<a href=user.aspx?id="+user.IdUser+" >"+user.Username+"</a>";
            cell1.Controls.Add(box);
            row.Controls.Add(cell1);
            users.Controls.Add(row);
        }

        IUserDao userdao=DaoFactory.getUserDao();
        DataSet ds = userdao.findDataSet(u);
        GridView1.DataSource = ds;
        GridView1.DataBind();
        
    }

    protected void addComment(object sender, EventArgs e)
    {
        SessionData sd = Session[SessionData.SessionName] as SessionData;
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
        DaoFactory.getIACommentDao().add(comment);
        reload(idAdmin);
    }


    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        search(sender, e);
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        search(sender, e);
    }
}
