using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Helper
{
   public  class SqlHelper
    {
        private static readonly string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ToString();


        public static SqlConnection GetConnection()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionstring);
                connection.Open();
                return connection;
            }
            catch (Exception EX)
            {

                throw;
            }
        }

        #region 单表的增删改查
          
        #endregion

    }
}
