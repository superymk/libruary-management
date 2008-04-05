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
/// ACommentDaoImpl 的摘要说明
/// </summary>
public class ACommentDaoImpl : BaseDao, IACommentDao
{
	public ACommentDaoImpl()
	{
        relateTable = "toadmincomment";
        key = new string[]{"IdUser","IdAdmin","CommentDate"};
        objectName = "ToAdminComment";
        autoKey = false;
	}

    
}
