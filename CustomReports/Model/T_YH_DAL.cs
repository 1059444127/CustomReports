using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using dbbase;

namespace CustomReports.Model
{
    public static class T_YH_DAL
    {
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static List<T_YH> GetList(string strWhere)
        {
            dbbase.odbcdb aa = new odbcdb("DSN=pathnet;UID=pathnet;PWD=4s3c2a1p", "", "");
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(" F_ID,F_YHM,F_YHMC,F_YHBH,F_YHQX,F_YHMM,F_DLSJ,F_SFZX,F_ZXWZ,F_ZXSC,F_DXYS,F_SFZH,F_DHHM,F_FJH,F_CXTS,F_DXFPYS,F_YH_BY1,F_YH_BY2 ");
            strSql.Append(" FROM T_YH ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            var dt = aa.GetDataTable(strSql.ToString(), "dt");
            var listYh = new List<T_YH>();
            foreach (DataRow dtRow in dt.Rows)
            {
                listYh.Add(T_YH.DataRowToModel(dtRow));
            }

            return listYh;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static T_YH GetModel(int F_ID)
        {
            dbbase.odbcdb aa = new odbcdb("DSN=pathnet;UID=pathnet;PWD=4s3c2a1p", "", "");
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 F_ID,F_YHM,F_YHMC,F_YHBH,F_YHQX,F_YHMM,F_DLSJ,F_SFZX,F_ZXWZ,F_ZXSC,F_DXYS,F_SFZH,F_DHHM,F_FJH,F_CXTS,F_DXFPYS,F_YH_BY1,F_YH_BY2 from T_YH ");
            strSql.Append($" where F_ID='{F_ID}'");
            
            DataTable dt = aa.GetDataTable(strSql.ToString(), "dt1");
            if (dt.Rows.Count > 0)
            {
                return T_YH.DataRowToModel(dt.Rows[0]);
            }
            return null;
        }
    }
}
