using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Collections.Generic;

public class BorrowDaoImpl : BaseDao, IBorrowDao
{
    public double DeadLinePeriod
    {
        get
        {
            int i = 10;
            
            return int.TryParse(getAppSetting("DeadLinePeriod"), out i)?i:10;
        }
    }

    public int InitialMark
    {
        get{
            int i = -10;
            
            return int.TryParse(getAppSetting("InitialMark"),out i) ? i : -10;
        }
    }

    public int MarkPerBorrow
    {
        get
        {
           int i = 10;
           
           return int.TryParse(getAppSetting("MarkPerBorrow"),out i) ? i : 10;
        }
    }

    public int TimeLimit
    {
        get
        {
            int i = 7;
            
            return int.TryParse(getAppSetting("TimeLimit"),out i) ? i : 7;
        }
    }

    public int BorrowCountLimit
    {
        get
        {
            int i = 5;
            return int.TryParse(getAppSetting("BorrowCountLimit"), out i) ? i : 5;
        }
    }
    private static string getAppSetting(string index)
    {
        return System.Configuration.ConfigurationManager.AppSettings[index];
    }

    public BorrowDaoImpl()
    {
        relateTable = "borrowtable";
        key = new string[]{"idBook","idUser"};
        objectName = "Borrow";
        autoKey = false;
    }

    public void RegisteById(int idUser,int idBook){
        Borrow borrow = new Borrow();
        borrow.IdBook = idBook;
        borrow.IdUser = idUser;
        borrow.DeadLine = DateTime.Today.AddDays(this.DeadLinePeriod);

        IBaseDao bookdao = DaoFactory.getBookDao();
        Book book = bookdao.getById(idBook)as Book;
        if (book == null) throw new DaoException("�Ҳ���id: " + idBook+" ��ͼ��!");
        if (!book.State.Trim().ToUpper().Equals(BookDaoImpl.Free))
            throw new DaoException("ͼ�� " + book.BookName + " ���ɱ����ģ��ѳ����ʧ!");
        book.State = BookDaoImpl.Borrowed;

        IUserDao userdao = DaoFactory.getUserDao();
        User user = userdao.getById(idUser)as User;
        int count = userdao.borrowedBookCount(idUser);

        if (user.Mark < 0)
            throw new DaoException("�û�: "+ user.Username + " �Ļ����ѵ���0��,�����ǽ��鳬ʱ������ע���û�,�������Ա��ϵ���");
        if (count >= BorrowCountLimit)
            throw new DaoException("�û�: " + user.Username + " �Ѿ������� " + (count+1)+" ���� "+BorrowCountLimit+ " ��ͼ��!");
        user.Mark-=MarkPerBorrow;

        userdao.update(user);
        bookdao.update(book);
        DaoFactory.getBorrowDao().add(borrow);
    }

    public void RegisteByName(string userName, string bookName)
    {
        Book book = new Book();
        book.BookName = bookName;
        IList<BaseObject> list = DaoFactory.getBookDao().find(book);
        if (list.Count != 1) throw new DaoException("�Ҳ���ͼ��: " + bookName);
        book = (Book)list[0];
        if (book.BookName == null || book.BookName.Equals("")) throw new DaoException("�Ҳ���ͼ��: " + bookName);

        User user = new User();
        user.Username = userName;
        list = DaoFactory.getUserDao().find(user);
        if (list.Count != 1) throw new DaoException("�Ҳ����û�: " + userName);
        user = (User)list[0];
        if (user.Username == null || user.Username.Equals("")) throw new DaoException("�Ҳ����û�: " + userName);

        RegisteById(user.IdUser,book.IdBook);
    }

    public void ReturnBookById(int userId, int bookId)
    {

        Borrow borrow = getById(new int[] { bookId, userId })as Borrow;
        if (borrow!=null)
        {
            IBaseDao bookdao = DaoFactory.getBookDao();
            Book book = bookdao.getById(bookId)as Book;
            if (book == null) throw new DaoException("����id: "+bookId+" ��ͼ�鲻����!");

            IBaseDao userdao = DaoFactory.getUserDao();
            User user = userdao.getById(userId)as User;
            if (user == null) throw new DaoException("����id: " + userId + " ���û�������!");

            book.State = BookDaoImpl.Free;
            bookdao.update(book);

            DateTime deadLine = borrow.DeadLine;
            if((deadLine>=DateTime.Now)){
                user.Mark+=MarkPerBorrow+MarkPerBorrow;
            }
            else if ((DateTime.Now - deadLine) <= TimeSpan.FromDays(TimeLimit))
            {
                user.Mark += MarkPerBorrow;
            }
            userdao.update(user);

            delete(new int[] { bookId, userId });
            return;
        }
        throw new DaoException("����idUser: " + userId + " ��idBook: " + bookId + " �Ľ����¼������!");
    }
    

}
