
namespace ExcelAddIn1
{
    partial class Main
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
            this.csvOpenFileInfo = new System.Windows.Forms.Label();
            this.openBtn = new System.Windows.Forms.Button();
            this.doRemoveBtn = new System.Windows.Forms.Button();
            this.filterListBox = new System.Windows.Forms.ListBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.RemoveBtn = new System.Windows.Forms.Button();
            this.loadFiltersBtn = new System.Windows.Forms.Button();
            this.saveFiltersBtn = new System.Windows.Forms.Button();
            this.mergeOutputChkBox = new System.Windows.Forms.CheckBox();
            this.mergeOutputBtn = new System.Windows.Forms.Button();
            this.mergeOutputLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // csvOpenFileInfo
            // 
            this.csvOpenFileInfo.AutoSize = true;
            this.csvOpenFileInfo.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.csvOpenFileInfo.Location = new System.Drawing.Point(93, 17);
            this.csvOpenFileInfo.Name = "csvOpenFileInfo";
            this.csvOpenFileInfo.Size = new System.Drawing.Size(92, 14);
            this.csvOpenFileInfo.TabIndex = 0;
            this.csvOpenFileInfo.Text = "CSV file to open...";
            // 
            // openBtn
            // 
            this.openBtn.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openBtn.Location = new System.Drawing.Point(12, 12);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(75, 23);
            this.openBtn.TabIndex = 1;
            this.openBtn.Text = "Select file...";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // doRemoveBtn
            // 
            this.doRemoveBtn.Enabled = false;
            this.doRemoveBtn.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doRemoveBtn.Location = new System.Drawing.Point(12, 285);
            this.doRemoveBtn.Name = "doRemoveBtn";
            this.doRemoveBtn.Size = new System.Drawing.Size(172, 23);
            this.doRemoveBtn.TabIndex = 9;
            this.doRemoveBtn.Text = "Process CSV";
            this.doRemoveBtn.UseVisualStyleBackColor = true;
            this.doRemoveBtn.Click += new System.EventHandler(this.doRemoveBtn_Click);
            // 
            // filterListBox
            // 
            this.filterListBox.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterListBox.FormattingEnabled = true;
            this.filterListBox.ItemHeight = 14;
            this.filterListBox.Location = new System.Drawing.Point(205, 109);
            this.filterListBox.Name = "filterListBox";
            this.filterListBox.Size = new System.Drawing.Size(290, 200);
            this.filterListBox.TabIndex = 5;
            this.filterListBox.SelectedIndexChanged += new System.EventHandler(this.filterListBox_SelectedIndexChanged);
            // 
            // addBtn
            // 
            this.addBtn.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtn.Location = new System.Drawing.Point(12, 184);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(172, 23);
            this.addBtn.TabIndex = 6;
            this.addBtn.Text = "Add new filter";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editBtn.Location = new System.Drawing.Point(12, 213);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(172, 23);
            this.editBtn.TabIndex = 7;
            this.editBtn.Text = "Edit selection";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // RemoveBtn
            // 
            this.RemoveBtn.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveBtn.Location = new System.Drawing.Point(12, 242);
            this.RemoveBtn.Name = "RemoveBtn";
            this.RemoveBtn.Size = new System.Drawing.Size(172, 23);
            this.RemoveBtn.TabIndex = 8;
            this.RemoveBtn.Text = "Remove selection";
            this.RemoveBtn.UseVisualStyleBackColor = true;
            this.RemoveBtn.Click += new System.EventHandler(this.RemoveBtn_Click);
            // 
            // loadFiltersBtn
            // 
            this.loadFiltersBtn.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadFiltersBtn.Location = new System.Drawing.Point(13, 109);
            this.loadFiltersBtn.Name = "loadFiltersBtn";
            this.loadFiltersBtn.Size = new System.Drawing.Size(172, 23);
            this.loadFiltersBtn.TabIndex = 3;
            this.loadFiltersBtn.Text = "Load filter list";
            this.loadFiltersBtn.UseVisualStyleBackColor = true;
            this.loadFiltersBtn.Click += new System.EventHandler(this.loadFiltersBtn_Click);
            // 
            // saveFiltersBtn
            // 
            this.saveFiltersBtn.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveFiltersBtn.Location = new System.Drawing.Point(12, 138);
            this.saveFiltersBtn.Name = "saveFiltersBtn";
            this.saveFiltersBtn.Size = new System.Drawing.Size(172, 23);
            this.saveFiltersBtn.TabIndex = 4;
            this.saveFiltersBtn.Text = "Save filter list";
            this.saveFiltersBtn.UseVisualStyleBackColor = true;
            this.saveFiltersBtn.Click += new System.EventHandler(this.saveFiltersBtn_Click);
            // 
            // mergeOutputChkBox
            // 
            this.mergeOutputChkBox.AutoSize = true;
            this.mergeOutputChkBox.Enabled = false;
            this.mergeOutputChkBox.Location = new System.Drawing.Point(13, 41);
            this.mergeOutputChkBox.Name = "mergeOutputChkBox";
            this.mergeOutputChkBox.Size = new System.Drawing.Size(470, 17);
            this.mergeOutputChkBox.TabIndex = 1;
            this.mergeOutputChkBox.Text = "Merge filters after filtering. NOTE: Verify filters produce unique results or dup" +
    "licates will happen!";
            this.mergeOutputChkBox.UseVisualStyleBackColor = true;
            this.mergeOutputChkBox.CheckedChanged += new System.EventHandler(this.mergeOutputChkBox_CheckedChanged);
            // 
            // mergeOutputBtn
            // 
            this.mergeOutputBtn.Enabled = false;
            this.mergeOutputBtn.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mergeOutputBtn.Location = new System.Drawing.Point(12, 64);
            this.mergeOutputBtn.Name = "mergeOutputBtn";
            this.mergeOutputBtn.Size = new System.Drawing.Size(75, 23);
            this.mergeOutputBtn.TabIndex = 2;
            this.mergeOutputBtn.Text = "Select file...";
            this.mergeOutputBtn.UseVisualStyleBackColor = true;
            this.mergeOutputBtn.Visible = false;
            this.mergeOutputBtn.Click += new System.EventHandler(this.mergeOutputBtn_Click);
            // 
            // mergeOutputLbl
            // 
            this.mergeOutputLbl.AutoSize = true;
            this.mergeOutputLbl.Enabled = false;
            this.mergeOutputLbl.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mergeOutputLbl.Location = new System.Drawing.Point(93, 69);
            this.mergeOutputLbl.Name = "mergeOutputLbl";
            this.mergeOutputLbl.Size = new System.Drawing.Size(91, 14);
            this.mergeOutputLbl.TabIndex = 12;
            this.mergeOutputLbl.Text = "Merge output to...";
            this.mergeOutputLbl.Visible = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 321);
            this.Controls.Add(this.mergeOutputBtn);
            this.Controls.Add(this.mergeOutputLbl);
            this.Controls.Add(this.mergeOutputChkBox);
            this.Controls.Add(this.loadFiltersBtn);
            this.Controls.Add(this.saveFiltersBtn);
            this.Controls.Add(this.RemoveBtn);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.filterListBox);
            this.Controls.Add(this.doRemoveBtn);
            this.Controls.Add(this.openBtn);
            this.Controls.Add(this.csvOpenFileInfo);
            this.Name = "Main";
            this.Text = "CSV Line Filtering Utility";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label csvOpenFileInfo;
        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.Button doRemoveBtn;
        private System.Windows.Forms.ListBox filterListBox;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button RemoveBtn;
        private System.Windows.Forms.Button loadFiltersBtn;
        private System.Windows.Forms.Button saveFiltersBtn;
        private System.Windows.Forms.CheckBox mergeOutputChkBox;
        private System.Windows.Forms.Button mergeOutputBtn;
        private System.Windows.Forms.Label mergeOutputLbl;
    }
}

