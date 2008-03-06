using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;


public class BookDaoImpl : BaseDao, IBookDao
{
    public BookDaoImpl(){
        relateTable = "bookstable";
        key = "IdBook";
        objectName = "Book";
    }
}

