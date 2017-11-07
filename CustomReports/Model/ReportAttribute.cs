using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomReports.Model
{
    public class ReportAttribute:Attribute
    {
        public ReportAttribute(string reportName,string hspName)
        {
            ReportName = reportName;
            HspName = hspName;
        }

        public string ReportName { get; set; }

        public string HspName { get; set; }
    }
}
