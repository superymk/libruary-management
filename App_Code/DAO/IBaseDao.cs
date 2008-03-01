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
/// IBaseDao 的摘要说明
/// </summary>
public interface IBaseDao
{
    bool register(BaseObject user);
    bool delete(int id);
    bool update(BaseObject user);
    User getById(int id);
    IList<User> find(BaseObject information);
}
