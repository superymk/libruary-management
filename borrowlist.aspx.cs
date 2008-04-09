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
        if (IsPostBack)
        {
         
            return;
        }
        SessionData sd = Session[SessionData.SessionName] as SessionData;
        if (sd == null || sd.CurrentUser == null)
            Response.Redirect("default.aspx");
        User user = sd.CurrentUser;
        IUserDao userdao=DaoFactory.getUserDao();

        if (userdao.isAdmin(user.IdUser)==1)
        {
            try
            {
                Int32 id = Int32.Parse(Request.QueryString["id"]);
                reload(id,true);
                return;
            }
            catch (Exception)
            {

            }
        }
        reload(user.IdUser, userdao.isAdmin(user.IdUser) == 1);
    }
    protected void reload(int idUser,bool isAdmin)
    {
        IBaseDao borrowdao = DaoFactory.getBorrowDao();
        Borrow borrow = new Borrow();
        borrow.IdUser = idUser;
        DataSet ds = borrowdao.findDataSet(borrow);

        if (isAdmin)
        {
            GridView1.Columns[GridView1.Columns.Count - 1].Visible = true;
        }
        else
        {
            GridView1.Columns[GridView1.Columns.Count - 1].Visible = false;
        }
        
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
            Book book = bookdao.getById(idbook)as Book;
            User user = userdao.getById(iduser)as User;

            row.Cells[1].Text = book.BookName;
            row.Cells[3].Text = user.Username;
        }
    }

    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        string idstr = GridView1.Rows[e.NewSelectedIndex].Cells[0].Text;
        Response.Redirect("book.aspx?id=" + idstr);
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
