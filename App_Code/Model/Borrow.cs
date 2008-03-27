using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

public class Borrow : global::BaseObject
{
    private int idBook;
    private int idUser;
    private DateTime deadLine;

    public double DeadLinePeriod
    {
        get
        {
            return 10;
        }
    }

    public int IdBook
    {
        get
        {
            return idBook;
        }
        set
        {
            idBook = value;
        }
    }

    public int IdUser
    {
        get
        {
            return idUser;

        }
        set
        {
            idUser = value;
        }
    }

    public DateTime DeadLine
    {
        get
        {
            return deadLine;
        }
        set
        {
            deadLine = value;
        }
    }
}
