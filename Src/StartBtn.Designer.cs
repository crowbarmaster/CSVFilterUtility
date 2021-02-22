
namespace ExcelAddIn1
{
    partial class StartBtn : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public StartBtn()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartBtn));
            this.tab1 = this.Factory.CreateRibbonTab();
            this.CSVTools = this.Factory.CreateRibbonGroup();
            this.ShowParser = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.CSVTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.ControlId.OfficeId = "TabData";
            this.tab1.Groups.Add(this.CSVTools);
            this.tab1.Label = "TabData";
            this.tab1.Name = "tab1";
            // 
            // CSVTools
            // 
            this.CSVTools.Items.Add(this.ShowParser);
            this.CSVTools.Label = "CSV Tools";
            this.CSVTools.Name = "CSVTools";
            // 
            // ShowParser
            // 
            this.ShowParser.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.ShowParser.Image = ((System.Drawing.Image)(resources.GetObject("ShowParser.Image")));
            this.ShowParser.Label = "Start CSV Filtering Utility";
            this.ShowParser.Name = "ShowParser";
            this.ShowParser.ShowImage = true;
            this.ShowParser.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ShowParser_Click);
            // 
            // StartBtn
            // 
            this.Name = "StartBtn";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.CSVTools.ResumeLayout(false);
            this.CSVTools.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup CSVTools;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ShowParser;
    }

    partial class ThisRibbonCollection
    {
        internal StartBtn Ribbon1
        {
            get { return this.GetRibbon<StartBtn>(); }
        }
    }
}
