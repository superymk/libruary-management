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
/// ToAdminComment 的摘要说明
/// </summary>
public class ToAdminComment : BaseObject
{
	public ToAdminComment() {}

    private int idUser;

    public int IdUser
    {
        get { return idUser; }
        set { idUser = value; }
    }

    private int idAdmin;

    public int IdAdmin
    {
        get { return idAdmin; }
        set { idAdmin = value; }
    }

    private string comment;

    public string Comment
    {
        get { return comment; }
        set { comment = value; }
    }

    private DateTime commentDate;

    public DateTime CommentDate
    {
        get { return commentDate; }
        set { commentDate = value; }
    }

}
