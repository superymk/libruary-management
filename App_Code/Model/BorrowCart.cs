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
        BookList.AddLast(book);
    }

    public void commit(User user)
    {
        IBorrowDao borrowdao = DaoFactory.getBorrowDao();

        foreach (Book book in BookList)
        {
            borrowdao.RegisteById(user.IdUser, book.IdBook);
        }
        bookList = new LinkedList<Book>();
    }
    public void cancel(int idBook)
    {
        for (LinkedListNode<Book> i = bookList.First; i != null; i = i.Next)
        {
            if (i.Value.IdBook == idBook)
                bookList.Remove(i);
        }
    }

	public BorrowCart()
	{
		
	}
}
