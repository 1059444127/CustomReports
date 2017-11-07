using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CustomReports.Model
{
    public partial class T_JCXX_DAL
    {
        public List<T_JCXX> GetJcxxTbsList(SqlFilter sqlFilter)
        {
            if (sqlFilter == null)
                throw new Exception("过滤条件不能传入null");

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM dbo.v_tbs_value ");
            strSql.Append(" where 1=1 ");

            //blh
            if (!string.IsNullOrEmpty(sqlFilter.BLH))
                strSql.Append($" and f_blh= '{sqlFilter.BLH}' ");
            //xm
            if (!string.IsNullOrEmpty(sqlFilter.Name))
                strSql.Append($" and f_xm= '{sqlFilter.Name}' ");

            if (sqlFilter.PathLibs.HasValue)
                switch (sqlFilter.PathLibs)
                {
                    case PathLibs.全部:
                        break;
                    case PathLibs.EBV:
                        strSql.Append($" and f_blk='EBV' ");
                        break;
                    case PathLibs.HBV:
                        strSql.Append($" and f_blk='HBV' ");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            if (sqlFilter.Sdrq1.HasValue)
                strSql.Append(
                    $" and CONVERT(datetime,f_sdrq) >= CONVERT(datetime,'{sqlFilter.Sdrq1.Value.ToString("s")}') ");
            if (sqlFilter.Sdrq2.HasValue)
                strSql.Append(
                    $" and CONVERT(datetime,f_sdrq) <= CONVERT(datetime,'{sqlFilter.Sdrq2.Value.ToString("s")}') ");

            //只查询三个月之内有一条以上数据的
            strSql.Append($@" and f_brbh in (select F_BRBH from dbo.v_tbs_value t where 1=1 ");
            //blk
            if (sqlFilter.PathLibs.HasValue)
                switch (sqlFilter.PathLibs)
                {
                    case PathLibs.全部:
                        break;
                    case PathLibs.EBV:
                        strSql.Append($" and t.f_blk='EBV' ");
                        break;
                    case PathLibs.HBV:
                        strSql.Append($" and t.f_blk='HBV' ");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            //报告状态
            if (sqlFilter.ReportStatus!= ReportStatuses.全部)
                strSql.Append($" and t.f_bgzt='{sqlFilter.ReportStatus}' ");

            //收到时间 betwwen 收到时间 - 收到时间-六个月
            strSql.Append($" and CONVERT(datetime,f_sdrq) > CONVERT(datetime,'{sqlFilter.Sdrq1.Value.AddMonths(-6).ToString("s")}') ");
            strSql.Append($" and CONVERT(datetime,f_sdrq) < CONVERT(datetime,'{sqlFilter.Sdrq2.Value.ToString("s")}') ");
            strSql.Append(" group by F_BRBH having (COUNT(F_BRBH)>1) and F_BRBH<>' ') ");

            strSql.Append(" order by f_sdrq desc ");

            var dt = DbHelper.GetTable(strSql.ToString());
            var list = new List<T_JCXX>();

            foreach (DataRow row in dt.Rows)
            {
                var jcxx = DataRowToModel_TBS(row);
                list.Add(jcxx);
            }

            return list;
        }

        public T_JCXX GetPreJcxx(T_JCXX jcxx)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 2 * ");
            strSql.Append(" FROM dbo.v_tbs_value ");
            strSql.Append(" where 1=1 ");

            //收到日期
            strSql.Append($" and CONVERT(datetime,f_sdrq) <= CONVERT(datetime,'{jcxx.F_SDRQ}') ");
            strSql.Append($" and CONVERT(datetime,f_sdrq) >= DATEADD(month,-6,CONVERT(datetime,'{jcxx.F_SDRQ}')) ");

            //blk
            strSql.Append($" and f_blk='{jcxx.F_BLK}' ");

            //brbh
            strSql.Append($" and f_brbh='{jcxx.F_BRBH}' ");

            strSql.Append(" order by f_sdrq desc ");

            var dt = DbHelper.GetTable(strSql.ToString());
            if (dt.Rows.Count > 1)
                return DataRowToModel_TBS(dt.Rows[1]);
            return new T_JCXX();
        }

        public T_JCXX DataRowToModel_TBS(DataRow dr)
        {
            var jcxx = DataRowToModel(dr);
            jcxx.TBS_VALUE = Convert.ToInt32(dr["TBS_VALUE"]);
            return jcxx;
        }
    }
}