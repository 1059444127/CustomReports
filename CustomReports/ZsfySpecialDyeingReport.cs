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
                    sqlWhere += $" and CONVERT(datetime,f_sdrq) <=CONVERT(datetime,'{sqlFilter.Sdrq2.Value.Date.AddDays(1)}') ";
                }

                StringBuilder sb = new StringBuilder();
                sb.Append("select ");
                sb.Append("count(*) as 总例数,");
                sb.Append("sum(case when t.f_tbszd like '%无上皮内病变或恶性病变%' then 1 else 0 end ) as NILM,");
                sb.Append("sum(case when (f_tbszd like '%意义不明确的非典型性鳞状细胞%') and (f_tbszd <>'%高级别%') then 1 else 0 end ) as \"ASC-US\",");
                sb.Append("sum(case when (f_tbszd like '%意义不明确的非典型性鳞状细胞%') and (f_tbszd LIKE '%高级别%') then 1 else 0 end ) as \"ASC-H\",");
                sb.Append("sum(case when (f_tbszd like '%低级别鳞状上皮内病变细胞%') and (f_tbszd <>'%不除外%') then 1 else 0 end ) as LSIL,");
                sb.Append("sum(case when (f_tbszd like '%高级别鳞状上皮内病变细胞%') and (f_tbszd <>'%不除外%') then 1 else 0 end ) as HSIL,");
                sb.Append("sum(case when (f_tbszd like '%鳞状细胞癌%') and (f_tbszd  like '%浸润性%') then 1 else 0 end ) as \"Invasive SCC\",");
                sb.Append("sum(case when f_tbszd like '%非典型腺细胞%' then 1 else 0 end ) as AGC,");
                sb.Append("sum(case when f_tbszd like '%可疑腺癌%' then 1 else 0 end ) as 可疑腺癌,");
                sb.Append("sum(case when (f_tbszd like '%腺癌%')  AND (f_tbszd <> '%不排除%') then 1 else 0 end ) as 腺癌,");

                sb.Append("sum(case when f_tbs_yzcd = '<50%' then 1 else 0 end ) as 轻度炎症,");
                sb.Append("sum(case when f_tbs_yzcd = '50-75%' then 1 else 0 end ) as 中度炎症,");
                sb.Append("sum(case when f_tbs_yzcd = '>75%' then 1 else 0 end ) as 高度炎症,");
                sb.Append("sum(case when F_TBS_BDXM2 LIKE '%有%' then 1 else 0 end ) as 念珠菌感染,");
                sb.Append("sum(case when F_TBS_WSW2 LIKE '%有%' then 1 else 0 end ) as 滴虫感染,");
                sb.Append("sum(case when (f_tbszd like '%细菌性阴道病%')  AND (f_tbszd <> '%不排除%') then 1 else 0 end ) as \"细菌菌群失调，提示细菌性阴道病\",");
                sb.Append("sum(case when (F_TBS_BDXM1 LIKE '%有%') then 1 else 0 end ) as 疱疹感染,");
                sb.Append("sum(case when (F_TBS_BBMYD ='满意') then 1 else 0 end ) as \"标本质量-满意\",");
                sb.Append("sum(case when (F_TBS_BBMYD like '%满意%') and (F_TBS_BBMYD like '%但%') then 1 else 0 end ) as \"标本质量-满意,但是\",");
                sb.Append("sum(case when (F_TBS_BBMYD ='不满意') then 1 else 0 end ) as \"标本质量-不满意\",");

                sb.Append("sum(case when (F_TBS_BBMYD ='无宫颈腺上皮细胞') then 1 else 0 end ) as \"标本质量-无宫颈腺上皮细胞\",");
                sb.Append("sum(case when (F_TBS_BBMYD ='鳞状上皮细胞过少') then 1 else 0 end ) as \"标本质量-鳞状上皮细胞过少\",");
                sb.Append("sum(case when (F_TBS_BBMYD ='炎性渗出') then 1 else 0 end ) as \"标本质量-炎性渗出\",");
                sb.Append("sum(case when (F_TBS_BBMYD ='血液覆盖')  then 1 else 0 end ) as \"标本质量-血液覆盖\",");
                sb.Append("sum(case when (F_TBS_BBMYD ='抹片过厚或人工假象')  then 1 else 0 end ) as \"标本质量-抹片过厚或人工假象\",");
                sb.Append("sum(case when (F_TBS_BDXM3 LIKE '%有%') then 1 else 0 end ) as \"线索细胞感染-有\",");
                sb.Append("sum(case when  (F_TBS_BDXM3 LIKE '%无%') then 1 else 0 end ) as \"线索细胞感染-无\",");
                sb.Append("sum(case when  (F_TBS_WSW3 LIKE '%有%') then 1 else 0 end ) as \"HPV感染提示：有\",");
                sb.Append("sum(case when  (F_TBS_WSW3 LIKE '%无%') then 1 else 0 end ) as \"HPV感染提示：无\",");
                sb.Append("sum(case when  (F_TBS_XBXM1 LIKE '%有%') then 1 else 0 end ) as \"颈管细胞：有\",");

                sb.Append("sum(case when (F_TBS_XBXM1 LIKE '%无%')  then 1 else 0 end ) as \"颈管细胞：无\",");
                sb.Append("sum(case when  (F_TBS_XBXM2 LIKE '%有%') then 1 else 0 end ) as \"化生细胞：有\",");
                sb.Append("sum(case when (F_TBS_XBXM2 LIKE '%无%')  then 1 else 0 end ) as \"化生细胞：无\",");
                sb.Append("sum(case when  (f_tbs_yzcd = '<50%')  then 1 else 0 end ) as \"炎症细胞覆盖面积<50%\",");
                sb.Append("sum(case when  (f_tbs_yzcd = '50-75%')  then 1 else 0 end ) as \"炎症细胞覆盖面积50-75%\",");
                sb.Append("sum(case when  (f_tbs_yzcd = '>75%')  then 1 else 0 end ) as \"炎症细胞覆盖面积>75%\"");

                sb.Append("from t_jcxx j inner join T_TBS_BG t on j.f_blh=t.F_BLH where j.f_blk='宫颈液基' ");
                sb.Append(" and " + sqlWhere);

                var dt1 = CommonDAL.GetTableBySql(sb.ToString());
                if (dt1.Rows.Count == 0)
                {
                    XtraMessageBox.Show("没有找到任何结果!");
                    return;
                }

                //查询结果为空时,填充0
                foreach (DataColumn dt1Column in dt1.Columns)
                {
                    if (dt1.Rows[0][dt1Column].ToString() == "")
                    {
                        dt1.Rows[0][dt1Column] = 0;
                    }
                }

                //处理数据
                dtResult.Columns.Add("统计项目");
                dtResult.Columns.Add("数量", typeof(Int32));
                dtResult.Columns.Add("百分比");
                var drSource = dt1.Rows[0];
                var totalCount = Convert.ToInt32(drSource["总例数"]);

                foreach (DataColumn dcSource in dt1.Columns)
                {
                    var drReport = dtResult.NewRow();
                    dtResult.Rows.Add(drReport);

                    drReport["统计项目"] = dcSource.ColumnName;
                    var count = Convert.ToInt32(drSource[dcSource.ColumnName]);
                    drReport["数量"] = count;
                    drReport["百分比"] = ((double) count*100 / (double) (totalCount==0?1:totalCount)).ToString("F1") + "%";
                }

                //增加"其它"项
                var drOthers = dtResult.NewRow();
                dtResult.Rows.InsertAt(drOthers,10);
                var otherCount = totalCount;
                string[] delColumn = new[] { "NILM", "ASC-US", "ASC-H", "LSIL", "HSIL", "Invasive SCC", "AGC", "可疑腺癌", "腺癌" };
                foreach (string colName in delColumn)
                {
                    otherCount -= Convert.ToInt32(dt1.Rows[0][colName]);
                }
                drOthers["统计项目"] = "其他";
                drOthers["数量"] = otherCount;
                drOthers["百分比"] = ((double)otherCount*100 / (double)(totalCount == 0 ? 1 : totalCount)).ToString("F1") + "%";
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