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
/// Summary description for BookComment
/// </summary>
public class BookComment : BaseObject
{
	public BookComment(){}
    int idBook;
    public int IdBook
    {
        get { return idBook; }
        set { idBook = value; }
    }

    int idUser;
    public int IdUser
    {
        get { return idUser; }
        set { idUser = value; }
    }

    string comment;
    public string Comment
    {
        get { return comment; }
        set { comment = value; }
    }

    DateTime commentDate;
    public DateTime CommentDate
    {
        get { return commentDate; }
        set { commentDate = value; }
    }
}
