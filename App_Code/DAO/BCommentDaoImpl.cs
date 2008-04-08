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
/// Summary description for BCommentDaoImpl
/// </summary>
public class BCommentDaoImpl : BaseDao, IBCommentDao
{
	public BCommentDaoImpl()
    {
        relateTable = "bookcomment";
        key = new string[] { "IdBook", "IdUser", "CommentDate" };
        objectName = "BookComment";
        autoKey = false;
	}
}
