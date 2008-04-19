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
/// Board 的摘要说明
/// </summary>
public class Board:BaseObject
{
    private string context="";
    public string Context
    {
        get
        {
            return context;
        }
        set
        {
            context = value;
        }
    }
	public Board()
	{
		
	}
}
