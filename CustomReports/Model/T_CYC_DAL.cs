using System.Collections.Generic;
using System.Data;
using dbbase;

namespace CustomReports.Model
{
    public class T_CYC_DAL
    {
       private static dbbase.odbcdb aa = new odbcdb("DSN=pathnet;UID=pathnet;PWD=4s3c2a1p", "", "");

        public static List<T_CYC> GetListByFl(string fl)
        {
            List<T_CYC> lstCyc = new List<T_CYC>();

            var dtCyc = aa.GetDataTable($" select * from t_cyc t where t.f_cyc_fl= '{fl}' ", "dt1");
            if(dtCyc!=null)
                foreach (DataRow row in dtCyc.Rows)
                {
                    lstCyc.Add(new T_CYC(row));
                }
            return lstCyc;
        }

        /// <summary>
        /// 常用字典类型静态变量
        /// </summary>
        public static class Dict
        {
            /// <summary>
            /// 项目分类
            /// </summary>
            public static string F_XMFL= "f_bblx";

            /// <summary>
            /// 分子病理医嘱项目
            /// </summary>
            public static string F_FZBL_YZXM= "f_fzbl_yzxm";
        }
    }
}