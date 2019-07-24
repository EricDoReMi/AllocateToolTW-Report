using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Threading;

namespace AllocateTool.utils
{
    public partial class OLDBHelper
    {

        private static string driverNameStr;
        private static string persistSecurityStr;
        private static string dataSourcePath;
        public static string dataSourceStr;
        private static string connStr;//connectStr
        private static OleDbConnection conn;

        //初始化
        static OLDBHelper() {
            

             driverNameStr = "Provider=Microsoft.Ace.OLEDB.12.0;";

            persistSecurityStr = "Persist Security Info=False;Data Source=";
            


        }

        public static OleDbConnection GetConnection()  {
            if (dataSourceStr.Contains("-Sum"))
            {
                dataSourcePath = @"N:\Transfer GSC\2019_allocateMarcoToolDB\SumDB\";
                //dataSourcePath = @"C:\Users\ShiMao\Desktop\KR\";
                dataSourcePath = @"C:\Users\ShiMao\Desktop\TW-Report\";
            }
            else {
                dataSourcePath = @"N:\Transfer GSC\2019_allocateMarcoToolDB\V5.0\";
                //dataSourcePath = @"C:\Users\ShiMao\Desktop\KR\";
            }
            

            connStr = driverNameStr + persistSecurityStr +dataSourcePath + dataSourceStr;
           

            if (conn == null)
            {

                conn = new OleDbConnection(connStr);

           

            }
            
            return conn;
        }

        public static void CloseConnection() {
           
            if (conn!=null && conn.State.Equals(ConnectionState.Open))
            {
                conn.Close();
                
           
            }
        }


        //释放数据库连接的资源
        public static void DisposeDB()
        {
           
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
                conn = null;
           
            }
        }

        ~OLDBHelper()
        {
            
            DisposeDB();
        }


    }
}
