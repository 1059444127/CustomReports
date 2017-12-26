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
    #region 报表需求

    //2、医生工作量统计
    //查询条件：收到日期（区间）、病例库（可以导出）
    //如:
        
    //取材 常规工作量
    //例 盒     初诊 复诊
    //医生A   16  232       2    3        
    //医生B   12  232       3    4        
    //医生C   13  112       5    1      

    //取材例数：t_jcxx表中 f_qcys的数量
    //取材盒数：T_QCMX个中f_qcys的数量
    //常规工作量初诊：t_jcxx表中=f_bgys的数量
    //常规工作量复诊：t_jcxx表中like f_fzys的数量, 如果f_fzys中有f_bgys的人的时候，则不统计。

    #endregion

    /// <summary>
    /// 广西肿瘤医院
    /// 疑难病例查询
    /// </summary>
    [Report("医生工作量统计", "广西肿瘤")]
    public partial class GxzlysgzlReport : XtraUserControl, IReport
    {
        public GxzlysgzlReport()
        {
            InitializeComponent();
            sqlFilterBindingSource.DataSource = new SqlFilter();
            var lstBlk = T_BLK_CS_DAL.GetAll();
            
            foreach (var blkCs in lstBlk)
            {
                PathLibImageComboBoxEdit.Properties.Items.Add(blkCs.F_BLKMC);
            }
        }

        #region Implementation of IReport

        public void Query()
        {
            dataLayoutControl1.Validate();

            T_JCXX_DAL dal = new T_JCXX_DAL();
            List<T_YH> yhList = null;
            var dataEntities = new List<DataEntity>();

            var sqlFilter = sqlFilterBindingSource.Current as SqlFilter;

            SplashScreenManager.ShowDefaultWaitForm($"正在查询");

            try
            {
                string sqlCg = " select f_bgys bgys,f_fzys fzys from [dbo].[T_JCXX] t where F_BZ like '疑难病例' ";
                string sqlWhereCg = "";
                string sqlQC =
                    "select t.F_QCYS qcys,count(distinct t.f_blh) lishu,count(*) heshu from t_jcxx t left join T_QCMX q on t.F_BLH=q.F_BLH ";
                string sqlWhereQc = " where 1=1 ";
                string sqlGroupQc = " group by t.F_QCYS ";

                if (sqlFilter.Blk != null && (sqlFilter.Blk != "全部" && sqlFilter.Blk != ""))
                {
                    sqlWhereCg += $" and t.f_blk='{sqlFilter.Blk}' ";
                    sqlWhereQc += $" and t.f_blk='{sqlFilter.Blk}' ";
                }

                if (sqlFilter.Sdrq1.HasValue)
                {
                    //收到日期
                    sqlWhereCg += $" and CONVERT(datetime,t.f_sdrq) >= CONVERT(datetime,'{sqlFilter.Sdrq1.Value.Date}') ";
                    sqlWhereQc += $" and CONVERT(datetime,t.f_sdrq) >= CONVERT(datetime,'{sqlFilter.Sdrq1.Value.Date}') ";

                }
                if (sqlFilter.Sdrq2.HasValue)
                {
                    sqlWhereCg += $" and CONVERT(datetime,t.f_sdrq) <=CONVERT(datetime,'{sqlFilter.Sdrq2.Value.Date.AddDays(1)}') ";
                    sqlWhereQc += $" and CONVERT(datetime,t.f_sdrq) <=CONVERT(datetime,'{sqlFilter.Sdrq2.Value.Date.AddDays(1)}') ";
                }
                //如果输入医生姓名,取单一的医生姓名,否则取用户列表
                if (!string.IsNullOrEmpty(sqlFilter.医生姓名))
                {
                    yhList=new List<T_YH>();
                    yhList.Add(new T_YH(){F_YHMC = sqlFilter.医生姓名});
                }
                else
                {
                    yhList = T_YH_DAL.GetList("");
                }

                var dtCg = CommonDAL.GetTableBySql(sqlCg+sqlWhereCg);
                var dtQc = CommonDAL.GetTableBySql(sqlQC + sqlWhereQc + sqlGroupQc);

                var dtCgEnumerable = dtCg.Rows.Cast<DataRow>().ToList();
                var dtQcEnumerable = dtQc.Rows.Cast<DataRow>().ToList();

                foreach (T_YH yh in yhList)
                {
                    DataEntity entity = new DataEntity();
                    entity.医生姓名 = yh.F_YHMC;
                    entity.常规初诊 = dtCgEnumerable.Count(dr => dr["bgys"].ToString().Contains(yh.F_YHMC));
                    entity.常规复诊 = dtCgEnumerable.Count(dr => dr["fzys"].ToString().Contains(yh.F_YHMC) && dr["bgys"].ToString().Contains(yh.F_YHMC)==false);
                    object lishu = dtQcEnumerable.SingleOrDefault(dr => dr["qcys"].ToString() == yh.F_YHMC)?["lishu"];
                    if (lishu != null)
                        entity.取材_例 = (int) lishu;
                    object heshu = dtQcEnumerable.SingleOrDefault(dr => dr["qcys"].ToString() == yh.F_YHMC)?["heshu"];
                    if (heshu != null)
                        entity.取材_盒 = (int)heshu;

                    if (entity.常规初诊 + entity.常规复诊 + entity.取材_例 + entity.取材_盒 > 0)
                        dataEntities.Add(entity);
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

            if (dataEntities.Any() == false)
                XtraMessageBox.Show("没有找到任何结果!");
            tJCXXBindingSource.DataSource = dataEntities;
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

        public class DataEntity
        {
            public string 医生姓名 { get; set; }
            public int 取材_例 { get; set; }
            public int 取材_盒 { get; set; }
            public int 常规初诊 { get; set; }
            public int 常规复诊 { get; set; }

        }
    }
}