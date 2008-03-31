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
/// SessionData 的摘要说明
/// </summary>
public class SessionData
{
    private static SessionData instance;
    private User currentUser;

	private SessionData(){}
    public static SessionData getInstance() {
        if (instance == null)
            instance = new SessionData();
        return instance;
    }


    public User CurrentUser
    {
        get { return currentUser; }
        set { currentUser = value; }
    }

    
}
