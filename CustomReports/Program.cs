using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CustomReports
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            var paramList = args[0].Split('|');
            var reportName = paramList[0];
            var hspName = paramList[1];

            if (string.IsNullOrEmpty(reportName))
            {
                MessageBox.Show("没有指定报告名称,无法打开报表!");
                Application.Exit();
            }
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var main = new Main();
            main.ReportName = reportName;
            main.HspName = hspName;
            main.InitReportControl();
            Application.Run(main);
        }
    }
}
