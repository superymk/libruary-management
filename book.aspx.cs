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
            
            try
            {
                Int32 id = Int32.Parse(Request.QueryString["id"]);
                reload(id);
            }
            catch (Exception )
            {
                btnUpdate.Visible = false;
                
            }

            SessionData sd = Session[SessionData.SessionName] as SessionData;
            User user = sd.CurrentUser;
            IUserDao userdao=DaoFactory.getUserDao();
            if (userdao.isAdmin(user.IdUser))
            {
                btnAdd.Visible = true;
                btnUpdate.Visible = true;
            }
            else
            {
                btnAdd.Visible = false;
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
            comments.Visible = true;

            BookComment tac = new BookComment();
            tac.IdBook = id;
            IBCommentDao acd = DaoFactory.getBookCommentDao();
            IList<BaseObject> list = acd.find(tac);
            for (int i = 0; i < list.Count; i++)
            {
                BookComment comment = (BookComment)list[i];
                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                Label box = new Label();
                User cuser = (User)dao.getById(comment.IdUser);
                box.Text = "<a href=user.aspx?id=" + comment.IdUser + " >" + cuser.Username + "</a> :" + comment.Comment;
                cell1.Controls.Add(box);
                row.Controls.Add(cell1);
                comments.Controls.Add(row);
                //description.Text += u.ToString();
            }
        }



        protected void update(object sender, EventArgs e)
        {
            Book b = new Book();
            try
            {
                b.IdBook = Int32.Parse(txtIdBook.Text);
            }
            catch (FormatException)
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
            catch (FormatException)
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
            catch (FormatException)
            {
                
                return;
            } 
            b.PublishCompany = txtPublishCompany.Text;
            b.Type = txtType.Text;

            b.State= ddlState.SelectedValue;
            
            DaoFactory.getBookDao().add(b);
            Response.Redirect("book.aspx" );
        }

        protected void borrow(object sender, EventArgs e)
        {
            SessionData sd = Session[SessionData.SessionName] as SessionData;
            if (sd == null||sd.CurrentUser==null)
            {
                Response.Write("<script>alert('请登陆')</script>");
                return;
            }
            //SessionData.getInstance().CurrentUser = sd.CurrentUser;

            IBorrowDao dao = DaoFactory.getBorrowDao();
            try
            {
                //dao.RegisteByName(sd.CurrentUser.Username, txtBookName.Text);

                dao.RegisteById(sd.CurrentUser.IdUser,int.Parse(txtIdBook.Text));
            }
            catch (DaoException)
            {
                Response.Write("<script>alert('图书已被借阅,或者图书或用户不存在')</script>");
                return;
            }
            Response.Redirect("borrowlist.aspx");

        }

        protected void addComment(object sender, EventArgs e)
        {
            SessionData sd = Session[SessionData.SessionName] as SessionData;
            User u = sd.CurrentUser;
            IUserDao dao = DaoFactory.getUserDao();
            int uid = dao.confirmUser(u.Username, u.Password);
            int idBook = -1;
            try
            {
                idBook = Int32.Parse(txtIdBook.Text);
            }
            catch (FormatException)
            { return; }
            DateTime now = DateTime.Now;
            BookComment comment = new BookComment();
            comment.IdUser = uid;
            comment.IdBook = idBook;
            comment.Comment = newCBox.Text;
            comment.CommentDate = now;
            DaoFactory.getBookCommentDao().add(comment);
            reload(idBook);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("borrowlist.aspx");
        }
        protected void btnAddCart_Click(object sender, EventArgs e)
        {
            int idBook = int.Parse(txtIdBook.Text);
            SessionData sd = Session[SessionData.SessionName] as SessionData;
            
            BorrowCart cart = sd.Cart;
            if (cart == null) cart = new BorrowCart();
            cart.addById(idBook);
            sd.Cart = cart;
            Session[SessionData.SessionName] = sd;

            Response.Redirect("borrowcart.aspx");
        }
}
