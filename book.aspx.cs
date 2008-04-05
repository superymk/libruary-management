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


    public partial class book : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
//                txtComment.Text = "postBack";
                return;
            }
            string mode = Request.QueryString["mode"];
            if (mode != null && mode.Equals("search"))
            {
                btnAdd.Visible = false;
                btnUpdate.Visible = false;
                return;
            } if (mode != null && mode.ToLower().Equals("searchall"))
            {
                btnUpdate.Visible = false;
                btnAdd.Visible = false;
                search(sender, e);
                return;

            }
            try
            {
                Int32 id = Int32.Parse(Request.QueryString["id"]);
                reload(id);
            }
            catch (Exception )
            {
                btnSearch.Visible = false;
                btnUpdate.Visible = false;
                
            }
        }

        private void reload(int id)
        {
            IBookDao dao = DaoFactory.getBookDao();
            Book b = (Book)dao.getById(id);
            txtIdBook.Text = b.IdBook.ToString();
            txtBookName.Text = b.BookName;
            txtComment.Text = b.Comment;
            txtAbstract.Text = b.Abstract;
            txtAuthor.Text = b.Author;
            txtDonatePerson.Text = b.DonatePerson;
            txtNumCopies.Text = b.NumCopies.ToString();
            txtPublishCompany.Text = b.PublishCompany;
            txtType.Text = b.Type;

            ddlState.SelectedValue = b.State.Trim();

            btnAdd.Visible = false;
            btnSearch.Visible = false;
        }


        protected void search(object sender, EventArgs e)
        {
            Book b = new Book();

            try
            {
                b.IdBook = Int32.Parse(txtIdBook.Text);
            }
            catch (FormatException )
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
            catch (FormatException )
            {
                b.NumCopies = 0;
            }
            b.PublishCompany = txtPublishCompany.Text;
            b.Type = txtType.Text;
            b.State = ddlState.SelectedValue;

            IBookDao dao = DaoFactory.getBookDao();
            IList<BaseObject> list = dao.find(b);
            
            for (int i = 0; i < list.Count; i++)
            {
                Book book = (Book)list[i];
                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                Label box = new Label();
                box.Text = "<a href=book.aspx?id=" + book.IdBook + " >" + book.BookName + "</a>";
                cell1.Controls.Add(box);
                row.Controls.Add(cell1);
                books.Controls.Add(row);
                
            }

        }

        protected void update(object sender, EventArgs e)
        {
            Book b = new Book();
            try
            {
                b.IdBook = Int32.Parse(txtIdBook.Text);
            }
            catch (FormatException ee)
            {
                Response.Write("<script>alert('idBook格式错误')</script>");
                return;
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
            catch (FormatException ee)
            {
                Response.Write("<script>alert('NumCopies格式错误')</script>");
                return;
            }
            b.PublishCompany = txtPublishCompany.Text;
            b.Type = txtType.Text;
            b.State = ddlState.SelectedValue;
            DaoFactory.getBookDao().update(b);
            reload(b.IdBook);
            
        }

        protected void register(object sender, EventArgs e)
        {
            Book b = new Book();
            b.BookName = txtBookName.Text;
            b.Abstract = txtAbstract.Text;
            b.Author = txtAuthor.Text;
            b.Comment = txtComment.Text;
            b.DonatePerson = txtDonatePerson.Text;
            try
            {
                Response.Write("<script>alert('NumCopies格式错误')</script>");
                b.NumCopies = int.Parse(txtNumCopies.Text);
            }
            catch (FormatException ee)
            {
                
                return;
            } 
            b.PublishCompany = txtPublishCompany.Text;
            b.Type = txtType.Text;

            b.State= ddlState.SelectedValue;
            
            DaoFactory.getBookDao().add(b);
            Response.Redirect("book.aspx?mode=search" );
        }

        protected void borrow(object sender, EventArgs e)
        {
            SessionData sd = Session[SessionData.SessionName] as SessionData;
            if (sd == null)
            {
                Response.Write("<script>alert('请登陆')</script>");
                return;
            }
            SessionData.getInstance().CurrentUser = sd.CurrentUser;

            IBorrowDao dao = DaoFactory.getBorrowDao();
            try
            {
                dao.RegisteByName(sd.CurrentUser.Username, txtBookName.Text);
            }
            catch (DaoException)
            {
                Response.Write("<script>alert('图书不存在')</script>");
                return;
            }
            Response.Redirect("borrow.aspx?mode=searchall");

        }
}
