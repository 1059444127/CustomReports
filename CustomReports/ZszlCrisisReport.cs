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
    /// 统计外院送检情况
    /// </summary>
    [Report("危急值统计", "广中中山一")]
    public partial class ZszlCrisisReport : XtraUserControl, IReport,IGroupable
    {
        public ZszlCrisisReport()
        {
            InitializeComponent();
            sqlFilterBindingSource.DataSource = new SqlFilter();
            var lstBlk = T_BLK_CS_DAL.GetAll();
            
            foreach (var blkCs in lstBlk)
            {
                PathLibsImageComboBoxEdit.Properties.Items.Add(blkCs.F_BLKMC);
            }

        }

        #region Implementation of IReport

        public void Query()
        {
            dataLayoutControl1.Validate();

            T_JCXX_DAL dal = new T_JCXX_DAL();
            var sqlFilter = sqlFilterBindingSource.Current as SqlFilter;
            var list1 = new List<T_JCXX>();

            SplashScreenManager.ShowDefaultWaitForm($"正在查询");

            try
            {
                var sqlWhere = "1 =1 ";
                sqlWhere += $" and f_bz<>'' ";
                if (sqlFilter.Blk != null && (sqlFilter.Blk != "全部" && sqlFilter.Blk != ""))
                {
                    sqlWhere += $" and f_blk='{sqlFilter.Blk}' ";
                }
                if (sqlFilter.Bgrq1.HasValue)
                {
                    //收到日期
                    sqlWhere += $" and CONVERT(datetime,f_bgrq) >= CONVERT(datetime,'{sqlFilter.Bgrq1.Value.Date}') ";
                }
                if (sqlFilter.Bgrq2.HasValue)
                {
                    sqlWhere += $" and CONVERT(datetime,f_bgrq) <=CONVERT(datetime,'{sqlFilter.Bgrq2.Value.Date.AddDays(1)}') ";
                }
                if (!string.IsNullOrEmpty(sqlFilter.CrisisText))
                {
                    sqlWhere += $" and f_bz like '%{sqlFilter.CrisisText}%' ";
                }

                list1 = T_JCXX_DAL.GetBySqlWhere(sqlWhere,"f_bgrq");
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

        #region Implementation of IGroupable

        public void ExpandAll()
        {
            gridView1.ExpandAllGroups();
        }

        public void CollapseAll()
        {
            gridView1.CollapseAllGroups();
        }

        #endregion
    }
}