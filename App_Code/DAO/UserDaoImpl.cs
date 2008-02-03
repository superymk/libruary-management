using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// UserDaoImpl 的摘要说明
/// </summary>
public class UserDaoImpl : IUserDao
{
    private string connsql = "server=.\\sqlexpress;uid=sa;pwd=admin1;database=libruary";
	public UserDaoImpl()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}



    #region UserDao 成员

    public bool confirmUser(string username, string password)
    {
        SqlConnection sconn = new SqlConnection(connsql);
        SqlCommand cmd = new SqlCommand();
        sconn.Open();
        cmd.Connection = sconn;
        cmd.CommandText = "select * from userinformation where username='" + username + "' and password='" + password+"'";
        //Console.WriteLine(cmd.CommandText);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read()) {
            int userid = (int)reader["idUser"];
            //save the userid in somewhere
            return true;
        }
        return false;
    }

    #endregion
}
