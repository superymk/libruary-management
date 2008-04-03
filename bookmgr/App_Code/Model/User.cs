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
/// User 的摘要说明
/// </summary>
public class User : BaseObject
{
    private int idUser;

    public int IdUser
    {
        get { return idUser; }
        set { idUser = value; }
    }

    private string username;

    public string Username
    {
        get { return username; }
        set { username = value; }
    }

    private string password;

    public string Password
    {
        get { return password; }
        set { password = value; }
    }

    private string trueName;

    public string TrueName
    {
        get { return trueName; }
        set { trueName = value; }
    }

    private string college;

    public string College
    {
        get { return college; }
        set { college = value; }
    }

    private string address;

    public string Address
    {
        get { return address; }
        set { address = value; }
    }

    private DateTime birthday;

    public DateTime Birthday
    {
        get { return birthday; }
        set { birthday = value; }
    }

    private string sex;

    public string Sex
    {
        get { return sex; }
        set { sex = value; }
    }

    private string email;

    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    private string telnumber;

    public string Telnumber
    {
        get { return telnumber; }
        set { telnumber = value; }
    }

    private string description;

    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    private int mark;

    public int Mark
    {
        get { return mark; }
        set { mark = value; }
    }

	public User()
	{
        
	}
}
