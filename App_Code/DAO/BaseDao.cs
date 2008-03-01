using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Reflection;
using System.Data.SqlClient;
using System.Collections.Generic;

/// <summary>
/// BaseDao 的摘要说明
/// </summary>
public abstract class BaseDao:IBaseDao
{
    protected string connsql = "server=.\\sqlexpress;uid=sa;pwd=admin1;database=libruary";
    protected string relateTable;
    protected string key;

    #region IBaseDao 成员


    public bool register(BaseObject obj)
    {
        SqlConnection sconn = new SqlConnection(connsql);
        SqlCommand cmd = new SqlCommand();
        sconn.Open();
        cmd.Connection = sconn;
        //if (!(user.Birthday > new DateTime())) { user.Birthday = DateTime.Now; }
        //cmd.CommandText = "insert into " + obj.RelateTable + " values('" + user.Username + "','" + user.Password + "','" + user.TrueName + "','"
        //   + user.College + "','" + user.Address + "','" + user.Birthday.ToString() + "','" + user.Sex + "','" + user.Email + "','" + user.Telnumber + "','" + user.Description + "','" + user.Mark + "')";
        //l.Text = cmd.CommandText;
        string command = "insert into " + relateTable + " values (";
        Type t = obj.GetType();
        foreach(PropertyInfo p in t.GetProperties()){
            Type pt = p.PropertyType;
            string name = p.Name;
            object value = p.GetValue(obj,null);
            if ( !name.Equals(key)) {
                if (pt.Equals(typeof(DateTime)))
                {
                    Console.WriteLine("a");
                    if (!((DateTime)value > new DateTime()))
                    {
                        value = DateTime.Now;
                    }
                }
                //if (pt.Equals(typeof(string))) {
                //    value = "'" + value + "'";
                //}
                
                //value += ",";
                command += "'" + value + "',";
            }
        }
        command = command.Remove(command.Length - 1);
        command += ")";
        cmd.CommandText = command;

        int result = cmd.ExecuteNonQuery();
        return result != 0;
    }



    public bool delete(int id)
    {
        SqlConnection sconn = new SqlConnection(connsql);
        SqlCommand cmd = new SqlCommand();
        sconn.Open();
        cmd.Connection = sconn;
        cmd.CommandText = "delete from " + relateTable + " where " + key + " = " + id;
        int result = cmd.ExecuteNonQuery();
        return result != 0;
    }

    public bool update(BaseObject user)
    {
        SqlConnection sconn = new SqlConnection(connsql);
        SqlCommand cmd = new SqlCommand();
        sconn.Open();
        cmd.Connection = sconn;
        if (!(user.Birthday > new DateTime())) { user.Birthday = DateTime.Now; }
        //cmd.CommandText = "update userinformation set username = '"  + user.Username + "' , password = '" + user.Password + "' , trueName = '" + user.TrueName + "' , college = '"
        //    + user.College + "' , address = '" + user.Address + "' , birthday = '" + user.Birthday + "' , sex = '" + user.Sex + "' , email = '" + user.Email + 
        //    "' , telnumber = '" + user.Telnumber + "' , description = '" + user.Description + "' , mark = '" + user.Mark + "' where idUser = "+user.IdUser;
        //l.Text = cmd.CommandText;
        int result = cmd.ExecuteNonQuery();
        return result != 0;
    }

    public User getById(int id)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public IList<User> find(BaseObject information)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    #endregion
}
