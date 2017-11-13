using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CustomReports.Model
{
    public partial class T_JCXX
    {
        public int TBS_VALUE { get; set; }
        public T_JCXX PreJcxx { get; set; }

        [DisplayName("差异值")]
        public int TBS_VALUE_DIFF
        {
            get
            {
                var preJcxx = this.PreJcxx;
                if (preJcxx != null) return this.TBS_VALUE - preJcxx.TBS_VALUE;
                return 0;
            }
        }

        public string F_FZ_BLZD { get; set; }

        [DisplayName("病历号")]
        public string 病历号 => this.F_ZYH.Trim() + this.F_MZH.Trim();

        [DisplayName("异常备注")]
        public string 异常备注 => this.F_WFBGYY.Trim() + this.F_SPARE9;

        [DisplayName("报告发放天数")]
        public int 发放天数 { get; set; }

        [DisplayName("DNA/RNA浓度")]
        public string F_DNAZK { get; set; }

        [DisplayName("病理质控")]
        public string F_RNAZK { get; set; }
    }
}
