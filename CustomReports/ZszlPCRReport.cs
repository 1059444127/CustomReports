using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomReports.Model;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace CustomReports
{
    /// <summary>
    /// 中山肿瘤附属医院分子病理报表
    /// 统计EBV,HBV进行过两次诊断的病人的两次结果值的差异
    /// </summary>
    [Report("EBV,HBV统计","广州中肿")]
    public partial class ZszlPCRReport : XtraUserControl, IReport
    {
        public ZszlPCRReport()
        {
            InitializeComponent();
            sqlFilterBindingSource.DataSource = new SqlFilter();
        }


        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            var jcxx = gridView1.GetRow(e.RowHandle) as T_JCXX;
            if (jcxx == null)
                return;

            if (Math.Abs(jcxx.TBS_VALUE_DIFF) >= 3)
                e.Appearance.ForeColor = Color.Red;
        }

        #region Implementation of IReport

        public void Query()
        {
            dataLayoutControl1.Validate();

            T_JCXX_DAL dal = new T_JCXX_DAL();
            var sqlFilter = sqlFilterBindingSource.Current as SqlFilter;
            var list1 = dal.GetJcxxTbsList(sqlFilter);

            SplashScreenManager.ShowDefaultWaitForm($"正在查询");

            try
            {
                foreach (T_JCXX jcxx in list1)
                {
                    SplashScreenManager.ShowDefaultWaitForm($"分析二次诊断数据 {list1.IndexOf(jcxx)}/{list1.Count}");
                    T_JCXX jcxxPre = dal.GetPreJcxx(jcxx);
                    jcxx.PreJcxx = jcxxPre;
                }
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

            //去掉没有上次检验的
            list1 = list1.Where(o => o.PreJcxx != null && string.IsNullOrEmpty(o.PreJcxx.F_BLH) == false).ToList();
            //差异值过滤
            if (sqlFilter != null && sqlFilter.ValueDiff > 0)
                list1 = list1.Where(o => Math.Abs(o.TBS_VALUE_DIFF) >= Math.Abs(sqlFilter.ValueDiff)).ToList();

            if (list1.Any() == false)
                XtraMessageBox.Show("没有找到任何结果!");
            tJCXXBindingSource.DataSource = list1;
            gridView1.RefreshData();
            gridView1.BestFitColumns();
        }

        public void Print()
        {
            gridView1.PrintDialog();
        }

        public void ExportExcel()
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.DefaultExt = "xls";
            var r = sd.ShowDialog();
            if (r != DialogResult.OK)
                return;

            gridView1.ExportToXls(sd.FileName);
        }

        public XtraUserControl Control => this;

        #endregion
    }
}