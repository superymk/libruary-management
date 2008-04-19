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

public partial class borrowlist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;

        SessionData sd = Session[SessionData.SessionName] as SessionData;
        if (sd == null || sd.CurrentUser == null)
            Response.Redirect("default.aspx");
        User user = sd.CurrentUser;

        if (DaoFactory.getUserDao().isAdmin(user.IdUser))
        {
            try
            {
                Int32 id = Int32.Parse(Request.QueryString["id"]);
                Borrow b = new Borrow();
                b.IdUser = id;
                reload(b);
            }
            catch (Exception)
            {
                if (sd.Alert != null)
                {
                    Response.Write("<script>alert('" + sd.Alert + "')</script>");
                    sd.Alert = null;
                    Session[SessionData.SessionName] = sd;
                }
                reload(new Borrow());
            }
            GridView1.Columns[GridView1.Columns.Count - 1].Visible = true;
            return;
        }
        GridView1.Columns[GridView1.Columns.Count - 1].Visible = false;
        Borrow borrow = new Borrow();
        borrow.IdUser = user.IdUser;
        reload(borrow);
    }
    protected void reload(Borrow borrow)
    {
        IBaseDao borrowdao = DaoFactory.getBorrowDao();

        DataSet ds = borrowdao.findDataSet(borrow,"DeadLine");


        GridView1.DataSource = ds;
        GridView1.DataBind();

        foreach (GridViewRow row in GridView1.Rows)
        {
            string idbookstr = row.Cells[0].Text;
            int idbook = int.Parse(idbookstr);
            string iduserstr = row.Cells[2].Text;
            int iduser = int.Parse(iduserstr);

            IBookDao bookdao = DaoFactory.getBookDao();
            IUserDao userdao = DaoFactory.getUserDao();
            Book book = bookdao.getById(idbook) as Book;
            User user = userdao.getById(iduser) as User;
            row.Cells[1].Text = "<a href='book.aspx?id="+idbook+"'>"+book.BookName+"<a/>";
            row.Cells[3].Text = "<a href='user.aspx?id=" + iduser + "'>" + user.Username + "<a/>";
        }

        if (GridView1.Rows.Count == 0)
        {
            lblMessage.Text = "借书单为空！";
        }
    }

    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        string idstr = GridView1.Rows[e.NewSelectedIndex].Cells[0].Text;
        Response.Redirect("book.aspx?id=" + idstr);
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        Page_Load(sender, e);
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        string idbookstr = GridView1.Rows[e.RowIndex].Cells[0].Text;
        int idbook = int.Parse(idbookstr);
        string iduserstr = GridView1.Rows[e.RowIndex].Cells[2].Text;
        int iduser = int.Parse(iduserstr);

        IBorrowDao borrowdao = DaoFactory.getBorrowDao();
        borrowdao.ReturnBookById(iduser, idbook);

        GridView1.Rows[e.RowIndex].Visible = false;
        Page_Load(sender, new EventArgs());
    }
}
