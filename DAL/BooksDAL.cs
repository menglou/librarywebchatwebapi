using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;
using System.Data.SqlClient;
using DAL.Helper;
using Dapper;

namespace DAL
{
   public class BooksDAL
    {
        /// <summary>
        /// 添加图书
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public int AddNewBook(Books book)
        {

            string sql = @"insert into Books
                          (
                           BookId, 
                           BarCode, 
                           BookName, 
                           Author, 
                           PublisherId, 
                           PublishDate, 
                           BookCategory,
                           UnitPrice, 
                           BookImage, 
                           BookCount,
                           Remainder, 
                           BookPosition,
                           RegTime
                          ) 
                         values
                          (
                            newid(), 
                           @BarCode, 
                           @BookName, 
                           @Author, 
                           @PublisherId, 
                           @PublishDate, 
                           @BookCategory,
                           @UnitPrice, 
                           @BookImage, 
                           @BookCount,
                           @Remainder, 
                           @BookPosition,
                           getdate()
                          )";

            try
            {
                using (IDbConnection coon = SqlHelper.GetConnection())
                {
                    return coon.Execute(sql, book);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// 修改图书
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public int UpdateBookInfo(Books book)
        {
            string sql = @"update Books set 
                           BarCode=@BarCode, 
                           BookName=@BookName, 
                           Author=@Author, 
                           PublisherId=@PublisherId, 
                           PublishDate=@PublishDate, 
                           BookCategory=@BookCategory,
                           UnitPrice=@UnitPrice, 
                           BookImage=@BookImage, 
                           BookCount=@BookCount,
                           Remainder=@Remainder, 
                           BookPosition=@BookPosition  where BookId=@BookId";
            try
            {
                using (IDbConnection coon = SqlHelper.GetConnection())
                {
                    return coon.Execute(sql, book);
                }
            }
            catch (Exception ex)
            {

                throw ;
            }
        }
    }
}
