﻿using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMessage.Text = "Hello World again!";
    }
    protected void Log_In(object sender, EventArgs e)
    {
        string name = username.Text;
        string psw = password.Text;
        UserDao dao;
        if (dao.confirmUser(name, psw))
        {
            //do something 
        }
        else
        {
            //dosomething
        }
        nameserver.Text = name;
        pswserver.Text = psw;
    }
}
