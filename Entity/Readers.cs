using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{

    public class Readers
    {
        private Guid? readerid;
        public Guid? ReaderId
        {
            get { return readerid; }
            set
            {
                readerid = value;
            }
        }
        private string readingcard;
        /// <summary>
        /// 借阅证编号
        /// </summary>
        public string ReadingCard
        {
            get { return readingcard; }
            set
            {
                readingcard = value;

            }
        }
        private string readername;
        public string ReaderName
        {
            get { return readername; }
            set
            {
                readername = value;

            }
        }
        private string gender;
        public string Gender
        {
            get { return gender; }
            set
            {
                gender = value;

            }
        }
        private string idcard;
        public string IDCard
        {
            get { return idcard; }
            set
            {
                idcard = value;

            }
        }
        private string raderaddress;
        public string ReaderAddress
        {
            get { return raderaddress; }
            set
            {
                raderaddress = value;

            }
        }
        private string postcode;
        public string PostCode
        {
            get { return postcode; }
            set
            {
                postcode = value;

            }
        }
        private string phonenumber;
        public string PhoneNumber
        {
            get { return phonenumber; }
            set
            {
                phonenumber = value;

            }
        }

        private Guid? roleid;
        public Guid? RoleId
        {
            get { return roleid; }
            set
            {
                roleid = value;

            }
        }
        private string readerimage;
        public string ReaderImage
        {
            get { return readerimage; }
            set
            {
                readerimage = value;

            }
        }

        private DateTime regtime;
        public DateTime RegTime
        {
            get { return regtime; }
            set
            {
                regtime = value;

            }
        }

        private string readerpwd;
        public string ReaderPwd
        {
            get { return readerpwd; }
            set
            {
                readerpwd = value;

            }
        }

        private int adminid;
        public int AdminId
        {
            get { return adminid; }
            set
            {
                adminid = value;

            }
        }

        private int statusid;
        public int StatusId
        {
            get { return statusid; }
            set
            {
                statusid = value;

            }
        }
        private string statusname;

        public string StatusName
        {
            get { return statusname; }
            set
            {
                statusname = value;

            }
        }

        private int readercount;
        public int ReaderCount
        {
            get { return readercount; }
            set
            {
                readercount = value;

            }
        }

        private string roleName;
        public string RoleName
        {
            get { return roleName; }
            set
            {
                roleName = value;

            }
        }

        public int PageCount { get; set; }

        public int PageSize { get; set; }

        public int PageIndex { get; set; }


    }
}
