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
    /// 中山附一特殊染色统计
    /// 统计项目合计数
    /// </summary>
    [Report("特殊染色统计", "广中中山一")]
    public partial class ZsfySpecialDyeingReport : XtraUserControl, IReport
    {
        public ZsfySpecialDyeingReport()
        {
            InitializeComponent();
            var filter = new SqlFilter();
            filter.Bgrq1 = null;
            filter.Bgrq2 = null;
            sqlFilterBindingSource.DataSource = filter;

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

                //收到日期
                if (sqlFilter.Sdrq1.HasValue)
                {
                    sqlWhere += $" and CONVERT(datetime,f_sdrq) >= CONVERT(datetime,'{sqlFilter.Sdrq1.Value.Date}') ";
                }
                if (sqlFilter.Sdrq2.HasValue)
                {
                    sqlWhere += $" and CONVERT(datetime,f_sdrq) < CONVERT(datetime,'{sqlFilter.Sdrq2.Value.Date.AddDays(1)}') ";
                }

                string sql1 = @"SELECT 
count(*) as 合计,
sum(case when j.f_blk in ('小标本','常规','冰冻') then 1 else 0 end ) as 常规特染数,
sum(case when j.f_blk='肾穿1' then 1 else 0 end ) as 肾穿1数,
sum(case when j.f_blk='肾穿2' then 1 else 0 end ) as 肾穿2数,
sum(case when j.f_blk='肌肉' then 1 else 0 end ) as 肌肉数
FROM T_TJYZ t inner join t_jcxx j on t.f_blh = j.f_blh
where f_yzlx='特殊染色' and " + sqlWhere;
                string sql2 = @"SELECT 
count(*) as 合计例数,
sum(case when j.f_blk in ('小标本','常规','冰冻') then 1 else 0 end ) as 常规特染例数,
sum(case when j.f_blk='肾穿1' then 1 else 0 end ) as 肾穿1例数,
sum(case when j.f_blk='肾穿2' then 1 else 0 end ) as 肾穿2例数,
sum(case when j.f_blk='肌肉' then 1 else 0 end ) as 肌肉例数
FROM t_jcxx j where exists (select 1 from T_TJYZ t where t.F_BLH=j.f_blh and t.F_YZLX='特殊染色')
 and " + sqlWhere;

                var dt1 = CommonDAL.GetTableBySql(sql1);
                var dt2 = CommonDAL.GetTableBySql(sql2);
                if (dt1.Rows.Count == 0)
                {
                    XtraMessageBox.Show("没有找到任何结果!");
                    return;
                }

                //查询结果为空时,填充0
                foreach (DataColumn column in dt1.Columns)
                {
                    if (dt1.Rows[0][column].ToString() == "")
                    {
                        dt1.Rows[0][column] = 0;
                    }
                }
                foreach (DataColumn column in dt2.Columns)
                {
                    if (dt2.Rows[0][column].ToString() == "")
                    {
                        dt2.Rows[0][column] = 0;
                    }
                }

                //处理数据
                dtResult.Columns.Add("序号",typeof(Int32));
                dtResult.Columns.Add("统计项目");
                dtResult.Columns.Add("例数", typeof(Int32));
                dtResult.Columns.Add("项目数", typeof(Int32));
                var drSource1= dt1.Rows[0];
                var drSource2 = dt2.Rows[0];

                var number = 1;
                foreach (DataColumn dcSource in dt1.Columns)
                {
                    var drReport = dtResult.NewRow();
                    dtResult.Rows.Add(drReport);

                    drReport["序号"] = number++;
                    drReport["统计项目"] = dcSource.ColumnName.TrimEnd('数');
                    var count = Convert.ToInt32(drSource1[dcSource.ColumnName]);
                    var countBlh = Convert.ToInt32(drSource2[dcSource.ColumnName.TrimEnd('数')+"例数"]);
                    drReport["项目数"] = count;
                    drReport["例数"] = countBlh;
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