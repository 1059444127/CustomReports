using System;
using System.Collections;
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
    ///     中山肿瘤附属医院分子病理报表
    ///    检查天数查询
    /// </summary>
    [Report("检查天数查询", "广州中肿")]
    public partial class ZszlTestDayReport : XtraUserControl, IReport
    {


        public ZszlTestDayReport()
        {
            InitializeComponent();
            sqlFilterBindingSource.DataSource = new SqlFilter();
            var lstBlk = T_BLK_CS_DAL.GetAll();
            var lstXmfl = T_CYC_DAL.GetListByFl(T_CYC_DAL.Dict.F_XMFL);

            foreach (var blkCs in lstBlk)
                PathLibImageComboBoxEdit.Properties.Items.Add(blkCs.F_BLKMC);

            lstXmfl.ForEach(o => XmflComboBoxEdit.Properties.Items.Add(o.CycMc));
        }

        #region Implementation of IReport

        public void Query()
        {
            dataLayoutControl1.Validate();

            var dal = new T_JCXX_DAL();
            var sqlFilter = sqlFilterBindingSource.Current as SqlFilter;
            var list1 = new List<T_JCXX>();

            SplashScreenManager.ShowDefaultWaitForm($"正在查询");

            try
            {
                var sqlWhere = "1 =1 ";

                //病例库
                if (sqlFilter.Blk != null && sqlFilter.Blk != "全部" && sqlFilter.Blk != "")
                    sqlWhere += $" and f_blk='{sqlFilter.Blk}' ";

                //收到日期
                if (sqlFilter.Sdrq1.HasValue)
                    sqlWhere += $" and CONVERT(datetime,f_sdrq) >= CONVERT(datetime,'{sqlFilter.Sdrq1.Value.Date}') ";
                if (sqlFilter.Sdrq2.HasValue)
                    sqlWhere +=
                        $" and CONVERT(datetime,f_sdrq) <=CONVERT(datetime,'{sqlFilter.Sdrq2.Value.Date.AddDays(1)}') ";

                //报告状态
                if (sqlFilter.Bgzt != Bgzts.全部)
                {
                    sqlWhere += $" and f_bgzt = '{sqlFilter.Bgzt}' ";
                }
                else
                {
                    sqlWhere += $" and f_bgzt in ('已写报告','已审核') ";
                }

                //项目分类
                if (sqlFilter.Xmfl != null && (sqlFilter.Xmfl != "全部" && sqlFilter.Xmfl.Trim() != ""))
                {
                    sqlWhere += $" and f_bblx='{sqlFilter.Xmfl}' ";
                }

                list1 = T_JCXX_DAL.GetBySqlWhere(sqlWhere);

                //处理报告发放天数
                foreach (T_JCXX jcxx in list1)
                {
                    jcxx.发放天数 = GetDays(jcxx);
                    //去掉项目前面的编号
                    if (jcxx.F_YZXM.Split('^').Length > 1)
                        jcxx.F_YZXM = jcxx.F_YZXM.Split('^')[1];
                }

                //获得合计
                var reportCountList = (from o in list1
                    group o by o.发放天数
                    into g
                    orderby Convert.ToInt32(g.Key)
                    select new
                    {
                        工作日 = g.Key.ToString(),
                        数量 = g.Count()
                    }
                    ).ToList();

                var totalCount = reportCountList.Sum(o => o.数量);
              
                reportCountList.Add(new {工作日 = "合计", 数量 = totalCount});

                gridControl2.DataSource = reportCountList;
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

            if (list1.Any() == false)
                XtraMessageBox.Show("没有找到任何结果!");
            tJCXXBindingSource.DataSource = list1;
            gridView1.RefreshData();
            gridView1.ExpandAllGroups();

            gridView1.BestFitColumns();
        }

        /// <summary>
        /// 根据报告的收到日期和审核日期,计算报告发放的天数
        /// </summary>
        /// <param name="jcxx"></param>
        /// <returns></returns>
        private int GetDays(T_JCXX jcxx)
        {
            var bgrq = Convert.ToDateTime(jcxx.F_BGRQ).Date;
            var sdrq = Convert.ToDateTime(jcxx.F_SDRQ).Date;

            //收到日期不应该大于报告日期 ,如果出现这种情况,说明数据有错误
            if (sdrq > bgrq)
                return -1;

            int dayDiff = 0;

            //如果时间大于100,则显示100,更多的计算没有意义,且会让程序变慢
            while (bgrq != sdrq & dayDiff <= 100)
            {
                //是否排除周六日
                if (chkDisable6.Checked && sdrq.DayOfWeek == DayOfWeek.Saturday)
                {
                    //排除周六
                }
                else if (chkDisable7.Checked && sdrq.DayOfWeek == DayOfWeek.Sunday)
                {
                    //排除周日
                }
                else
                {
                    dayDiff++;
                }
                sdrq = sdrq.AddDays(1);
            }

            return dayDiff;
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

            if (xtraTabControl1.SelectedTabPage== xtraTabPage1)
            {
                gridView1.ExportToXls(sd.FileName);
            }
            if (xtraTabControl1.SelectedTabPage == xtraTabPage2)
            {
                gridView2.ExportToXls(sd.FileName);
            }
        }

        public XtraUserControl Control => this;

        #endregion
    }
}