using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

public class BorrowCart
{
    private LinkedList<Book> bookList = new LinkedList<Book>();

    public LinkedList<Book> BookList
    {
        get
        {
            return bookList;
        }
    }

    public void addById(int idBook)
    {
        IBaseDao bookdao = DaoFactory.getBookDao();
        Book book = bookdao.getById(idBook)as Book;

        for (LinkedListNode<Book> i = bookList.First; i != null; i = i.Next)
        {
            if (i.Value.IdBook == idBook)
                return;
        }

        bookList.AddLast(book);
    }

    public void commit(User user)
    {
        IBorrowDao borrowdao = DaoFactory.getBorrowDao();

        for (;bookList.Count>0; )
        {
            borrowdao.RegisteById(user.IdUser, bookList.First.Value.IdBook);
            bookList.RemoveFirst();
        }
        
    }
    public void cancel(int idBook)
    {
        for (LinkedListNode<Book> i = bookList.First; i != null; i = i.Next)
        {
            if (i.Value.IdBook == idBook)
            {
                bookList.Remove(i);
                return;
            }
        }
    }
    public void refresh()
    {
        IBookDao bookdao = DaoFactory.getBookDao();
        for (LinkedListNode<Book> i = bookList.First; i != null; i = i.Next)
        {
            i.Value = bookdao.getById(i.Value.IdBook)as Book;
        }
    }

	public BorrowCart()
	{
		
	}
}
