using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;



public class BookDaoImpl : BaseDao, IBookDao
{
    public BookDaoImpl(){
        relateTable = "bookstable";
        key = new string[]{"IdBook"};
        objectName = "Book";
    }
    public override bool add(BaseObject book)
    {
        Book bookname=new Book();
        IList<BaseObject> list= base.find(book);
        if (list.Count != 0) return false;
        return base.add(book);
    }

    public static string Free
    {
        get { return "FREE"; }
    }

    public static string Borrowed
    {
        get { return "BORROWED"; }
    }

    public static string Missing
    {
        get { return "MISSING"; }
    }


}

