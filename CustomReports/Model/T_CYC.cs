using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CustomReports.Model
{
    public class T_CYC
    {
        public string Id { get; set; }
        public string Pxid { get; set; }
        public string CycMc { get; set; }
        public string Zjc1 { get; set; }
        public string Zjc2 { get; set; }
        public string CycFl { get; set; }

        public T_CYC()
        {
            
        }

        public T_CYC(DataRow dr)
        {
            this.Id = dr["F_ID"].ToString();
            this.Pxid = dr["F_PXID"].ToString();
            this.CycMc = dr["F_CYC_MC"].ToString();
            this.CycFl = dr["F_CYC_FL"].ToString();
            this.Zjc1 = dr["F_ZJC1"].ToString();
            this.Zjc2 = dr["F_ZJC2"].ToString();
        }
    }
}