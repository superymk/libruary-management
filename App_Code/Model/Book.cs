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
/// Book 的摘要说明
/// </summary>
public class Book : global::BaseObject
{
    /// <summary>
    /// abstract is the reserved string in csharp so the field of the Abstract is bookAbstract
    /// </summary>
    /// <remarks>abstract is the reserved string in csharp so the field of the Abstract is bookAbstract</remarks>
    private string bookAbstract;
    private string author;
    private string bookName;
    private string comment;
    private string donatePerson;
    private int idBook;
    private int numCopies;
    private string publishCompany;
    private string state;
    private string type;

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



    public int IdBook
    {
        get
        {
            return idBook;
        }
        set
        {
            idBook = value;
        }
    }

    public string Type
    {
        get
        {
            return type;
        }
        set
        {
            type = value;
        }
    }

    public int NumCopies
    {
        get
        {
            return numCopies;
        }
        set
        {
            numCopies = value;
        }
    }

    public string Abstract
    {
        get
        {
            return bookAbstract;
        }
        set
        {
            bookAbstract = value;
        }
    }

    public string Author
    {
        get
        {
            return author;
        }
        set
        {
            author = value;
        }
    }

    public string PublishCompany
    {
        get
        {
            return publishCompany;
        }
        set
        {
            publishCompany = value;
        }
    }

    public string Comment
    {
        get
        {
            return comment;
        }
        set
        {
            comment = value;
        }
    }

    public string DonatePerson
    {
        get
        {
            return donatePerson;
        }
        set
        {
            donatePerson = value;
        }
    }

    public string State
    {
        get
        {
            return state;
        }
        set
        {
            state = value;
        }
    }

    public string BookName
    {
        get
        {
            return bookName;
        }
        set
        {
            bookName = value;
        }
    }
}
