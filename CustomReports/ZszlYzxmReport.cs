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
    /// 统计项目合计数
    /// </summary>
    [Report("项目统计","广州中肿")]
    public partial class ZszlYzxmReport : XtraUserControl, IReport
    {
        public ZszlYzxmReport()
        {
            InitializeComponent();
            var filter = new SqlFilter();
            filter.Bgrq1 = null;
            filter.Bgrq2 = null;
            sqlFilterBindingSource.DataSource = filter;
            var lstBlk = T_BLK_CS_DAL.GetAll();
            var lstCyc = T_CYC_DAL.GetListByFl("F_sjdw");
            var lstXmfl = T_CYC_DAL.GetListByFl("f_bblx");
            
            foreach (var blkCs in lstBlk)
            {
                PathLibImageComboBoxEdit.Properties.Items.Add(blkCs.F_BLKMC);
            }

            foreach (T_CYC cyc in lstCyc)
            {
                SendHspComboBoxEdit.Properties.Items.Add(cyc.CycMc);
            }

            cmbCmfl.Properties.Items.Add("全部");
            lstXmfl.ForEach(o=>cmbCmfl.Properties.Items.Add(o.CycMc));
            cmbCmfl.SelectedIndex = 0;

            Sdrq1DateEdit.EditValue= new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            Bgrq1DateEdit.EditValue = null;

        }

        #region Implementation of IReport

        public void Query()
        {
            dataLayoutControl1.Validate();
            var sqlFilter = sqlFilterBindingSource.Current as SqlFilter;
            var dtResult = new DataTable();
            
            SplashScreenManager.ShowDefaultWaitForm($"正在查询");

            try
            {
                var sqlWhere = "1 =1 ";

                //病理库
                if (sqlFilter.Blk != null && (sqlFilter.Blk != "全部" && sqlFilter.Blk != ""))
                {
                    sqlWhere += $" and f_blk='{sqlFilter.Blk}' ";
                }

                //项目分类
                if (sqlFilter.Xmfl != null && (sqlFilter.Xmfl != "全部" && sqlFilter.Xmfl != ""))
                {
                    sqlWhere += $" and f_bblx='{sqlFilter.Xmfl}' ";
                }

                //送检单位
                if (sqlFilter.SendHsp != null && (sqlFilter.SendHsp != "全部" && sqlFilter.SendHsp != ""))
                {
                    sqlWhere += $" and f_sjdw='{sqlFilter.SendHsp}' ";
                }

                //收到日期
                if (sqlFilter.Sdrq1.HasValue)
                {
                    sqlWhere += $" and CONVERT(datetime,f_sdrq) >= CONVERT(datetime,'{sqlFilter.Sdrq1.Value.Date}') ";
                }
                if (sqlFilter.Sdrq2.HasValue)
                {
                    sqlWhere += $" and CONVERT(datetime,f_sdrq) <=CONVERT(datetime,'{sqlFilter.Sdrq2.Value.Date.AddDays(1)}') ";
                }

                //报告日期
                if (sqlFilter.Bgrq1.HasValue)
                {
                    sqlWhere += $" and CONVERT(datetime,f_bgrq) >= CONVERT(datetime,'{sqlFilter.Bgrq1.Value.Date}') ";
                }
                if (sqlFilter.Bgrq2.HasValue)
                {
                    sqlWhere += $" and CONVERT(datetime,f_bgrq) <=CONVERT(datetime,'{sqlFilter.Bgrq2.Value.Date.AddDays(1)}') ";
                }

                //报告状态
                if (sqlFilter.Bgzt != Bgzts.全部)
                {
                    sqlWhere += $" and f_bgzt = '{sqlFilter.Bgzt}' ";
                }

                string sql = " select f_yzxm as 检测项目,count(*) 检测例数 from t_jcxx where " + sqlWhere + "group by f_yzxm ";

                var dt1 = CommonDAL.GetTableBySql(sql);
                if (dt1.Rows.Count == 0)
                {
                    XtraMessageBox.Show("没有找到任何结果!");
                    return;
                }
                //处理名称带有^的
                foreach (DataRow row in dt1.Rows)
                {
                    var yzxm = row["检测项目"].ToString();
                    if (yzxm.Split('^').Length > 1)
                    {
                        yzxm = yzxm.Split('^')[1];
                        row["检测项目"] = yzxm;
                    }
                }

                //处理完成后,合并名称相同的行
                dtResult = dt1.Clone();
                foreach (DataRow rowSource in dt1.Rows)
                {
                    var rowResult =
                        dtResult.Rows.Cast<DataRow>()
                            .SingleOrDefault(o => o["检测项目"].ToString() == rowSource["检测项目"].ToString());
                    if (rowResult == null)
                        dtResult.ImportRow(rowSource);
                    else
                        rowResult["检测例数"] = Convert.ToInt32(rowResult["检测例数"]) + Convert.ToInt32(rowSource["检测例数"]);
                }

                dtResult.DefaultView.Sort = "检测项目";

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
            
            gridControl1.DataSource = dtResult;
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
    }
}