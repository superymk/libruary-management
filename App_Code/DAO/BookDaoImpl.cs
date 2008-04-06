using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;


public class BookDaoImpl : BaseDao, IBookDao
{
    public BookDaoImpl(){
        relateTable = "bookstable";
        key = new string[]{"IdBook"};
        objectName = "Book";
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

