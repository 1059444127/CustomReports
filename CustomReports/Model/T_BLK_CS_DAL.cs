using System.Collections.Generic;
using System.Data;
using dbbase;

namespace CustomReports.Model
{
    public class T_BLK_CS_DAL
    {
        private static dbbase.odbcdb aa = new odbcdb("DSN=pathnet;UID=pathnet;PWD=4s3c2a1p", "", "");

        public static List<T_BLK_CS> GetAll()
        {
            List<T_BLK_CS> lstCyc = new List<T_BLK_CS>();

            var dtCyc = aa.GetDataTable($" select * from T_BLK_CS t ", "dt1");
            if(dtCyc!=null)
                foreach (DataRow row in dtCyc.Rows)
                {
                    lstCyc.Add(T_BLK_CS.DataRowToModel(row));
                }
            return lstCyc;
        }
    }
}