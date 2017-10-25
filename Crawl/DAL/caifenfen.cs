using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace DAL
{
    public class caifenfen
    {
        public static string m_strConnectionString = ConnectionManager.ConnectionString();

        public static DataTable GetLast()
        {
            string sql = "select top 1 * from caifenfen  order by n desc";
            SqlDatabase osdDataBase = new SqlDatabase(m_strConnectionString);
            DbCommand odbCommand = osdDataBase.GetSqlStringCommand(sql);            
            return osdDataBase.ExecuteDataSet(odbCommand).Tables[0];
        }

        public static void Insert(int n, string r, int wan, int qian, int bai, int shi, int ge,string sn)
        {
            string sql = "insert into caifenfen(n,r,wan,qian,bai,shi,ge,sn) values(@n,@r,@wan,@qian,@bai,@shi,@ge,@sn)";
            SqlDatabase osdDataBase = new SqlDatabase(m_strConnectionString);
            DbCommand odbCommand = osdDataBase.GetSqlStringCommand(sql);
            osdDataBase.AddInParameter(odbCommand, "@n", System.Data.DbType.Int32, n);
            osdDataBase.AddInParameter(odbCommand, "@r", System.Data.DbType.String, r);
            osdDataBase.AddInParameter(odbCommand, "@wan", System.Data.DbType.Int32, wan);
            osdDataBase.AddInParameter(odbCommand, "@qian", System.Data.DbType.Int32, qian);
            osdDataBase.AddInParameter(odbCommand, "@bai", System.Data.DbType.Int32, bai);
            osdDataBase.AddInParameter(odbCommand, "@shi", System.Data.DbType.Int32, shi);
            osdDataBase.AddInParameter(odbCommand, "@ge", System.Data.DbType.Int32, ge);
            osdDataBase.AddInParameter(odbCommand, "@sn", System.Data.DbType.String, sn);
            osdDataBase.ExecuteNonQuery(odbCommand);
        }

        public static DataTable GetBySql(string sql)
        {            
            SqlDatabase osdDataBase = new SqlDatabase(m_strConnectionString);
            DbCommand odbCommand = osdDataBase.GetSqlStringCommand(sql);
            return osdDataBase.ExecuteDataSet(odbCommand).Tables[0];
        }

        public static void ExecBySql(string sql)
        {
            SqlDatabase osdDataBase = new SqlDatabase(m_strConnectionString);
            DbCommand odbCommand = osdDataBase.GetSqlStringCommand(sql);
            osdDataBase.ExecuteNonQuery(odbCommand);
        }


        public static DataTable GetList_NextBySN(string top,string sn)
        {          
            SqlDatabase osdDataBase = new SqlDatabase(m_strConnectionString);
            DbCommand odbCommand = osdDataBase.GetStoredProcCommand("GET_CFF_LIST_BYLASTSN");
            osdDataBase.AddInParameter(odbCommand, "@top", System.Data.DbType.String, top);
            osdDataBase.AddInParameter(odbCommand, "@sn", System.Data.DbType.String, sn);
            return osdDataBase.ExecuteDataSet(odbCommand).Tables[0];
        }
    }
}
