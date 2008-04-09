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

public partial class userlist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }
        string mode = Request.QueryString["mode"];
        search(sender, e);
        
    }

    protected void search(object sender, EventArgs e)
    {
        User u = new User();
        u.Username = username.Text;
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
        catch (FormatException ee) { }
        IUserDao dao = DaoFactory.getUserDao();
        IList<BaseObject> list = dao.find(u);
        for (int i = 0; i < list.Count; i++)
        {
            User user = (User)list[i];
            TableRow row = new TableRow();
            TableCell cell1 = new TableCell();
            Label box = new Label();
            box.Text = "<a href=user.aspx?id=" + user.IdUser + " >" + user.Username + "</a>";
            cell1.Controls.Add(box);
            row.Controls.Add(cell1);
            users.Controls.Add(row);
        }

        IUserDao userdao = DaoFactory.getUserDao();
        DataSet ds = userdao.findDataSet(u);
        GridView1.DataSource = ds;
        GridView1.DataBind();

    }


    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        search(sender, e);
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        search(sender, e);
    }
}
