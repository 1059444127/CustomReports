using CustomReports.Model;

namespace CustomReports
{
    partial class ZszlExceptionReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.PathLibImageComboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.sqlFilterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BgztImageComboBoxEdit = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.Sdrq1DateEdit = new DevExpress.XtraEditors.DateEdit();
            this.Sdrq2DateEdit = new DevExpress.XtraEditors.DateEdit();
            this.XmflComboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForPathLib = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForSdrq1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForSdrq2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.ItemForBgzt = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForXmfl = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.tJCXXBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colF_BLH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colF_XM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colF_XB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colF_NL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colF_YZXM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colF_ZYH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colF_BGYS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colF_FZYS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col异常备注 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colF_BGRQ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colF_BGZT = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PathLibImageComboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlFilterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BgztImageComboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sdrq1DateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sdrq1DateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sdrq2DateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sdrq2DateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XmflComboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPathLib)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSdrq1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSdrq2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForBgzt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForXmfl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tJCXXBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(1);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.dataLayoutControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(827, 464);
            this.splitContainerControl1.SplitterPosition = 221;
            this.splitContainerControl1.TabIndex = 5;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.PathLibImageComboBoxEdit);
            this.dataLayoutControl1.Controls.Add(this.BgztImageComboBoxEdit);
            this.dataLayoutControl1.Controls.Add(this.Sdrq1DateEdit);
            this.dataLayoutControl1.Controls.Add(this.Sdrq2DateEdit);
            this.dataLayoutControl1.Controls.Add(this.XmflComboBoxEdit);
            this.dataLayoutControl1.DataSource = this.sqlFilterBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Margin = new System.Windows.Forms.Padding(1);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(221, 464);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // PathLibImageComboBoxEdit
            // 
            this.PathLibImageComboBoxEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.sqlFilterBindingSource, "Blk", true));
            this.PathLibImageComboBoxEdit.EditValue = "全部";
            this.PathLibImageComboBoxEdit.Location = new System.Drawing.Point(75, 12);
            this.PathLibImageComboBoxEdit.Margin = new System.Windows.Forms.Padding(1);
            this.PathLibImageComboBoxEdit.Name = "PathLibImageComboBoxEdit";
            this.PathLibImageComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.PathLibImageComboBoxEdit.Properties.Items.AddRange(new object[] {
            "全部"});
            this.PathLibImageComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.PathLibImageComboBoxEdit.Properties.UseCtrlScroll = true;
            this.PathLibImageComboBoxEdit.Size = new System.Drawing.Size(134, 20);
            this.PathLibImageComboBoxEdit.StyleController = this.dataLayoutControl1;
            this.PathLibImageComboBoxEdit.TabIndex = 4;
            // 
            // sqlFilterBindingSource
            // 
            this.sqlFilterBindingSource.DataSource = typeof(CustomReports.Model.SqlFilter);
            // 
            // BgztImageComboBoxEdit
            // 
            this.BgztImageComboBoxEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.sqlFilterBindingSource, "Bgzt", true));
            this.BgztImageComboBoxEdit.Location = new System.Drawing.Point(75, 36);
            this.BgztImageComboBoxEdit.Name = "BgztImageComboBoxEdit";
            this.BgztImageComboBoxEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.BgztImageComboBoxEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.BgztImageComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.BgztImageComboBoxEdit.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("全部", CustomReports.Bgzts.全部, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("已登记", CustomReports.Bgzts.已登记, 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("已写报告", CustomReports.Bgzts.已写报告, 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("已审核", CustomReports.Bgzts.已审核, 3)});
            this.BgztImageComboBoxEdit.Properties.UseCtrlScroll = true;
            this.BgztImageComboBoxEdit.Size = new System.Drawing.Size(134, 20);
            this.BgztImageComboBoxEdit.StyleController = this.dataLayoutControl1;
            this.BgztImageComboBoxEdit.TabIndex = 8;
            // 
            // Sdrq1DateEdit
            // 
            this.Sdrq1DateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.sqlFilterBindingSource, "Sdrq1", true));
            this.Sdrq1DateEdit.EditValue = null;
            this.Sdrq1DateEdit.Location = new System.Drawing.Point(75, 84);
            this.Sdrq1DateEdit.Name = "Sdrq1DateEdit";
            this.Sdrq1DateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.Sdrq1DateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Sdrq1DateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Sdrq1DateEdit.Size = new System.Drawing.Size(134, 20);
            this.Sdrq1DateEdit.StyleController = this.dataLayoutControl1;
            this.Sdrq1DateEdit.TabIndex = 9;
            // 
            // Sdrq2DateEdit
            // 
            this.Sdrq2DateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.sqlFilterBindingSource, "Sdrq2", true));
            this.Sdrq2DateEdit.EditValue = null;
            this.Sdrq2DateEdit.Location = new System.Drawing.Point(75, 108);
            this.Sdrq2DateEdit.Name = "Sdrq2DateEdit";
            this.Sdrq2DateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.Sdrq2DateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Sdrq2DateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Sdrq2DateEdit.Size = new System.Drawing.Size(134, 20);
            this.Sdrq2DateEdit.StyleController = this.dataLayoutControl1;
            this.Sdrq2DateEdit.TabIndex = 10;
            // 
            // XmflComboBoxEdit
            // 
            this.XmflComboBoxEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.sqlFilterBindingSource, "Xmfl", true));
            this.XmflComboBoxEdit.Location = new System.Drawing.Point(75, 60);
            this.XmflComboBoxEdit.Name = "XmflComboBoxEdit";
            this.XmflComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.XmflComboBoxEdit.Size = new System.Drawing.Size(134, 20);
            this.XmflComboBoxEdit.StyleController = this.dataLayoutControl1;
            this.XmflComboBoxEdit.TabIndex = 11;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 8;
            this.layoutControlGroup1.Size = new System.Drawing.Size(221, 464);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForPathLib,
            this.ItemForSdrq1,
            this.ItemForSdrq2,
            this.emptySpaceItem1,
            this.ItemForBgzt,
            this.ItemForXmfl});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.OptionsItemText.TextToControlDistance = 8;
            this.layoutControlGroup2.Size = new System.Drawing.Size(201, 444);
            // 
            // ItemForPathLib
            // 
            this.ItemForPathLib.Control = this.PathLibImageComboBoxEdit;
            this.ItemForPathLib.Location = new System.Drawing.Point(0, 0);
            this.ItemForPathLib.Name = "ItemForPathLib";
            this.ItemForPathLib.Size = new System.Drawing.Size(201, 24);
            this.ItemForPathLib.Text = "病理库";
            this.ItemForPathLib.TextSize = new System.Drawing.Size(55, 14);
            // 
            // ItemForSdrq1
            // 
            this.ItemForSdrq1.Control = this.Sdrq1DateEdit;
            this.ItemForSdrq1.Location = new System.Drawing.Point(0, 72);
            this.ItemForSdrq1.Name = "ItemForSdrq1";
            this.ItemForSdrq1.Size = new System.Drawing.Size(201, 24);
            this.ItemForSdrq1.Text = "收到日期1";
            this.ItemForSdrq1.TextSize = new System.Drawing.Size(55, 14);
            // 
            // ItemForSdrq2
            // 
            this.ItemForSdrq2.Control = this.Sdrq2DateEdit;
            this.ItemForSdrq2.Location = new System.Drawing.Point(0, 96);
            this.ItemForSdrq2.Name = "ItemForSdrq2";
            this.ItemForSdrq2.Size = new System.Drawing.Size(201, 24);
            this.ItemForSdrq2.Text = "收到日期2";
            this.ItemForSdrq2.TextSize = new System.Drawing.Size(55, 14);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 120);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(201, 324);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // ItemForBgzt
            // 
            this.ItemForBgzt.Control = this.BgztImageComboBoxEdit;
            this.ItemForBgzt.Location = new System.Drawing.Point(0, 24);
            this.ItemForBgzt.Name = "ItemForBgzt";
            this.ItemForBgzt.Size = new System.Drawing.Size(201, 24);
            this.ItemForBgzt.Text = "报告状态";
            this.ItemForBgzt.TextSize = new System.Drawing.Size(55, 14);
            // 
            // ItemForXmfl
            // 
            this.ItemForXmfl.Control = this.XmflComboBoxEdit;
            this.ItemForXmfl.Location = new System.Drawing.Point(0, 48);
            this.ItemForXmfl.Name = "ItemForXmfl";
            this.ItemForXmfl.Size = new System.Drawing.Size(201, 24);
            this.ItemForXmfl.Text = "项目分类";
            this.ItemForXmfl.TextSize = new System.Drawing.Size(55, 14);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.tJCXXBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(1);
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(1);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(601, 464);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // tJCXXBindingSource
            // 
            this.tJCXXBindingSource.DataSource = typeof(CustomReports.Model.T_JCXX);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colF_BLH,
            this.colF_XM,
            this.colF_XB,
            this.colF_NL,
            this.colF_YZXM,
            this.colF_ZYH,
            this.colF_BGYS,
            this.colF_FZYS,
            this.col异常备注,
            this.colF_BGRQ,
            this.colF_BGZT});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "F_BLH", null, "合计:{0}")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupedColumns = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colF_BLH
            // 
            this.colF_BLH.Caption = "分子编号";
            this.colF_BLH.FieldName = "F_BLH";
            this.colF_BLH.Name = "colF_BLH";
            this.colF_BLH.Visible = true;
            this.colF_BLH.VisibleIndex = 0;
            // 
            // colF_XM
            // 
            this.colF_XM.Caption = "姓名";
            this.colF_XM.FieldName = "F_XM";
            this.colF_XM.Name = "colF_XM";
            this.colF_XM.Visible = true;
            this.colF_XM.VisibleIndex = 1;
            // 
            // colF_XB
            // 
            this.colF_XB.Caption = "性别";
            this.colF_XB.FieldName = "F_XB";
            this.colF_XB.Name = "colF_XB";
            this.colF_XB.Visible = true;
            this.colF_XB.VisibleIndex = 2;
            // 
            // colF_NL
            // 
            this.colF_NL.Caption = "年龄";
            this.colF_NL.FieldName = "F_NL";
            this.colF_NL.Name = "colF_NL";
            this.colF_NL.Visible = true;
            this.colF_NL.VisibleIndex = 3;
            // 
            // colF_YZXM
            // 
            this.colF_YZXM.Caption = "检测项目";
            this.colF_YZXM.FieldName = "F_YZXM";
            this.colF_YZXM.Name = "colF_YZXM";
            this.colF_YZXM.Visible = true;
            this.colF_YZXM.VisibleIndex = 4;
            // 
            // colF_ZYH
            // 
            this.colF_ZYH.Caption = "病历号";
            this.colF_ZYH.FieldName = "病历号";
            this.colF_ZYH.Name = "colF_ZYH";
            this.colF_ZYH.Visible = true;
            this.colF_ZYH.VisibleIndex = 5;
            // 
            // colF_BGYS
            // 
            this.colF_BGYS.Caption = "报告医生";
            this.colF_BGYS.FieldName = "F_BGYS";
            this.colF_BGYS.Name = "colF_BGYS";
            this.colF_BGYS.Visible = true;
            this.colF_BGYS.VisibleIndex = 6;
            // 
            // colF_FZYS
            // 
            this.colF_FZYS.Caption = "检测者";
            this.colF_FZYS.FieldName = "F_FZYS";
            this.colF_FZYS.Name = "colF_FZYS";
            this.colF_FZYS.Visible = true;
            this.colF_FZYS.VisibleIndex = 7;
            // 
            // col异常备注
            // 
            this.col异常备注.Caption = "备注";
            this.col异常备注.FieldName = "异常备注";
            this.col异常备注.Name = "col异常备注";
            this.col异常备注.Visible = true;
            this.col异常备注.VisibleIndex = 10;
            // 
            // colF_BGRQ
            // 
            this.colF_BGRQ.Caption = "报告日期";
            this.colF_BGRQ.FieldName = "F_BGRQ";
            this.colF_BGRQ.Name = "colF_BGRQ";
            this.colF_BGRQ.Visible = true;
            this.colF_BGRQ.VisibleIndex = 8;
            // 
            // colF_BGZT
            // 
            this.colF_BGZT.Caption = "报告状态";
            this.colF_BGZT.FieldName = "F_BGZT";
            this.colF_BGZT.Name = "colF_BGZT";
            this.colF_BGZT.Visible = true;
            this.colF_BGZT.VisibleIndex = 9;
            // 
            // ZszlExceptionReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "ZszlExceptionReport";
            this.Size = new System.Drawing.Size(827, 464);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PathLibImageComboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlFilterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BgztImageComboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sdrq1DateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sdrq1DateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sdrq2DateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sdrq2DateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XmflComboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPathLib)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSdrq1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSdrq2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForBgzt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForXmfl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tJCXXBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private System.Windows.Forms.BindingSource sqlFilterBindingSource;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPathLib;
        private System.Windows.Forms.BindingSource tJCXXBindingSource;
        private DevExpress.XtraEditors.ComboBoxEdit PathLibImageComboBoxEdit;
        private DevExpress.XtraEditors.ImageComboBoxEdit BgztImageComboBoxEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForBgzt;
        private DevExpress.XtraEditors.DateEdit Sdrq1DateEdit;
        private DevExpress.XtraEditors.DateEdit Sdrq2DateEdit;
        private DevExpress.XtraEditors.ComboBoxEdit XmflComboBoxEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSdrq1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSdrq2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForXmfl;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colF_BLH;
        private DevExpress.XtraGrid.Columns.GridColumn colF_XM;
        private DevExpress.XtraGrid.Columns.GridColumn colF_XB;
        private DevExpress.XtraGrid.Columns.GridColumn colF_NL;
        private DevExpress.XtraGrid.Columns.GridColumn colF_YZXM;
        private DevExpress.XtraGrid.Columns.GridColumn colF_ZYH;
        private DevExpress.XtraGrid.Columns.GridColumn colF_BGYS;
        private DevExpress.XtraGrid.Columns.GridColumn colF_FZYS;
        private DevExpress.XtraGrid.Columns.GridColumn colF_BGRQ;
        private DevExpress.XtraGrid.Columns.GridColumn colF_BGZT;
        private DevExpress.XtraGrid.Columns.GridColumn col异常备注;
    }
}