using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

public class BorrowDaoImpl : BaseDao, IBorrowDao
{
    public BorrowDaoImpl()
    {
        relateTable = "borrowtable";
        key = "IdBook";
        objectName = "Borrow";
    }
}
