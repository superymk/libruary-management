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
        u.Sex = DropDownList1.SelectedValue.Equals("") ? null : DropDownList1.SelectedValue;
        u.Email = email.Text;
        u.Description = description.Text;
        try
        {
            u.Birthday = DateTime.Parse(birthday.Text);
        }
        catch (FormatException) { }
        IUserDao dao = DaoFactory.getUserDao();
        DataSet ds = dao.findDataSet(u,"iduser asc");
        GridView1.DataSource = ds;
        GridView1.DataBind();
        foreach (GridViewRow row in GridView1.Rows)
        {
            int iduser = int.Parse(row.Cells[0].Text);
            row.Cells[row.Cells.Count - 3].Text = DaoFactory.getUserDao().isAdmin(iduser) ? "是" : "否";

            int mark = 0;
            int.TryParse(row.Cells[8].Text,out mark);
           
            if (mark < 0)
                row.Cells[8].Attributes.Add("style","color:red");
        }
        
        SessionData sd = Session[SessionData.SessionName] as SessionData;
        if (sd == null)
        {
            Response.Redirect("Default.aspx");
            return;
        }
        GridView1.Columns[GridView1.Columns.Count - 1].Visible = DaoFactory.getUserDao().isAdmin(sd.CurrentUser.IdUser);
       
        if (GridView1.Rows.Count == 0)
        {
            lblMessage.Text = "用户列表为空！";
        }

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

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        string idstr = GridView1.Rows[e.RowIndex].Cells[0].Text;
        int id = int.Parse(idstr);
        IBaseDao userdao = DaoFactory.getUserDao();
        userdao.delete(id);
        GridView1.Rows[e.RowIndex].Visible = false;
        
        Page_Load(sender, new EventArgs());
    }
    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        string idstr = GridView1.Rows[e.NewSelectedIndex].Cells[0].Text;
        Response.Redirect("user.aspx?id=" + idstr);
    }
    protected void btnShowSearch_Click(object sender, EventArgs e)
    {
        panelSearch.Visible = !panelSearch.Visible;
    }
}
