using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class searchbook : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            //                txtComment.Text = "postBack";
            return;
        }
        search(sender, e);

    }

    private void gridViewBind(Book b)
    {
        
        IBaseDao bookdao = DaoFactory.getBookDao();
        DataSet ds = bookdao.findDataSet(b);
        GridView1.DataSource = ds;
        GridView1.DataBind();

    }
    protected void search(object sender, EventArgs e)
    {
        SessionData sd = Session[SessionData.SessionName]as SessionData;
        if (sd == null) sd = new SessionData();
        Book b = sd.SearchBook;
        if (b==null )b=new Book();

        IBookDao dao = DaoFactory.getBookDao();
        

        gridViewBind(b);

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
