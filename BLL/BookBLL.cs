using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace BLL
{
    public class BookBLL
    {
        public int AddNewBook(Books book)
        {
            return new DAL.BooksDAL().AddNewBook(book);
        }

        public int UpdateBookInfo(Books book)
        {
            return new DAL.BooksDAL().UpdateBookInfo(book);
        }
    }
}
