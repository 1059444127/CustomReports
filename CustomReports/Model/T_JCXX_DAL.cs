using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using dbbase;

namespace CustomReports.Model
{
    /// <summary>
    /// 数据访问类:T_JCXX
    /// </summary>
    public partial class T_JCXX_DAL
    {
        public T_JCXX_DAL()
        { }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public T_JCXX GetModel(string F_BLH)
        {
            dbbase.odbcdb aa = new odbcdb("DSN=pathnet;UID=pathnet;PWD=4s3c2a1p", "", "");

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from T_JCXX ");
            strSql.Append($" where F_BLH= '{F_BLH}' ");
            
            DataSet ds = aa.GetDataSet(strSql.ToString(),"dt1");
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public static List<T_JCXX> GetBySqlWhere(string sqlWhere,string sqlOrderColumns="")
        {
            dbbase.odbcdb aa = new odbcdb("DSN=pathnet;UID=pathnet;PWD=4s3c2a1p", "", "");
            var list =new List<T_JCXX>();

            var sql = $"select * from t_jcxx t where {sqlWhere} ";
            if (string.IsNullOrEmpty(sqlOrderColumns) == false)
                sql += " order by " + sqlOrderColumns;

            var dt = aa.GetDataTable(sql, "dt1");
            foreach (DataRow row in dt.Rows)
            {
                list.Add(DataRowToModel(row));
            }
            return list;

        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static T_JCXX DataRowToModel(DataRow row)
        {
            T_JCXX model = new T_JCXX();
            if (row != null)
            {
                if (row["F_BLK"] != null)
                {
                    model.F_BLK = row["F_BLK"].ToString();
                }
                if (row["F_BLH"] != null)
                {
                    model.F_BLH = row["F_BLH"].ToString();
                }
                if (row["F_BRBH"] != null)
                {
                    model.F_BRBH = row["F_BRBH"].ToString();
                }
                if (row["F_SQXH"] != null)
                {
                    model.F_SQXH = row["F_SQXH"].ToString();
                }
                if (row["F_YZID"] != null)
                {
                    model.F_YZID = row["F_YZID"].ToString();
                }
                if (row["F_YZXM"] != null)
                {
                    model.F_YZXM = row["F_YZXM"].ToString();
                }
                if (row["F_STUDY_UID"] != null)
                {
                    model.F_STUDY_UID = row["F_STUDY_UID"].ToString();
                }
                if (row["F_XM"] != null)
                {
                    model.F_XM = row["F_XM"].ToString();
                }
                if (row["F_XB"] != null)
                {
                    model.F_XB = row["F_XB"].ToString();
                }
                if (row["F_NL"] != null)
                {
                    model.F_NL = row["F_NL"].ToString();
                }
                if (row["F_AGE"] != null && row["F_AGE"].ToString() != "")
                {
                    model.F_AGE = decimal.Parse(row["F_AGE"].ToString());
                }
                if (row["F_HY"] != null)
                {
                    model.F_HY = row["F_HY"].ToString();
                }
                if (row["F_MZ"] != null)
                {
                    model.F_MZ = row["F_MZ"].ToString();
                }
                if (row["F_ZY"] != null)
                {
                    model.F_ZY = row["F_ZY"].ToString();
                }
                if (row["F_SFZH"] != null)
                {
                    model.F_SFZH = row["F_SFZH"].ToString();
                }
                if (row["F_LXXX"] != null)
                {
                    model.F_LXXX = row["F_LXXX"].ToString();
                }
                if (row["F_BRLB"] != null)
                {
                    model.F_BRLB = row["F_BRLB"].ToString();
                }
                if (row["F_FB"] != null)
                {
                    model.F_FB = row["F_FB"].ToString();
                }
                if (row["F_ZYH"] != null)
                {
                    model.F_ZYH = row["F_ZYH"].ToString();
                }
                if (row["F_MZH"] != null)
                {
                    model.F_MZH = row["F_MZH"].ToString();
                }
                if (row["F_BQ"] != null)
                {
                    model.F_BQ = row["F_BQ"].ToString();
                }
                if (row["F_SJKS"] != null)
                {
                    model.F_SJKS = row["F_SJKS"].ToString();
                }
                if (row["F_CH"] != null)
                {
                    model.F_CH = row["F_CH"].ToString();
                }
                if (row["F_SJDW"] != null)
                {
                    model.F_SJDW = row["F_SJDW"].ToString();
                }
                if (row["F_SJYS"] != null)
                {
                    model.F_SJYS = row["F_SJYS"].ToString();
                }
                if (row["F_SDRQ"] != null)
                {
                    model.F_SDRQ = row["F_SDRQ"].ToString();
                }
                if (row["F_JSY"] != null)
                {
                    model.F_JSY = row["F_JSY"].ToString();
                }
                if (row["F_BBLX"] != null)
                {
                    model.F_BBLX = row["F_BBLX"].ToString();
                }
                if (row["F_BBQK"] != null)
                {
                    model.F_BBQK = row["F_BBQK"].ToString();
                }
                if (row["F_JSYY"] != null)
                {
                    model.F_JSYY = row["F_JSYY"].ToString();
                }
                if (row["F_SF"] != null && row["F_SF"].ToString() != "")
                {
                    model.F_SF = decimal.Parse(row["F_SF"].ToString());
                }
                if (row["F_BBMC"] != null)
                {
                    model.F_BBMC = row["F_BBMC"].ToString();
                }
                if (row["F_LCZD"] != null)
                {
                    model.F_LCZD = row["F_LCZD"].ToString();
                }
                if (row["F_LCZL"] != null)
                {
                    model.F_LCZL = row["F_LCZL"].ToString();
                }
                if (row["F_RYSJ"] != null)
                {
                    model.F_RYSJ = row["F_RYSJ"].ToString();
                }
                if (row["F_QCYS"] != null)
                {
                    model.F_QCYS = row["F_QCYS"].ToString();
                }
                if (row["F_QCRQ"] != null)
                {
                    model.F_QCRQ = row["F_QCRQ"].ToString();
                }
                if (row["F_JLY"] != null)
                {
                    model.F_JLY = row["F_JLY"].ToString();
                }
                if (row["F_LKZS"] != null && row["F_LKZS"].ToString() != "")
                {
                    model.F_LKZS = int.Parse(row["F_LKZS"].ToString());
                }
                if (row["F_CKZS"] != null && row["F_CKZS"].ToString() != "")
                {
                    model.F_CKZS = int.Parse(row["F_CKZS"].ToString());
                }
                if (row["F_FY"] != null)
                {
                    model.F_FY = row["F_FY"].ToString();
                }
                if (row["F_JXSJ"] != null)
                {
                    model.F_JXSJ = row["F_JXSJ"].ToString();
                }
                if (row["F_BLZD"] != null)
                {
                    model.F_BLZD = row["F_BLZD"].ToString();
                }
                if (row["F_TSJC"] != null)
                {
                    model.F_TSJC = row["F_TSJC"].ToString();
                }
                try
                {
                    if (row["F_BGYS"] != null)
                    {
                        model.F_BGYS = row["F_BGYS"].ToString();
                    }
                }
                catch (Exception e)
                {
                }
                if (row["F_SHYS"] != null)
                {
                    model.F_SHYS = row["F_SHYS"].ToString();
                }
                if (row["F_BGRQ"] != null)
                {
                    model.F_BGRQ = row["F_BGRQ"].ToString();
                }
                if (row["F_CZYJ"] != null)
                {
                    model.F_CZYJ = row["F_CZYJ"].ToString();
                }
                if (row["F_XGYJ"] != null)
                {
                    model.F_XGYJ = row["F_XGYJ"].ToString();
                }
                if (row["F_ZDGJC"] != null)
                {
                    model.F_ZDGJC = row["F_ZDGJC"].ToString();
                }
                if (row["F_YYX"] != null)
                {
                    model.F_YYX = row["F_YYX"].ToString();
                }
                if (row["F_WFBGYY"] != null)
                {
                    model.F_WFBGYY = row["F_WFBGYY"].ToString();
                }
                if (row["F_BZ"] != null)
                {
                    model.F_BZ = row["F_BZ"].ToString();
                }
                if (row["F_BD_SFFH"] != null)
                {
                    model.F_BD_SFFH = row["F_BD_SFFH"].ToString();
                }
                if (row["F_BGZT"] != null)
                {
                    model.F_BGZT = row["F_BGZT"].ToString();
                }
                if (row["F_SFCT"] != null)
                {
                    model.F_SFCT = row["F_SFCT"].ToString();
                }
                if (row["F_SFDY"] != null)
                {
                    model.F_SFDY = row["F_SFDY"].ToString();
                }
                if (row["F_BGGS"] != null)
                {
                    model.F_BGGS = row["F_BGGS"].ToString();
                }
                if (row["F_GDZT"] != null)
                {
                    model.F_GDZT = row["F_GDZT"].ToString();
                }
                if (row["F_KNHZ"] != null && row["F_KNHZ"].ToString() != "")
                {
                    model.F_KNHZ = int.Parse(row["F_KNHZ"].ToString());
                }
                if (row["F_ZJYJ"] != null)
                {
                    model.F_ZJYJ = row["F_ZJYJ"].ToString();
                }
                if (row["F_WYYJ"] != null)
                {
                    model.F_WYYJ = row["F_WYYJ"].ToString();
                }
                if (row["F_SFZT"] != null && row["F_SFZT"].ToString() != "")
                {
                    model.F_SFZT = int.Parse(row["F_SFZT"].ToString());
                }
                if (row["F_SFJG"] != null)
                {
                    model.F_SFJG = row["F_SFJG"].ToString();
                }
                if (row["F_JBBM_CN"] != null)
                {
                    model.F_JBBM_CN = row["F_JBBM_CN"].ToString();
                }
                if (row["F_JBBM_ENG"] != null)
                {
                    model.F_JBBM_ENG = row["F_JBBM_ENG"].ToString();
                }
                if (row["F_JBMC"] != null)
                {
                    model.F_JBMC = row["F_JBMC"].ToString();
                }
                if (row["F_YBLH"] != null)
                {
                    model.F_YBLH = row["F_YBLH"].ToString();
                }
                if (row["F_SJCL"] != null)
                {
                    model.F_SJCL = row["F_SJCL"].ToString();
                }
                if (row["F_YBLZD"] != null)
                {
                    model.F_YBLZD = row["F_YBLZD"].ToString();
                }
                if (row["F_BGFSFS"] != null)
                {
                    model.F_BGFSFS = row["F_BGFSFS"].ToString();
                }
                if (row["F_SCYS"] != null)
                {
                    model.F_SCYS = row["F_SCYS"].ToString();
                }
                if (row["F_SFFH"] != null)
                {
                    model.F_SFFH = row["F_SFFH"].ToString();
                }
                if (row["F_SPARE1"] != null)
                {
                    model.F_SPARE1 = row["F_SPARE1"].ToString();
                }
                if (row["F_SPARE2"] != null)
                {
                    model.F_SPARE2 = row["F_SPARE2"].ToString();
                }
                if (row["F_SPARE3"] != null)
                {
                    model.F_SPARE3 = row["F_SPARE3"].ToString();
                }
                if (row["F_SPARE4"] != null)
                {
                    model.F_SPARE4 = row["F_SPARE4"].ToString();
                }
                if (row["F_SPARE5"] != null)
                {
                    model.F_SPARE5 = row["F_SPARE5"].ToString();
                }
                if (row["F_SPARE6"] != null)
                {
                    model.F_SPARE6 = row["F_SPARE6"].ToString();
                }
                if (row["F_SPARE7"] != null)
                {
                    model.F_SPARE7 = row["F_SPARE7"].ToString();
                }
                if (row["F_SPARE8"] != null)
                {
                    model.F_SPARE8 = row["F_SPARE8"].ToString();
                }
                if (row["F_SPARE9"] != null)
                {
                    model.F_SPARE9 = row["F_SPARE9"].ToString();
                }
                if (row["F_SPARE10"] != null)
                {
                    model.F_SPARE10 = row["F_SPARE10"].ToString();
                }
                if (row["F_BY1"] != null)
                {
                    model.F_BY1 = row["F_BY1"].ToString();
                }
                if (row["F_BY2"] != null)
                {
                    model.F_BY2 = row["F_BY2"].ToString();
                }
                if (row["F_TXML"] != null)
                {
                    model.F_TXML = row["F_TXML"].ToString();
                }
                if (row["F_ZPZT"] != null)
                {
                    model.F_ZPZT = row["F_ZPZT"].ToString();
                }
                if (row["F_MCYJ"] != null)
                {
                    model.F_MCYJ = row["F_MCYJ"].ToString();
                }
                if (row["F_SFJJ"] != null)
                {
                    model.F_SFJJ = row["F_SFJJ"].ToString();
                }
                if (row["F_TBSID"] != null && row["F_TBSID"].ToString() != "")
                {
                    model.F_TBSID = int.Parse(row["F_TBSID"].ToString());
                }
                if (row["F_TBSMC"] != null)
                {
                    model.F_TBSMC = row["F_TBSMC"].ToString();
                }
                if (row["F_QSB_DYZT"] != null)
                {
                    model.F_QSB_DYZT = row["F_QSB_DYZT"].ToString();
                }
                if (row["F_BGWZ"] != null)
                {
                    model.F_BGWZ = row["F_BGWZ"].ToString();
                }
                if (row["F_BGWZ_QRSJ"] != null)
                {
                    model.F_BGWZ_QRSJ = row["F_BGWZ_QRSJ"].ToString();
                }
                if (row["F_BGWZ_QRCZY"] != null)
                {
                    model.F_BGWZ_QRCZY = row["F_BGWZ_QRCZY"].ToString();
                }
                if (row["F_BBWZ"] != null)
                {
                    model.F_BBWZ = row["F_BBWZ"].ToString();
                }
                if (row["F_LKWZ"] != null)
                {
                    model.F_LKWZ = row["F_LKWZ"].ToString();
                }
                if (row["F_QPWZ"] != null)
                {
                    model.F_QPWZ = row["F_QPWZ"].ToString();
                }
                if (row["F_GDCZY"] != null)
                {
                    model.F_GDCZY = row["F_GDCZY"].ToString();
                }
                if (row["F_GDSJ"] != null)
                {
                    model.F_GDSJ = row["F_GDSJ"].ToString();
                }
                if (row["F_GDBZ"] != null)
                {
                    model.F_GDBZ = row["F_GDBZ"].ToString();
                }
                if (row["F_BGLRY"] != null)
                {
                    model.F_BGLRY = row["F_BGLRY"].ToString();
                }
                if (row["F_FZYS"] != null)
                {
                    model.F_FZYS = row["F_FZYS"].ToString();
                }
                if (row["F_YL1"] != null)
                {
                    model.F_YL1 = row["F_YL1"].ToString();
                }
                if (row["F_YL2"] != null)
                {
                    model.F_YL2 = row["F_YL2"].ToString();
                }
                if (row["F_YL3"] != null)
                {
                    model.F_YL3 = row["F_YL3"].ToString();
                }
                if (row["F_YL4"] != null)
                {
                    model.F_YL4 = row["F_YL4"].ToString();
                }
                if (row["F_YL5"] != null)
                {
                    model.F_YL5 = row["F_YL5"].ToString();
                }
                if (row["F_YL6"] != null)
                {
                    model.F_YL6 = row["F_YL6"].ToString();
                }
                if (row["F_YL7"] != null)
                {
                    model.F_YL7 = row["F_YL7"].ToString();
                }
                if (row["F_YL8"] != null)
                {
                    model.F_YL8 = row["F_YL8"].ToString();
                }
                if (row["F_YL9"] != null)
                {
                    model.F_YL9 = row["F_YL9"].ToString();
                }
                if (row["F_YL10"] != null)
                {
                    model.F_YL10 = row["F_YL10"].ToString();
                }
                if (row["F_ICD10_BM1"] != null)
                {
                    model.F_ICD10_BM1 = row["F_ICD10_BM1"].ToString();
                }
                if (row["F_ICD10_MC1"] != null)
                {
                    model.F_ICD10_MC1 = row["F_ICD10_MC1"].ToString();
                }
                if (row["F_BL1"] != null)
                {
                    model.F_BL1 = row["F_BL1"].ToString();
                }
                if (row["F_BL2"] != null)
                {
                    model.F_BL2 = row["F_BL2"].ToString();
                }
                if (row["F_BL3"] != null)
                {
                    model.F_BL3 = row["F_BL3"].ToString();
                }
                if (row["F_BL4"] != null)
                {
                    model.F_BL4 = row["F_BL4"].ToString();
                }
                if (row["F_BL5"] != null)
                {
                    model.F_BL5 = row["F_BL5"].ToString();
                }
                if (row["F_BL6"] != null)
                {
                    model.F_BL6 = row["F_BL6"].ToString();
                }
                if (row["F_BL7"] != null)
                {
                    model.F_BL7 = row["F_BL7"].ToString();
                }
                if (row["F_BL8"] != null)
                {
                    model.F_BL8 = row["F_BL8"].ToString();
                }
                if (row["F_BL9"] != null)
                {
                    model.F_BL9 = row["F_BL9"].ToString();
                }
                if (row["F_BL10"] != null)
                {
                    model.F_BL10 = row["F_BL10"].ToString();
                }
                if (row["F_ICD10_BM2"] != null)
                {
                    model.F_ICD10_BM2 = row["F_ICD10_BM2"].ToString();
                }
                if (row["F_ICD10_MC2"] != null)
                {
                    model.F_ICD10_MC2 = row["F_ICD10_MC2"].ToString();
                }
                try
                {
                    if (row["F_FBSJ"] != null)
                    {
                        model.F_FBSJ = row["F_FBSJ"].ToString();
                    }
                }
                catch (Exception e)
                {
                    
                }
                try
                {
                    if (row["F_FBYS"] != null)
                    {
                        model.F_FBYS = row["F_FBYS"].ToString();
                    }
                }
                catch (Exception e)
                {
                    
                }
            }
            return model;
        }
        
    }
}

