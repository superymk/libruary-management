using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

public class DaoException:Exception
{
    private string error;

    public DaoException(string err)
        : base(err)
    {
        
        error = err;
    }

    public override string Message
    {
        get
        {
            return error;
        }
    }
}
