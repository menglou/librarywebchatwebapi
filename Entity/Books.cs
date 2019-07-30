using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Books
    {
        private Guid? bookid = null;
        public Guid? BookId
        {
            get { return bookid; }
            set
            {
                bookid = value;

            }
        }
        private string barcode;
        public string BarCode
        {
            get { return barcode; }
            set
            {
                barcode = value;

            }
        }
        private string bookname;
        public string BookName
        {
            get { return bookname; }
            set
            {
                bookname = value;

            }
        }
        private string author;
        public string Author
        {
            get { return author; }
            set
            {
                author = value;

            }
        }

        private Guid? publishid = null;

        public Guid? PublisherId
        {
            get { return publishid; }
            set
            {
                publishid = value;

            }
        }
        public DateTime PublishDate { get; set; }

        private Guid? bookcategory = null;
        public Guid? BookCategory
        {
            get { return bookcategory; }
            set
            {
                bookcategory = value;

            }
        }
        private decimal unitprice;
        public decimal UnitPrice
        {
            get { return unitprice; }
            set
            {
                unitprice = value;

            }
        }
        private string bookimage;
        public string BookImage
        {
            get { return bookimage; }
            set
            {
                bookimage = value;

            }
        }
        private int bookcount;
        public int BookCount
        {
            get { return bookcount; }
            set
            {
                bookcount = value;

            }
        }
        private int remainder;
        /// <summary>
        /// 可借总数
        /// </summary>
        public int Remainder
        {
            get { return remainder; }
            set
            {
                remainder = value;

            }
        }
        private string bookposition;
        /// <summary>
        /// 图书位置
        /// </summary>
        public string BookPosition
        {
            get { return bookposition; }
            set
            {
                bookposition = value;

            }
        }
        private DateTime regtime;
        /// <summary>
        /// 上架时间
        /// </summary>
        public DateTime RegTime
        {
            get { return regtime; }
            set
            {
                regtime = value;

            }

        }

        private string publisername;
        public string PublisherName
        {
            get { return publisername; }
            set
            {
                publisername = value;

            }
        }

        public int PageSize { get; set; }

        public int PageIndex { get; set; }

        public int PageCount { get; set; }


    }
}
