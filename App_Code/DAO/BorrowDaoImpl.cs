using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
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
}
