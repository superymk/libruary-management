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
    protected double deadLinePeriod = 10;

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
            //updateConfirm.Visible = false;
            //searchConfirm.Visible = false;
        }
    }
    protected void register(object sender, EventArgs e)
    {
        
        Borrow borrow = new Borrow();

        Book book = new Book();
        book.BookName = txtBookName.Text;
        IList<BaseObject> list = DaoFactory.getBookDao().find(book);
        if (list.Count != 1) Response.Redirect("borrow.aspx?err=\"Can't find Book!");
        book = (Book)list[0];
        if (book.BookName==null||book.BookName.Equals("")) Response.Redirect("borrow.aspx?err=\"Can't find Book!");

        User user = new User();
        user.Username = txtUserName.Text;
        list = DaoFactory.getUserDao().find(user);
        if (list.Count != 1) Response.Redirect("borrow.aspx?err=\"Can't find User!");
        user= (User)list[0];
        if (user.Username == null || user.Username.Equals("")) Response.Redirect("borrow.aspx?err=\"Can't find User!");

        borrow.IdBook = book.IdBook;
        borrow.IdUser = user.IdUser;

        borrow.DeadLine =DateTime.Today.AddDays(deadLinePeriod);

        DaoFactory.getBorrowDao().register(borrow);
        
        
        Response.Redirect("borrow.aspx?mode=search");
    }
}
