using DevExpress.XtraEditors;

namespace CustomReports
{
    public interface IReport
    {
        void Query();

        void Print();

        void ExportExcel();

        XtraUserControl Control { get;  }
    }

    public interface IGroupable
    {
        void ExpandAll();
        void CollapseAll();
    }
}