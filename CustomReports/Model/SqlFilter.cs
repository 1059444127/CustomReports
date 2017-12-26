using System;
using System.ComponentModel;

namespace CustomReports.Model
{
    public class SqlFilter
    {
        [DisplayName("病理库")]
        public PathLibs? PathLibs { get; set; } = 0;

        [DisplayName("病理库名称")]
        public string Blk { get; set; } = "全部";

        [DisplayName("收到日期1")]
        public DateTime? Sdrq1 { get; set; } = DateTime.Now.AddDays(-7);

        [DisplayName("收到日期2")]
        public DateTime? Sdrq2 { get; set; } = DateTime.Now;

        [DisplayName("报告日期1")]
        public DateTime? Bgrq1 { get; set; } = DateTime.Now.AddDays(-30);

        [DisplayName("报告日期2")]
        public DateTime? Bgrq2 { get; set; } = DateTime.Now;

        [DisplayName("病理号")]
        public string BLH { get; set; }

        [DisplayName("姓名")]
        public string Name { get; set; }

        [DisplayName("差异值≥")]
        public int ValueDiff { get; set; } = 3;

        [DisplayName("报告状态")]
        public ReportStatuses ReportStatus { get; set; } = ReportStatuses.已写报告;

        [DisplayName("送检医院")]
        public string SendHsp { get; set; } = "全部";

        /// <summary>
        /// 对应常用词分类:f_bblx
        /// </summary>
        [DisplayName("项目分类")]
        public string Xmfl { get; set; } = "全部";

        [DisplayName("报告状态")]
        public Bgzts Bgzt { get; set; }

        [DisplayName("检测项目")]
        public string Yzxm { get; set; } = "全部";

        [DisplayName("临床诊断")]
        public string Lczd { get; set; } = "";

        [DisplayName("是否阳性")]
        public bool IsPositive { get; set; }

        [DisplayName("危急值内容")]
        public string CrisisText { get; set; }

        [DisplayName("医生姓名")]
        public string 医生姓名 { get; set; }
    }

    /// <summary>
    /// 报告状态
    /// </summary>
    public enum ReportStatuses
    {
        全部,已登记,已审核,已写报告
    }
}