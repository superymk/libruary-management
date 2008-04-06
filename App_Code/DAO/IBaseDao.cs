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
    bool add(BaseObject user);
    bool delete(int id);
    bool delete(int[] ids);
    bool update(BaseObject user);
    BaseObject getById(int id);
    BaseObject getById(int[] ids);
    IList<BaseObject> find(BaseObject information);
    DataSet getDataSet();
    
}
