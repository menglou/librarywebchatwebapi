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
   public class SysAdminDAL
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="sysadmin"></param>
        /// <returns></returns>
        public SysAdmin Login(SysAdmin sysadmin)
        {
            using (IDbConnection coon = SqlHelper.GetConnection())
            {
                string sql = "select AdminId, AdminName, LoginPwd, StatusId, RoleId from SysAdmin where AdminId=@AdminId and LoginPwd=@LoginPwd";

                return coon.QueryFirstOrDefault<SysAdmin>(sql, sysadmin);
            }
        }
    }
}
