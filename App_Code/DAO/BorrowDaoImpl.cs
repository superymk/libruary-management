using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Collections.Generic;

public class BorrowDaoImpl : BaseDao, IBorrowDao
{
    public double DeadLinePeriod
    {
        get
        {
            return 10;
        }
    }

    public BorrowDaoImpl()
    {
        relateTable = "borrowtable";
        key = "";
        objectName = "Borrow";
    }

    public void RegisteById(int idUser,int idBook){
        Borrow borrow = new Borrow();
        borrow.IdBook = idBook;
        borrow.IdUser = idUser;
        borrow.DeadLine = DateTime.Today.AddDays(this.DeadLinePeriod);

        IBaseDao bookdao = DaoFactory.getBookDao();
        Book book = bookdao.getById(idBook)as Book;
        if (book!=null&&!book.State.Trim().ToUpper().Equals(Book.Free))
            throw new DaoException("Book " + book.BookName + "is not free");
        book.State = Book.Borrowed;
        bookdao.update(book);

        DaoFactory.getBorrowDao().register(borrow);
    }

    public void RegisteByName(string userName, string bookName)
    {
        Book book = new Book();
        book.BookName = bookName;
        IList<BaseObject> list = DaoFactory.getBookDao().find(book);
        if (list.Count != 1) throw new DaoException("Can't find Book:" + bookName);
        book = (Book)list[0];
        if (book.BookName == null || book.BookName.Equals("")) throw new DaoException("Can't find Book:" + bookName);

        User user = new User();
        user.Username = userName;
        list = DaoFactory.getUserDao().find(user);
        if (list.Count != 1) throw new DaoException("Can't find User:" + userName);
        user = (User)list[0];
        if (user.Username == null || user.Username.Equals("")) throw new DaoException("Can't find User:" + userName);

        RegisteById(user.IdUser,book.IdBook);
    }

    public void ReturnBookById(int userId, int bookId)
    {
        SqlConnection sconn = new SqlConnection(connsql);
        SqlCommand cmd = new SqlCommand();
        sconn.Open();
        cmd.Connection = sconn;
        cmd.CommandText = "delete from borrowtable where idBook='" + bookId + "' and idUser='" + userId + "'";
         cmd.ExecuteNonQuery();
        
        sconn.Close();
        return ;
    }
}
