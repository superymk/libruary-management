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

public partial class borrowcart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SessionData sd = Session[SessionData.SessionName] as SessionData;
        if (sd == null||sd.Cart==null)
        {
            lblMessage.Text = "借书车为空";
            btnSubmit.Visible = false;
            return;
        }
        sd.Cart.refresh();
        GridView1.DataSource = sd.Cart.BookList;
        GridView1.DataBind();
        btnSubmit.Visible = true;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SessionData sd = Session[SessionData.SessionName] as SessionData;
        BorrowCart cart = sd.Cart;
        try
        {
            cart.commit(sd.CurrentUser);
        }
        catch (DaoException de)
        {
            Response.Write("<script>alert('"+de.Message+"')</script>");
            Page_Load(sender,e);
            return;            
        }
        Response.Redirect("borrowlist.aspx?id="+sd.CurrentUser.IdUser);
        
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        string idstr = GridView1.Rows[e.RowIndex].Cells[0].Text;
        int id = int.Parse(idstr);
        SessionData sd = Session[SessionData.SessionName] as SessionData;
        BorrowCart cart = sd.Cart;
        cart.cancel(id);
        sd.Cart = cart;
        Session[SessionData.SessionName] = sd;

        Response.Redirect("borrowcart.aspx");
        

    }
}
