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
/// UserDao 的摘要说明
/// </summary>
public interface IUserDao
{
    bool confirmUser(string username, string password);
}
