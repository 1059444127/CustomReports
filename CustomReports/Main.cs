using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomReports.Model;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraReports;
using DevExpress.XtraSplashScreen;

namespace CustomReports
{
    /// <summary>
    /// 中山肿瘤附属医院分子病理报表
    /// 统计EBV,HBV进行过两次诊断的病人的两次结果值的差异
    /// </summary>
    public partial class Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public string ReportName { get; set; }
        public string HspName { get; set; }

        public IReport Report = null;
        public IGroupable GroupableReport = null;

        public Main()
        {
            InitializeComponent();

        }



        private void ZszlPCRReport_Load(object sender, EventArgs e)
        {

        }

        public void InitReportControl()
        {
            var assembly = this.GetType().GetAssembly();
            foreach (Type type in assembly.GetTypes())
            {
                var attr = type.GetCustomAttribute(typeof (ReportAttribute)) as ReportAttribute;
                if(attr==null)
                    continue;
                if (attr.ReportName == ReportName && attr.HspName == HspName)
                {
                    this.Text = ReportName;

                    Report = (IReport) assembly.CreateInstance(type.FullName);


                }
                else
                {
                    continue;
                }

                grpGroup.Visible = Report is IGroupable;
                GroupableReport = Report as IGroupable;

                Report.Control.Dock = DockStyle.Fill;
                panelControl1.Controls.Add(Report.Control);
            }

            if (Report == null)
                throw new Exception("没有找到报表:" + ReportName);
        }

        /// <summary>
        /// 导出为Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportWord_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            Report.Print();
        }

        private void btnSearch_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                SplashScreenManager.ShowDefaultWaitForm($"正在查询...");

                Report.Query();
            }
            finally
            {
                SplashScreenManager.CloseDefaultSplashScreen();
            }
        }


        private void btnExportExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            Report.ExportExcel();}

        private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void btnExpandAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            GroupableReport?.ExpandAll();
        }

        private void btnCollapseAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            GroupableReport?.CollapseAll();
        }
    }
}