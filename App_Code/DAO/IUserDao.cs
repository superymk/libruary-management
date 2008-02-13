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

/// <summary>
/// UserDao 的摘要说明
/// </summary>
public interface IUserDao
{
    int confirmUser(string username, string password);
    bool registerUser(User user,Label l);
    bool deleteUser(int idUser);
    bool updateUser(User user, Label l);
    IList<User> findUser(User information);
}
