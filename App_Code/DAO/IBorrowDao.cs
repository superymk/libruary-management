using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

public interface IBorrowDao : global::IBaseDao
{
     void RegisteById(int idUser, int idBook);
     void RegisteByName(string userName, string bookName);
}
