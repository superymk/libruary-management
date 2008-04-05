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
using System.Collections.Generic;

/// <summary>
/// UserDaoImpl 的摘要说明
/// </summary>
public class UserDaoImpl : BaseDao, IUserDao{
    //private string connsql = "server=.\\sqlexpress;uid=sa;pwd=admin1;database=libruary";
	public UserDaoImpl(){
        relateTable = "userinformation";
        key = "IdUser";
        objectName = "User";
    }

    #region IUserDao 成员

    public int confirmUser(string username, string password)
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
            sconn.Close();
            return userid;
        }
        sconn.Close();
        return -1;
    }


    public int isAdmin(int idUser)
    {
        SqlConnection sconn = new SqlConnection(connsql);
        SqlCommand cmd = new SqlCommand();
        sconn.Open();
        cmd.Connection = sconn;
        cmd.CommandText = "select * from admininformation where idAdmin='" + idUser + "'";
        //Console.WriteLine(cmd.CommandText);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            int adminid = (int)reader["idAdmin"];
            //save the userid in somewhere
            sconn.Close();
            return 1;
        }
        sconn.Close();
        return 0;

    }
    //public bool register(User user) {
    //    SqlConnection sconn = new SqlConnection(connsql);
    //    SqlCommand cmd = new SqlCommand();
    //    sconn.Open();
    //    cmd.Connection = sconn;
    //    if (!(user.Birthday > new DateTime())) { user.Birthday = DateTime.Now; }
    //    cmd.CommandText = "insert into userinformation values('" + user.Username + "','"+user.Password+"','"+user.TrueName+"','"
    //        +user.College+"','"+user.Address+"','"+user.Birthday.ToString()+"','"+user.Sex+"','"+user.Email+"','"+user.Telnumber+"','"+user.Description+"','"+user.Mark+"')";
    //    //l.Text = cmd.CommandText;
    //    int result = cmd.ExecuteNonQuery();
    //    return result != 0;
    //}

    //public bool update(User user)
    //{
    //    SqlConnection sconn = new SqlConnection(connsql);
    //    SqlCommand cmd = new SqlCommand();
    //    sconn.Open();
    //    cmd.Connection = sconn;
    //    if (!(user.Birthday > new DateTime())) { user.Birthday = DateTime.Now; }
    //    cmd.CommandText = "update userinformation set username = '"  + user.Username + "' , password = '" + user.Password + "' , trueName = '" + user.TrueName + "' , college = '"
    //        + user.College + "' , address = '" + user.Address + "' , birthday = '" + user.Birthday + "' , sex = '" + user.Sex + "' , email = '" + user.Email + 
    //        "' , telnumber = '" + user.Telnumber + "' , description = '" + user.Description + "' , mark = '" + user.Mark + "' where idUser = "+user.IdUser;
    //    //l.Text = cmd.CommandText;
    //    int result = cmd.ExecuteNonQuery();
    //    return result != 0;
    //}

    //public bool delete(int idUser)
    //{
    //    SqlConnection sconn = new SqlConnection(connsql);
    //    SqlCommand cmd = new SqlCommand();
    //    sconn.Open();
    //    cmd.Connection = sconn;
    //    cmd.CommandText = "delete from userinformation where idUser = " + idUser;
    //    int result = cmd.ExecuteNonQuery();
    //    return result != 0;
    //}

    //public User getById(int idUser) {
    //    SqlConnection sconn = new SqlConnection(connsql);
    //    SqlCommand cmd = new SqlCommand();
    //    sconn.Open();
    //    cmd.Connection = sconn;
    //    string sqlquery = "select * from userinformation where idUser = " + idUser;
    //    cmd.CommandText = sqlquery;
    //    SqlDataReader reader = cmd.ExecuteReader();
    //    if (reader.Read())
    //    {
    //        User u = new User();
    //        u.IdUser = (int)reader["idUser"];
    //        u.Username = (string)reader["userName"];
    //        u.Password = (string)reader["password"];
    //        u.TrueName = (string)reader["trueName"];
    //        u.College = (string)reader["college"];
    //        u.Birthday = (DateTime)reader["birthday"];
    //        u.Address = (string)reader["address"];
    //        u.Sex = (string)reader["sex"];
    //        u.Email = (string)reader["email"];
    //        u.Description = (string)reader["description"];
    //        u.Mark = (int)reader["mark"];
    //        return u;
    //    }
    //    return null;
    //}

    //public IList<User> find(User info)
    //{
    //    SqlConnection sconn = new SqlConnection(connsql);
    //    SqlCommand cmd = new SqlCommand();
    //    sconn.Open();
    //    cmd.Connection = sconn;
    //    string sqlquery = "select * from userinformation where 1=1";
    //    if (info.Username != null && !info.Username.Equals(""))
    //    {
    //        sqlquery = sqlquery + " and username like '" + info.Username + "'";
    //    }
    //    if (info.TrueName != null && !info.TrueName.Equals(""))
    //    {
    //        sqlquery = sqlquery + " and truename like '" + info.TrueName + "'";
    //    }
    //    if (info.College != null && !info.College.Equals(""))
    //    {
    //        sqlquery = sqlquery + " and college like '" + info.College + "'";
    //    }
    //    if (info.Address != null && !info.Address.Equals(""))
    //    {
    //        sqlquery = sqlquery + " and address like '" + info.Address + "'";
    //    }
    //    if (info.Sex != null && !info.Sex.Equals(""))
    //    {
    //        sqlquery = sqlquery + " and sex = '" + info.Sex + "'";
    //    }
    //    if (info.Email != null && !info.Email.Equals(""))
    //    {
    //        sqlquery = sqlquery + " and email like '" + info.Email + "'";
    //    }
    //    if (info.Description != null && !info.Description.Equals(""))
    //    {
    //        sqlquery = sqlquery + " and description like '" + info.Description + "'";
    //    }
    //    if (info.Mark != -1)
    //    {
    //        sqlquery = sqlquery + " and mark = " + info.Mark;
    //    }
    //    cmd.CommandText = sqlquery;
    //    SqlDataReader reader = cmd.ExecuteReader();
    //    IList<User> result = new List<User>();
    //    while (reader.Read())
    //    {
    //        User u = new User();
    //        u.IdUser = (int)reader["idUser"];
    //        u.Username = (string)reader["userName"];
    //        u.Password = (string)reader["password"];
    //        u.TrueName = (string)reader["trueName"];
    //        u.College = (string)reader["college"];
    //        u.Birthday = (DateTime)reader["birthday"];
    //        u.Address = (string)reader["address"];
    //        u.Sex = (string)reader["sex"];
    //        u.Email = (string)reader["email"];
    //        u.Description = (string)reader["description"];
    //        u.Mark = (int)reader["mark"];
    //        result.Add(u);
    //    }
    //    return result;
    //}
    #endregion

}
