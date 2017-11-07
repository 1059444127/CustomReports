using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using dbbase;

namespace CustomReports.Model
{
    public static class CommonDAL
    {
        static dbbase.odbcdb aa = new odbcdb("DSN=pathnet;UID=pathnet;PWD=4s3c2a1p", "", "");

        public static DataTable GetTableBySql(string sql)
        {

            return aa.GetDataTable(sql,"table1");
        }
    }
}
