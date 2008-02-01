using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class test : System.Web.UI.Page
{
    protected void btnCounter_OnClick(object sender, EventArgs e)
    {
        btnCounter.Text = "Clicked";
    }
    protected void Page_Load()
    {
        lblMessage.Text += "Hello World!";
    }
}
