using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// DaoFactory 的摘要说明
/// </summary>
public class DaoFactory
{
	public DaoFactory(){
	}

    public static IUserDao getUserDao()
    {
        return new UserDaoImpl();
    }

    public static IBookDao getBookDao()
    {
        return new BookDaoImpl();
    }

    public static IBorrowDao getBorrowDao()
    {
        return new BorrowDaoImpl();
    }
}
