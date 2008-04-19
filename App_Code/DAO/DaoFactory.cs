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
/// DaoFactory 非强制性的Dao对象的Singleton Factory
/// </summary>
public class DaoFactory
{
	public DaoFactory(){
	}

    private static IUserDao userDao = null;
    public static IUserDao getUserDao()
    {
        return (userDao!=null)?userDao:userDao=new UserDaoImpl();
    }

    private static IBookDao bookDao = null;
    public static IBookDao getBookDao()
    {
        return (bookDao != null) ? bookDao : bookDao = new BookDaoImpl();
    }

    private static IBorrowDao borrowDao = null;
    public static IBorrowDao getBorrowDao()
    {
        return (borrowDao != null) ? borrowDao : borrowDao = new BorrowDaoImpl();
    }

    private static IACommentDao aCommentDao = null;
    public static IACommentDao getAdminCommentDao()
    {
        return (aCommentDao != null) ? aCommentDao : aCommentDao = new ACommentDaoImpl();
    }

    private static IBCommentDao bookCommentDao = null;
    public static IBCommentDao getBookCommentDao()
    {
        return (bookCommentDao != null) ? bookCommentDao : bookCommentDao = new BCommentDaoImpl();
    }

    private static IBoardDao boardDao = null;
    public static IBoardDao getBoardDao()
    {
        return (boardDao != null) ? boardDao : boardDao = new BoardDaoImpl();
    }
}
