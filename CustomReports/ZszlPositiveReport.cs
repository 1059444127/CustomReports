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
    [Report("阳性结果查询", "广州中肿")]
    public partial class ZszlPositiveReport : XtraUserControl, IReport
    {
        public ZszlPositiveReport()
        {
            InitializeComponent();
            var filter = new SqlFilter();
            filter.Bgrq1 = null;
            filter.Bgrq2 = null;
            sqlFilterBindingSource.DataSource = filter;
            var lstBlk = T_BLK_CS_DAL.GetAll();
            var lstXmfl = T_CYC_DAL.GetListByFl(T_CYC_DAL.Dict.F_XMFL);
            var lstYzxm = T_CYC_DAL.GetListByFl(T_CYC_DAL.Dict.F_FZBL_YZXM);

            foreach (var blkCs in lstBlk)
                PathLibImageComboBoxEdit.Properties.Items.Add(blkCs.F_BLKMC);

            lstXmfl.ForEach(o => XmflComboBoxEdit.Properties.Items.Add(o.CycMc));
            lstYzxm.ForEach(o => YzxmComboBoxEdit.Properties.Items.Add(o.CycMc));
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
                
                //报告日期
                if (sqlFilter.Bgrq1.HasValue)
                    sqlWhere += $" and CONVERT(datetime,f_bgrq) >= CONVERT(datetime,'{sqlFilter.Bgrq1.Value.Date}') ";
                if (sqlFilter.Bgrq2.HasValue)
                    sqlWhere +=
                        $" and CONVERT(datetime,f_bgrq) <=CONVERT(datetime,'{sqlFilter.Bgrq2.Value.Date.AddDays(1)}') ";

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

                //检测项目(医嘱项目)
                if (string.IsNullOrEmpty(sqlFilter.Yzxm.Trim()) == false &&sqlFilter.Yzxm!="全部")
                {
                    sqlWhere += $" and f_yzxm = '{sqlFilter.Yzxm}' ";
                }

                //临床诊断
                if (string.IsNullOrEmpty(sqlFilter.Lczd.Trim()) == false)
                {
                    sqlWhere += $" and f_lczd like '%{sqlFilter.Lczd}%' ";
                }

                //是否阳性
                if (sqlFilter.IsPositive == false)
                {
                    sqlWhere += "and not";
                }
                else
                {
                    sqlWhere += " and ";
                }
                sqlWhere +=
                    " ((f_fz_blzd like '%突变型%' or F_FZ_BLZD like '%阳性%' or F_FZ_BLZD like '%不稳定%' )and( f_fz_blzd not LIKE '%未见%' and f_fz_blzd not LIKE '%微卫星稳定%')) ";

                string sql =
                    $"select t.*,t2.f_fz_blzd from t_jcxx t  inner join (select f_blh,f_fz_blzd from T_TBS_BG) t2 on t.F_BLH=t2.F_BLH where ";
                sql += sqlWhere;

                var dt1 = CommonDAL.GetTableBySql(sql);
                foreach (DataRow dr in dt1.Rows)
                {
                    var jcxx = T_JCXX_DAL.DataRowToModel(dr);
                    jcxx.F_FZ_BLZD = dr["f_fz_blzd"].ToString();
                    list1.Add(jcxx);
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