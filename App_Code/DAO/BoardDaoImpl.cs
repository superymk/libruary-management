using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Data.SqlClient;


/// <summary>
/// BoardDaoImpl 的摘要说明
/// </summary>
public class BoardDaoImpl: BaseDao, IBoardDao
{
	public BoardDaoImpl()
	{
        relateTable = "board";
        key = new string[] {"Context" };
        objectName = "Board";
        autoKey = false;
	}
    public string BoardCast
    {
        get{
            IList<BaseObject> blist = find(new Board());
            if (blist.Count != 0)
                return ((blist[blist.Count-1]) as Board).Context;
            else
                return "";
        }
        set
        {
            Board b=new Board();
            b.Context=value;
            update(b);
        }
    }

    public override bool update(BaseObject obj)
    {
        SqlConnection sconn = new SqlConnection(connsql);
        SqlCommand cmd = new SqlCommand();
        sconn.Open();
        cmd.Connection = sconn;
        string command = "update " + relateTable + " set ";
        command += "context='"+(obj as Board).Context+"' ";
        
        cmd.CommandText = command;
        int result = cmd.ExecuteNonQuery();
        return result != 0;
    }

}
