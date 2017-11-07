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
    ///     中山肿瘤附属医院分子病理报表
    ///     统计外院送检情况
    /// </summary>
    [Report("异常报告查询", "广州中肿")]
    public partial class ZszlExceptionReport : XtraUserControl, IReport
    {
        public ZszlExceptionReport()
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

                //项目分类
                if (sqlFilter.Xmfl != null && (sqlFilter.Xmfl != "全部" && sqlFilter.Xmfl.Trim() != ""))
                {
                    sqlWhere += $" and f_bblx='{sqlFilter.Xmfl}' ";
                }

                sqlWhere += " and ( trim(f_WFBGYY)!='' and trim(f_spare9)!= '' )";

                list1 = T_JCXX_DAL.GetBySqlWhere(sqlWhere);
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
            var sd = new SaveFileDialog();
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