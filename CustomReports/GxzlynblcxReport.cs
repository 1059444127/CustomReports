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

    //1、疑难病例查询
    //查询条件：收到日期（区间）、病例库（可以导出）
    //如：
    //常规工作量 补充工作量
    //初诊 复诊     初诊 复诊
    //医生A     2    3        1       2
    //医生B     3    4        3       4
    //医生C     5    1        5       1
    //计算方法：
    //常规工作量中的初诊：T_JCXX表中F_BZ或者 T_BC_BZ字段中 = '疑难病例'的时候f_bgys=的数

    //常规工作量中的复诊：T_JCXX表中F_BZ或者 T_BC_BZ字段中 = '疑难病例'的时候f_fzys like 的数(用like 因为f_fzys有可能同时会有几个人)  注：如果f_fzys中有f_bgys的人的时候，则不统计，因为f_bgys在初诊里已经统计过了，一个医生在一个常规病例中最多
    //统计两次工作量，常规1次，补充一次，不管出现几次名字。

    //补充工作量中的初诊：T_JCXX表中F_BZ或者 T_BC_BZ字段中 = '疑难病例'的时候f_bc_bgys=的数(不管有几份补充报告，只计算第一份补充报告。)

    //工作量中的复诊：T_JCXX表中F_BZ或者 T_BC_BZ字段中 = '疑难病例'的时候f_bc_fzys like 的数(用like 因为f_fzys有可能同时会有几个人)  注：如果f_bc_fzys中有f_bc_bgys的人的时候，则不统计，因为f_bc_bgys在初诊里已经统计过了(不管有几份补充报告，只计算第一份补充报告。)

    //注：可以通过收到日期（区间）、病例库以及f_bgys常用词来查询明细

    #endregion

    /// <summary>
    /// 广西肿瘤医院
    /// 疑难病例查询
    /// </summary>
    [Report("疑难病例查询", "广西肿瘤")]
    public partial class GxzlynblcxReport : XtraUserControl, IReport
    {
        public GxzlynblcxReport()
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
                string sqlBc =
                    "select f_bc_bgys bgys,F_BC_FZYS fzys from [dbo].[T_BCBG] bc inner join t_jcxx t on t.f_blh=bc.f_blh where F_BC_BZ like  '疑难病例' and F_BC_BGXH='1' ";
                string sqlWhereBc = "";
                string sqlWhereCg = "";

                if (sqlFilter.Blk != null && (sqlFilter.Blk != "全部" && sqlFilter.Blk != ""))
                {
                    sqlWhereCg += $" and t.f_blk='{sqlFilter.Blk}' ";
                    sqlWhereBc += $" and t.f_blk='{sqlFilter.Blk}' ";

                }

                if (sqlFilter.Sdrq1.HasValue)
                {
                    //收到日期
                    sqlWhereBc += $" and CONVERT(datetime,t.f_sdrq) >= CONVERT(datetime,'{sqlFilter.Sdrq1.Value.Date}') ";
                    sqlWhereCg += $" and CONVERT(datetime,t.f_sdrq) >= CONVERT(datetime,'{sqlFilter.Sdrq1.Value.Date}') ";
                }
                if (sqlFilter.Sdrq2.HasValue)
                {
                    sqlWhereBc += $" and CONVERT(datetime,t.f_sdrq) <=CONVERT(datetime,'{sqlFilter.Sdrq2.Value.Date.AddDays(1)}') ";
                    sqlWhereCg += $" and CONVERT(datetime,t.f_sdrq) <=CONVERT(datetime,'{sqlFilter.Sdrq2.Value.Date.AddDays(1)}') ";
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
                var dtBc = CommonDAL.GetTableBySql(sqlBc+sqlWhereBc);

                var dtCgEnumerable = dtCg.Rows.Cast<DataRow>().ToList();
                var dtBcEnumerable = dtBc.Rows.Cast<DataRow>().ToList();

                foreach (T_YH yh in yhList)
                {
                    DataEntity entity = new DataEntity();
                    entity.医生姓名 = yh.F_YHMC;
                    entity.常规初诊 = dtCgEnumerable.Count(dr => dr["bgys"].ToString().Contains(yh.F_YHMC));
                    entity.常规复诊 = dtCgEnumerable.Count(dr => dr["fzys"].ToString().Contains(yh.F_YHMC) && dr["bgys"].ToString().Contains(yh.F_YHMC)==false);
                    entity.补充初诊 = dtBcEnumerable.Count(dr => dr["bgys"].ToString().Contains(yh.F_YHMC));
                    entity.补充复诊 = dtBcEnumerable.Count(dr => dr["fzys"].ToString().Contains(yh.F_YHMC) && dr["bgys"].ToString().Contains(yh.F_YHMC) == false);

                    if (entity.常规初诊 + entity.常规复诊 + entity.补充初诊 + entity.补充复诊 > 0)
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
            public int 常规初诊 { get; set; }
            public int 常规复诊 { get; set; }
            public int 补充初诊 { get; set; }
            public int 补充复诊 { get; set; }
        }
    }
}