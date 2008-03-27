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
using System.Data.Common;
using System.Collections.Generic;

public partial class borrow : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }
        string mode = Request.QueryString["mode"];
        if (mode != null && mode.Equals("search"))
        {
            btnUpdate.Visible = false;
            btnRegister.Visible = false;
            return;
        }
        string err = Request.QueryString["err"];
        if (err != null )
        {
            btnUpdate.Visible = false;
            btnRegister.Visible = false;
            Response.Write(err);
            return;
        }
        try
        {
            Int32 id = Int32.Parse(Request.QueryString["id"]);
            //reload(id);
        }
        catch (Exception ee)
        {
            btnSearch.Visible = false;
            btnUpdate.Visible = false;
        }
    }
    protected void register(object sender, EventArgs e)
    {

        BorrowDaoImpl bDao = (BorrowDaoImpl)DaoFactory.getBorrowDao();
        try
        {
            bDao.RegisteByName(txtUserName.Text, txtBookName.Text);
        }
        catch (DaoException de)
        {
            Response.Redirect("borrow.aspx?err="+de.Message);
        }
       
        Response.Redirect("borrow.aspx?mode=search");
    }
    protected void Search(object sender, EventArgs e)
    {

        Borrow b = new Borrow();
        IBorrowDao dao = DaoFactory.getBorrowDao();
        IBookDao bookDao = DaoFactory.getBookDao();
        IUserDao userDao = DaoFactory.getUserDao();
        IList<BaseObject> list = dao.find(b);

        for (int i = 0; i < list.Count; i++)
        {
            Borrow borrow = (Borrow)list[i];
            TableRow row = new TableRow();
            TableCell cell1 = new TableCell();
            Label box = new Label();

            Book book =(Book) bookDao.getById(borrow.IdBook);
            User user =(User) userDao.getById(borrow.IdUser);

            box.Text = "<a href=book.aspx?id=" + book.IdBook + " >" + book.BookName + "</a>";
            box.Text += " - <a href=user.aspx?id=" + user.IdUser + " >" + user.Username + "</a>";

            cell1.Controls.Add(box);
            row.Controls.Add(cell1);
            tblBorrow.Controls.Add(row);

        }

    }
}
