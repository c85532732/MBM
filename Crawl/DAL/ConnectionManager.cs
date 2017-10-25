using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace DAL
{
    public class ConnectionManager
    {
        #region Static Constant
        private static Dictionary<string, string> odConnectionString = new Dictionary<string, string>();
        private const string DefaultConnectionString = "crawl";
        private static object ooLocker = new object();
        #endregion

        #region Public Static Method

        /// <summary>
        /// 返回当前应用程序默认的数据库连接字符串. 默认的字符串名"Volcker"。请确保当前的应用程序配置文件中含有此配置项。
        /// </summary>
        /// <returns></returns>
        public static string ConnectionString()
        {
            if (!odConnectionString.ContainsKey(DefaultConnectionString))
            {
                ConnectionManager.ReadConnectionString(DefaultConnectionString);
            }

            return odConnectionString[DefaultConnectionString];
        }

        /// <summary>
        /// 返回当前应用程序中的一个的数据库连接字符串。请确保当前的应用程序配置文件中含有此配置项。
        /// </summary>
        /// <param name="strConnectionKey">连接字符串名</param>
        /// <returns>数据库连接字符串</returns>
        public static string ConnectionString(string strConnectionKey)
        {
            if (!odConnectionString.ContainsKey(strConnectionKey))
            {
                ReadConnectionString(strConnectionKey);
            }
            return odConnectionString[strConnectionKey];
        }



        public void ResetConnectionStrings()
        {
            lock (ooLocker)
            {
                odConnectionString = new Dictionary<string, string>();
            }
        }

        #endregion

        #region 私有静态方法

        /// <summary>
        /// 从当前应用程序中读取一个数据库连接字符串到字符串集合中.
        /// </summary>
        /// <param name="strConnectionKey"></param>
        private static void ReadConnectionString(string strConnectionKey)
        {
            // 先锁住保证只有当前可以进入.
            lock (ooLocker)
            {
                // 再次判断是否需要读入,因为有可能在当前进程进入前已经有进程完成了读取.
                if (!odConnectionString.ContainsKey(strConnectionKey))
                {
                    string strConnectionString;
                    try
                    {
                        // 从当前应用程序配置文件中读取指定的数据库连接字符串.
                        strConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[strConnectionKey].ConnectionString;
                    }
                    catch (Exception oeException)
                    {
                        throw new Exception(string.Format("当前应用程序配置文件中不包含 [{0}] 数据库连接字符串", strConnectionKey), oeException);
                    }
                    // 将读取到的连接字符串放入字符串集合中.
                    odConnectionString[strConnectionKey] = strConnectionString;
                }
            }
        }

        #endregion


        public static DataTable ExecProcByDataBasePager(string connectionString, string tableName, string showColumn, int pageNumber, int pageSize, string condition, string sortField, out int recordCount)
        {

            string strStoreProcedure = "DataBasePager";
            SqlDatabase odbDatabase = new SqlDatabase(connectionString);
            DbCommand odbCommand = odbDatabase.GetStoredProcCommand(strStoreProcedure);
            odbDatabase.AddInParameter(odbCommand, "@TableName", System.Data.DbType.String, tableName);
            odbDatabase.AddInParameter(odbCommand, "@ShowColumn", System.Data.DbType.String, showColumn);
            odbDatabase.AddInParameter(odbCommand, "@PageNumber", System.Data.DbType.Int32, pageNumber);
            odbDatabase.AddInParameter(odbCommand, "@PageSize", System.Data.DbType.Int32, pageSize);
            odbDatabase.AddInParameter(odbCommand, "@Condition", System.Data.DbType.String, condition);
            odbDatabase.AddInParameter(odbCommand, "@SortField", System.Data.DbType.String, sortField);
            odbDatabase.AddOutParameter(odbCommand, "@RecordCount", System.Data.DbType.Int32, 0);
            try
            {
                DataTable dt = odbDatabase.ExecuteDataSet(odbCommand).Tables[0];
                recordCount = int.Parse(odbCommand.Parameters["@RecordCount"].Value.ToString());
                return dt;

            }
            catch (Exception oeException)
            {
                throw new Exception("An error has  occurred while loading the " + tableName + " table. Error Message: " + oeException.Message, oeException);
            }
        }
    }
}
