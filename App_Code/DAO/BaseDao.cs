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
    protected string objectName;

    #region IBaseDao 成员


    public bool register(BaseObject obj)
    {
        SqlConnection sconn = new SqlConnection(connsql);
        SqlCommand cmd = new SqlCommand();
        sconn.Open();
        cmd.Connection = sconn;
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

    public bool update(BaseObject obj)
    {
        SqlConnection sconn = new SqlConnection(connsql);
        SqlCommand cmd = new SqlCommand();
        sconn.Open();
        cmd.Connection = sconn;
        string command = "update " + relateTable + " set ";
        Type t = obj.GetType();
        foreach (PropertyInfo p in t.GetProperties())
        {
            Type pt = p.PropertyType;
            string name = p.Name;
            object value = p.GetValue(obj, null);
            if (!name.Equals(key))
            {
                if (pt.Equals(typeof(DateTime)))
                {
                    Console.WriteLine("a");
                    if (!((DateTime)value > new DateTime()))
                    {
                        value = DateTime.Now;
                    }
                }
                command += name + " ='" + value + "',";
            }
        }
        command = command.Remove(command.Length - 1);
        command += "where " + key + " = " + t.GetProperty(key).GetValue(obj,null);
        cmd.CommandText = command;
        int result = cmd.ExecuteNonQuery();
        return result != 0;
    }

    public BaseObject getById(int id)
    {
        SqlConnection sconn = new SqlConnection(connsql);
        SqlCommand cmd = new SqlCommand();
        sconn.Open();
        cmd.Connection = sconn;
        string sqlquery = "select * from "+relateTable+" where " + key + " = " + id;
        cmd.CommandText = sqlquery;
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            Type t = Type.GetType(objectName);
            BaseObject o = System.Activator.CreateInstance(t) as BaseObject;
            foreach (PropertyInfo p in t.GetProperties())
            {
                Type pType = p.PropertyType;
                p.SetValue(o, reader[lowerFirstChar(p.Name)], null);
                //casting may be not needed
                //switch (pType.Name){
                //    case "String":
                //        p.SetValue(o, (string)reader[lowerFirstChar(p.Name)], null);
                //        break;
                //    case "DateTime":
                //        p.SetValue(o, (DateTime)reader[lowerFirstChar(p.Name)], null);
                //        break;
                //    case "Int32":
                //        p.SetValue(o, (int)reader[lowerFirstChar(p.Name)], null);
                //        break;
                //}
            }
            return o;
        }
        return null;
    }

    public IList<BaseObject> find(BaseObject information)
    {
        SqlConnection sconn = new SqlConnection(connsql);
        SqlCommand cmd = new SqlCommand();
        sconn.Open();
        cmd.Connection = sconn;
        string sqlquery = "select * from "+relateTable+" where 1=1";
        Type t = information.GetType();
        foreach (PropertyInfo p in t.GetProperties()) {
            Type pt = p.PropertyType;
            string name = p.Name;
            object value = p.GetValue(information, null);
            if (!name.Equals(key) && value!=null && !value.Equals(""))
            {
                if (!pt.Equals(typeof(DateTime)) && !pt.Equals(typeof(Int32))) {
                    sqlquery += " and " + name + " like '%" + value + "%'";
                }
                else if (pt.Equals(typeof(DateTime)) && ((DateTime)value > new DateTime()))
                {
                    sqlquery += " and " + name + " like '" + value + "'";
                }
            }
            
        }
        
        cmd.CommandText = sqlquery;
        SqlDataReader reader = cmd.ExecuteReader();
        IList<BaseObject> result = new List<BaseObject>();
        while (reader.Read())
        {
            BaseObject o = System.Activator.CreateInstance(t) as BaseObject;
            foreach (PropertyInfo p in t.GetProperties())
            {
                Type pType = p.PropertyType;
                Console.Write(lowerFirstChar(p.Name));
                p.SetValue(o, reader[lowerFirstChar(p.Name)], null);
                //casting may be not needed
                //switch (pType.Name)
                //{
                //    case "String":
                //        p.SetValue(o, (string)reader[lowerFirstChar(p.Name)], null);
                //        break;
                //    case "DateTime":
                //        p.SetValue(o, (DateTime)reader[lowerFirstChar(p.Name)], null);
                //        break;
                //    case "Int32":
                //        p.SetValue(o, (int)reader[lowerFirstChar(p.Name)], null);
                //        break;
                //}
            }
            result.Add(o);
        }
        return result;
    }

    private string lowerFirstChar(string ori) {
        string first = ori.Substring(0, 1);
        string after = ori.Substring(1, ori.Length - 1);
        return first.ToLower() + after;
    }

    #endregion
}
