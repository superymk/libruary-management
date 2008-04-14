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
public partial class booklist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SessionData sd = Session[SessionData.SessionName] as SessionData;
        if (sd == null || sd.CurrentUser == null)
            Response.Redirect("Default.aspx");
        gridViewBind(new Book());
        
    }


    private void gridViewBind(Book b)
    {
        IBaseDao bookdao = DaoFactory.getBookDao();
        DataSet ds = bookdao.findDataSet(b);
        GridView1.DataSource = ds;
        //IList<Book> list = bookdao.find(b);
        //GridView1.DataSource = list.to;
        IUserDao userdao = DaoFactory.getUserDao();
        SessionData sd = Session[SessionData.SessionName] as SessionData;
        User user = sd.CurrentUser;
        if (userdao.isAdmin(user.IdUser))
        {
            GridView1.Columns[GridView1.Columns.Count - 1].Visible = true;
        }
        else
        {
            GridView1.Columns[GridView1.Columns.Count - 1].Visible = false;
        }

        GridView1.DataBind();

        if (ds.Tables.Count == 0)
        {
            lblMessage.Text = "书库为空！";
        }

    }


    protected void search(object sender, EventArgs e)
    {
        Book b = new Book();

        try
        {
            b.IdBook = Int32.Parse(txtIdBook.Text);
        }
        catch (FormatException)
        {
            b.IdBook = 0;
        }

        b.BookName = txtBookName.Text;
        b.Comment = txtComment.Text;
        b.Abstract = txtAbstract.Text;
        b.Author = txtAuthor.Text;
        b.DonatePerson = txtDonatePerson.Text;
        try
        {
            b.NumCopies = int.Parse(txtNumCopies.Text);
        }
        catch (FormatException)
        {
            b.NumCopies = 0;
        }
        b.PublishCompany = txtPublishCompany.Text;
        b.Type = txtType.Text;
        b.State = ddlState.SelectedValue;


        gridViewBind(b);

    }



    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        string idstr = GridView1.Rows[e.NewSelectedIndex].Cells[0].Text;
        Response.Redirect("book.aspx?id=" + idstr);
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        gridViewBind(new Book());
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        string idstr = GridView1.Rows[e.RowIndex].Cells[0].Text;
        int id = int.Parse(idstr);
        IBaseDao bookdao = DaoFactory.getBookDao();
        bookdao.delete(id);
        GridView1.Rows[e.RowIndex].Visible = false;
        gridViewBind(new Book());
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        gridViewBind(new Book());
    }
    protected void showSearch_Click(object sender, EventArgs e)
    {
        panelSearch.Visible = !panelSearch.Visible;
    }
}
