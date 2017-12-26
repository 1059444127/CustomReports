using System;
using System.ComponentModel;

namespace CustomReports.Model
{
    public class SqlFilter
    {
        [DisplayName("�����")]
        public PathLibs? PathLibs { get; set; } = 0;

        [DisplayName("���������")]
        public string Blk { get; set; } = "ȫ��";

        [DisplayName("�յ�����1")]
        public DateTime? Sdrq1 { get; set; } = DateTime.Now.AddDays(-7);

        [DisplayName("�յ�����2")]
        public DateTime? Sdrq2 { get; set; } = DateTime.Now;

        [DisplayName("��������1")]
        public DateTime? Bgrq1 { get; set; } = DateTime.Now.AddDays(-30);

        [DisplayName("��������2")]
        public DateTime? Bgrq2 { get; set; } = DateTime.Now;

        [DisplayName("�����")]
        public string BLH { get; set; }

        [DisplayName("����")]
        public string Name { get; set; }

        [DisplayName("����ֵ��")]
        public int ValueDiff { get; set; } = 3;

        [DisplayName("����״̬")]
        public ReportStatuses ReportStatus { get; set; } = ReportStatuses.��д����;

        [DisplayName("�ͼ�ҽԺ")]
        public string SendHsp { get; set; } = "ȫ��";

        /// <summary>
        /// ��Ӧ���ôʷ���:f_bblx
        /// </summary>
        [DisplayName("��Ŀ����")]
        public string Xmfl { get; set; } = "ȫ��";

        [DisplayName("����״̬")]
        public Bgzts Bgzt { get; set; }

        [DisplayName("�����Ŀ")]
        public string Yzxm { get; set; } = "ȫ��";

        [DisplayName("�ٴ����")]
        public string Lczd { get; set; } = "";

        [DisplayName("�Ƿ�����")]
        public bool IsPositive { get; set; }

        [DisplayName("Σ��ֵ����")]
        public string CrisisText { get; set; }

        [DisplayName("ҽ������")]
        public string ҽ������ { get; set; }
    }

    /// <summary>
    /// ����״̬
    /// </summary>
    public enum ReportStatuses
    {
        ȫ��,�ѵǼ�,�����,��д����
    }
}