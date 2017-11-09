using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CustomReports.Model;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace CustomReports
{
    /// <summary>
    ///     广中中山大学附属一一院
    ///     工作量统计表
    /// </summary>
    [Report("工作量报表", "广中中山一")]
    public partial class GzzsfyMonthlyReport : XtraUserControl, IReport
    {
        public GzzsfyMonthlyReport()
        {

            InitializeComponent();
            sqlFilterBindingSource.DataSource = new SqlFilter();
        }

        #region Implementation of IReport

        public void Query()
        {
            dataLayoutControl1.Validate();

            var dal = new T_JCXX_DAL();
            var sqlFilter = sqlFilterBindingSource.Current as SqlFilter;
            var list = new List<ReportItem>();

            SplashScreenManager.ShowDefaultWaitForm($"正在查询");

            try
            {
                var sqlWhere = "1 =1 ";
                
                //报告日期
                if (sqlFilter.Bgrq1.HasValue)
                    sqlWhere += $" and CONVERT(datetime,f_sdrq) >= CONVERT(datetime,'{sqlFilter.Bgrq1.Value.Date}') ";
                if (sqlFilter.Bgrq2.HasValue)
                    sqlWhere +=
                        $" and CONVERT(datetime,f_sdrq) <=CONVERT(datetime,'{sqlFilter.Bgrq2.Value.Date.AddDays(1)}') ";

                sqlWhere += $" and f_blk in ('常规','小标本','细胞学','病理会诊','细针穿刺','肾穿1','肾穿2') ";

                string sql = $" select count(*) c,case when ltrim(rtrim(f_zyh))='' then '0' else '1' end as zy, f_blk,F_SJDW,F_SFFH,f_sjks from t_jcxx" +
                             $" where {sqlWhere} " +
                             $" group by f_blk,f_sjks,F_SJDW,F_SFFH,case when ltrim(rtrim(f_zyh))='' then '0' else '1' end ";
                var dtSource = CommonDAL.GetTableBySql(sql);

                //处理数据
                var queryableSource = from o in dtSource.Rows.Cast<DataRow>()
                    select new
                    {
                        count = Convert.ToInt32(o["c"]),
                        blk = o["f_blk"].ToString(),
                        sjdw = o["f_sjdw"].ToString(),
                        sffh = o["f_sffh"].ToString(),
                        zy = o["zy"].ToString(),
                        sjks=o["f_sjks"].ToString().Trim()
                    };

                //常规检查
                var commonItem = new ReportItem();
                list.Add(commonItem);
                var queryableCommon = queryableSource.Where(o => o.blk == "常规" || o.blk == "小标本");
                commonItem.序号 = 1;
                commonItem.类别 = "病理检查(常规)";
                commonItem.总人次数 = queryableCommon.Sum(o=>o.count);
                commonItem.诊断符合人次数 = queryableCommon.Where(o=>o.sffh != "不符合").Sum(o => o.count);

                //常规检查_院外
                var commonItemOutside = new ReportItem();
                list.Add(commonItemOutside);
                var queryableCommonOutSide = queryableSource.Where(o => o.blk == "常规" || o.blk == "小标本").Where(o=>o.sjdw!= "中山大学附一院");
                commonItemOutside.序号 = 1;
                commonItemOutside.类别 = "院外";
                commonItemOutside.总人次数 = queryableCommonOutSide.Sum(o => o.count);
                commonItemOutside.诊断符合人次数 = queryableCommonOutSide.Where(o => o.sffh != "不符合").Sum(o => o.count);

                //常规检查_院内
                var commonItemInside = new ReportItem();
                list.Add(commonItemInside);
                var queryableCommonInSide = queryableSource.Where(o => o.blk == "常规" || o.blk == "小标本").Where(o => o.sjdw == "中山大学附一院");
                commonItemInside.序号 = 1;
                commonItemInside.类别 = "院内合计";
                commonItemInside.总人次数 = queryableCommonInSide.Sum(o => o.count);
                commonItemInside.诊断符合人次数 = queryableCommonInSide.Where(o => o.sffh != "不符合").Sum(o => o.count);

                //常规检查_院内_门诊
                var commonItemInsideMz = new ReportItem();
                list.Add(commonItemInsideMz);
                var queryableCommonInSideMz = queryableCommonInSide.Where(o => o.zy != "1");
                commonItemInsideMz.序号 = 1;
                commonItemInsideMz.类别 = "院内门诊";
                commonItemInsideMz.总人次数 = queryableCommonInSideMz.Sum(o => o.count);
                commonItemInsideMz.诊断符合人次数 = queryableCommonInSideMz.Where(o => o.sffh != "不符合").Sum(o => o.count);

                //常规检查_院内_门诊
                var commonItemInsideZy = new ReportItem();
                list.Add(commonItemInsideZy);
                var queryableCommonInSideZy = queryableCommonInSide.Where(o => o.zy == "1");
                commonItemInsideZy.序号 = 1;
                commonItemInsideZy.类别 = "院内住院";
                commonItemInsideZy.总人次数 = queryableCommonInSideZy.Sum(o => o.count);
                commonItemInsideZy.诊断符合人次数 = queryableCommonInSideZy.Where(o => o.sffh != "不符合").Sum(o => o.count);

                //非妇科细胞学涂片
                var itemCell = new ReportItem();
                list.Add(itemCell);
                var queryableCell = queryableSource.Where(o => o.blk=="细胞学");
                itemCell.序号 = 2;
                itemCell.类别 = "非妇科细胞学涂片";
                itemCell.总人次数 = queryableCell.Sum(o => o.count);
                itemCell.诊断符合人次数 = queryableCell.Where(o => o.sffh != "不符合").Sum(o => o.count);

                //会诊病例
                var itemHz = new ReportItem();
                list.Add(itemHz);
                var queryableHz = queryableSource.Where(o => o.blk == "病理会诊");
                itemHz.序号 = 6;
                itemHz.类别 = "会诊病例";
                itemHz.总人次数 = queryableHz.Sum(o => o.count);
                itemHz.诊断符合人次数 = queryableHz.Where(o => o.sffh != "不符合").Sum(o => o.count);

                //本院肾穿
                var itemInSc = new ReportItem();
                list.Add(itemInSc);
                var queryableInSc = queryableSource.Where(o => o.blk == "肾穿1" || (o.blk=="肾穿2" && o.sjks.Trim()!=""));
                itemInSc.序号 = 9;
                itemInSc.类别 = "本院肾穿";
                itemInSc.总人次数 = queryableInSc.Sum(o => o.count);
                itemInSc.诊断符合人次数 = queryableInSc.Where(o => o.sffh != "不符合").Sum(o => o.count);

                //外院肾穿
                var itemOutSc = new ReportItem();
                list.Add(itemOutSc);
                var queryableOutSc = queryableSource.Where(o => o.blk == "肾穿2" && o.sjks.Trim() == "");
                itemOutSc.序号 = 9;
                itemOutSc.类别 = "外院肾穿";
                itemOutSc.总人次数 = queryableOutSc.Sum(o => o.count);
                itemOutSc.诊断符合人次数 = queryableOutSc.Where(o => o.sffh != "不符合").Sum(o => o.count);

                //细针穿刺
                var itemCC = new ReportItem();
                list.Add(itemCC);
                var queryableCC = queryableSource.Where(o => o.blk == "细针穿刺");
                itemCC.序号 = 10;
                itemCC.类别 = "细针穿刺";
                itemCC.总人次数 = queryableCC.Sum(o => o.count);
                itemCC.诊断符合人次数 = queryableCC.Where(o => o.sffh != "不符合").Sum(o => o.count);

                //合计
                var itemAll = new ReportItem();
                var queryableAll = queryableSource;
                var 合计类别 = new string[] { "病理检查(常规)", "细针穿刺", "外院肾穿", "本院肾穿", "会诊病例", "非妇科细胞学涂片" };
                itemAll.序号 = 99;
                itemAll.类别 = "总计";
                itemAll.总人次数 = list.Where(o=>合计类别.Contains(o.类别)).Sum(o => o.总人次数);
                itemAll.诊断符合人次数 = list.Where(o => 合计类别.Contains(o.类别)).Sum(o=>o.诊断符合人次数);
                list.Add(itemAll);

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
                return;
            }
            finally
            {
                try
                {
                    SplashScreenManager.CloseDefaultWaitForm();
                }
                catch
                {
                }
            }

            if (list.Count == 0)
                XtraMessageBox.Show("没有找到任何结果!");
            reportItemBindingSource.DataSource = list;
            gridView1.RefreshData();
            gridView1.ExpandAllGroups();

            gridView1.BestFitColumns();
        }

        public void Print()
        {
            gridView1.PrintDialog();
        }

        public void ExportExcel()
        {
            var sd = new SaveFileDialog();
            sd.DefaultExt = "xls";
            var r = sd.ShowDialog();
            if (r != DialogResult.OK)
                return;

            gridView1.ExportToXls(sd.FileName);
        }

        public XtraUserControl Control => this;

        #endregion


        public class ReportItem
        {
            public int 序号 { get; set; }
            public string 类别 { get; set; }
            public int 总人次数 { get; set; }
            public int 无诊断对比人次数 { get; set; }
            public int 诊断符合人次数 { get; set; }

            public string 临床诊断与病理诊断符合率
            {
                get
                {
                    try
                    {
                        var percent = ((double) 诊断符合人次数 * 100 / (double) 总人次数).ToString("F2") + "%";
                        if (percent == "NaN%")
                            return "-";
                        return percent;
                    }
                    catch
                    {
                        return "-";
                    }
                }
            }
        }
    }

}