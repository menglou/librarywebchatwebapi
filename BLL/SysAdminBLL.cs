using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;

namespace BLL
{
   public  class SysAdminBLL
    {
        public SysAdmin Login(SysAdmin sysadmin)
        {
            return new DAL.SysAdminDAL().Login(sysadmin);
        }
    }
}
