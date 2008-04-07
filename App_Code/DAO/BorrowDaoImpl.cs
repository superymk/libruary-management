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

    public static int MarkPerBorrow
    {
        get
        {
            return 10;
        }
    }

    public static int TimeLimit
    {
        get
        {
            return 7;
        }
    }

    public BorrowDaoImpl()
    {
        relateTable = "borrowtable";
        key = new string[]{"idBook","idUser"};
        objectName = "Borrow";
        autoKey = false;
    }

    public void RegisteById(int idUser,int idBook){
        Borrow borrow = new Borrow();
        borrow.IdBook = idBook;
        borrow.IdUser = idUser;
        borrow.DeadLine = DateTime.Today.AddDays(this.DeadLinePeriod);

        IBaseDao bookdao = DaoFactory.getBookDao();
        Book book = bookdao.getById(idBook)as Book;
        if (book!=null&&!book.State.Trim().ToUpper().Equals(BookDaoImpl.Free))
            throw new DaoException("Book " + book.BookName + "is not free");
        book.State = BookDaoImpl.Borrowed;
        bookdao.update(book);

        IBaseDao userdao = DaoFactory.getUserDao();
        User user = userdao.getById(idUser) as User;


        DaoFactory.getBorrowDao().add(borrow);
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

        Borrow borrow = getById(new int[] { bookId, userId })as Borrow;
        if (borrow!=null)
        {
            IBaseDao bookdao = DaoFactory.getBookDao();
            Book book = bookdao.getById(bookId)as Book;
            if (book == null) throw new DaoException("Book with id:"+bookId+"didn't exist");

            IBaseDao userdao = DaoFactory.getUserDao();
            User user = userdao.getById(userId)as User;
            if (user == null) throw new DaoException("User with id:" + userId + "didn't exist");

            book.State = BookDaoImpl.Free;
            bookdao.update(book);

            DateTime deadLine = borrow.DeadLine;
            if((deadLine>=DateTime.Now)){
                user.Mark+=MarkPerBorrow+MarkPerBorrow;
            }
            else if ((DateTime.Now - deadLine) <= TimeSpan.FromDays(TimeLimit))
            {
                user.Mark += MarkPerBorrow;
            }
            userdao.update(user);

            delete(new int[] { bookId, userId });
            return;
        }
        throw new DaoException("Borrow with idUser:" + userId + " and idBook:" + bookId + "didn't exist");
    }
    

}
