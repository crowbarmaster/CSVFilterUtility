
namespace ExcelAddIn1
{
    partial class AddFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFilter));
            this.label1 = new System.Windows.Forms.Label();
            this.rangeMinMatchLbl = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.rangeMaxLbl = new System.Windows.Forms.Label();
            this.matchBox = new System.Windows.Forms.TextBox();
            this.rangeMaxBox = new System.Windows.Forms.TextBox();
            this.columnLbl = new System.Windows.Forms.Label();
            this.columnBox = new System.Windows.Forms.TextBox();
            this.filterEditLbl = new System.Windows.Forms.Label();
            this.filterEditColBox = new System.Windows.Forms.TextBox();
            this.filterEditNewValueLbl = new System.Windows.Forms.Label();
            this.filterEditValBox = new System.Windows.Forms.TextBox();
            this.saveAllChkBox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.editHeaderNameBox = new System.Windows.Forms.TextBox();
            this.editHeaderNameLbl = new System.Windows.Forms.Label();
            this.filterInputDropBox = new System.Windows.Forms.ComboBox();
            this.filterOpDropBox = new System.Windows.Forms.ComboBox();
            this.filterEditDropBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Searched value is:";
            // 
            // rangeMinMatchLbl
            // 
            this.rangeMinMatchLbl.AutoSize = true;
            this.rangeMinMatchLbl.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rangeMinMatchLbl.Location = new System.Drawing.Point(12, 108);
            this.rangeMinMatchLbl.Name = "rangeMinMatchLbl";
            this.rangeMinMatchLbl.Size = new System.Drawing.Size(82, 14);
            this.rangeMinMatchLbl.TabIndex = 3;
            this.rangeMinMatchLbl.Text = "Minimum value:";
            // 
            // saveBtn
            // 
            this.saveBtn.Enabled = false;
            this.saveBtn.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Location = new System.Drawing.Point(12, 328);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(217, 28);
            this.saveBtn.TabIndex = 10;
            this.saveBtn.Text = "Save Filter";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // rangeMaxLbl
            // 
            this.rangeMaxLbl.AutoSize = true;
            this.rangeMaxLbl.Enabled = false;
            this.rangeMaxLbl.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rangeMaxLbl.Location = new System.Drawing.Point(9, 132);
            this.rangeMaxLbl.Name = "rangeMaxLbl";
            this.rangeMaxLbl.Size = new System.Drawing.Size(84, 14);
            this.rangeMaxLbl.TabIndex = 5;
            this.rangeMaxLbl.Text = "Maximum value:";
            this.rangeMaxLbl.Visible = false;
            // 
            // matchBox
            // 
            this.matchBox.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matchBox.Location = new System.Drawing.Point(94, 104);
            this.matchBox.Name = "matchBox";
            this.matchBox.Size = new System.Drawing.Size(136, 20);
            this.matchBox.TabIndex = 2;
            this.matchBox.TextChanged += new System.EventHandler(this.rangeMinMatchBox_TextChanged);
            // 
            // rangeMaxBox
            // 
            this.rangeMaxBox.Enabled = false;
            this.rangeMaxBox.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rangeMaxBox.Location = new System.Drawing.Point(94, 129);
            this.rangeMaxBox.Name = "rangeMaxBox";
            this.rangeMaxBox.Size = new System.Drawing.Size(136, 20);
            this.rangeMaxBox.TabIndex = 3;
            this.rangeMaxBox.Visible = false;
            this.rangeMaxBox.TextChanged += new System.EventHandler(this.rangeMaxBox_TextChanged);
            // 
            // columnLbl
            // 
            this.columnLbl.AutoSize = true;
            this.columnLbl.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.columnLbl.Location = new System.Drawing.Point(16, 159);
            this.columnLbl.Name = "columnLbl";
            this.columnLbl.Size = new System.Drawing.Size(77, 14);
            this.columnLbl.TabIndex = 8;
            this.columnLbl.Text = "Search column:";
            // 
            // columnBox
            // 
            this.columnBox.Enabled = false;
            this.columnBox.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.columnBox.Location = new System.Drawing.Point(94, 156);
            this.columnBox.Name = "columnBox";
            this.columnBox.Size = new System.Drawing.Size(36, 20);
            this.columnBox.TabIndex = 4;
            this.columnBox.TextChanged += new System.EventHandler(this.columnBox_TextChanged);
            // 
            // filterEditLbl
            // 
            this.filterEditLbl.AutoSize = true;
            this.filterEditLbl.Location = new System.Drawing.Point(62, 247);
            this.filterEditLbl.Name = "filterEditLbl";
            this.filterEditLbl.Size = new System.Drawing.Size(125, 14);
            this.filterEditLbl.TabIndex = 11;
            this.filterEditLbl.Text = "Copy value from column:";
            // 
            // filterEditColBox
            // 
            this.filterEditColBox.Enabled = false;
            this.filterEditColBox.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterEditColBox.Location = new System.Drawing.Point(194, 244);
            this.filterEditColBox.Name = "filterEditColBox";
            this.filterEditColBox.Size = new System.Drawing.Size(36, 20);
            this.filterEditColBox.TabIndex = 7;
            this.filterEditColBox.TextChanged += new System.EventHandler(this.filterEditColBox_TextChanged);
            // 
            // filterEditNewValueLbl
            // 
            this.filterEditNewValueLbl.AutoSize = true;
            this.filterEditNewValueLbl.Location = new System.Drawing.Point(127, 273);
            this.filterEditNewValueLbl.Name = "filterEditNewValueLbl";
            this.filterEditNewValueLbl.Size = new System.Drawing.Size(60, 14);
            this.filterEditNewValueLbl.TabIndex = 14;
            this.filterEditNewValueLbl.Text = "To column:";
            // 
            // filterEditValBox
            // 
            this.filterEditValBox.Enabled = false;
            this.filterEditValBox.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterEditValBox.Location = new System.Drawing.Point(194, 270);
            this.filterEditValBox.Name = "filterEditValBox";
            this.filterEditValBox.Size = new System.Drawing.Size(36, 20);
            this.filterEditValBox.TabIndex = 8;
            this.filterEditValBox.TextChanged += new System.EventHandler(this.filterEditValBox_TextChanged);
            // 
            // saveAllChkBox
            // 
            this.saveAllChkBox.AutoSize = true;
            this.saveAllChkBox.Enabled = false;
            this.saveAllChkBox.Location = new System.Drawing.Point(75, 306);
            this.saveAllChkBox.Name = "saveAllChkBox";
            this.saveAllChkBox.Size = new System.Drawing.Size(85, 18);
            this.saveAllChkBox.TabIndex = 9;
            this.saveAllChkBox.Text = "Save all lines";
            this.saveAllChkBox.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Location = new System.Drawing.Point(4, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(231, 2);
            this.label7.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(4, 183);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(231, 2);
            this.label8.TabIndex = 28;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Location = new System.Drawing.Point(4, 300);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(231, 2);
            this.label9.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(4, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(231, 2);
            this.label6.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 15);
            this.label3.TabIndex = 30;
            this.label3.Text = "Filter input type:";
            // 
            // editHeaderNameBox
            // 
            this.editHeaderNameBox.Enabled = false;
            this.editHeaderNameBox.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editHeaderNameBox.Location = new System.Drawing.Point(119, 218);
            this.editHeaderNameBox.Name = "editHeaderNameBox";
            this.editHeaderNameBox.Size = new System.Drawing.Size(111, 20);
            this.editHeaderNameBox.TabIndex = 6;
            // 
            // editHeaderNameLbl
            // 
            this.editHeaderNameLbl.AutoSize = true;
            this.editHeaderNameLbl.Location = new System.Drawing.Point(42, 221);
            this.editHeaderNameLbl.Name = "editHeaderNameLbl";
            this.editHeaderNameLbl.Size = new System.Drawing.Size(70, 14);
            this.editHeaderNameLbl.TabIndex = 38;
            this.editHeaderNameLbl.Text = "Header name:";
            // 
            // filterInputDropBox
            // 
            this.filterInputDropBox.BackColor = System.Drawing.SystemColors.Window;
            this.filterInputDropBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterInputDropBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filterInputDropBox.FormattingEnabled = true;
            this.filterInputDropBox.Location = new System.Drawing.Point(94, 10);
            this.filterInputDropBox.Name = "filterInputDropBox";
            this.filterInputDropBox.Size = new System.Drawing.Size(136, 22);
            this.filterInputDropBox.TabIndex = 0;
            this.filterInputDropBox.SelectedIndexChanged += new System.EventHandler(this.filterInputDropBox_SelectedIndexChanged);
            this.filterInputDropBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FilterDropBox_KeyDown);
            // 
            // filterOpDropBox
            // 
            this.filterOpDropBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterOpDropBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filterOpDropBox.FormattingEnabled = true;
            this.filterOpDropBox.Location = new System.Drawing.Point(94, 56);
            this.filterOpDropBox.Name = "filterOpDropBox";
            this.filterOpDropBox.Size = new System.Drawing.Size(136, 22);
            this.filterOpDropBox.TabIndex = 1;
            this.filterOpDropBox.SelectedIndexChanged += new System.EventHandler(this.filterOpDropBox_SelectedIndexChanged);
            this.filterOpDropBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FilterDropBox_KeyDown);
            // 
            // filterEditDropBox
            // 
            this.filterEditDropBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterEditDropBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filterEditDropBox.FormattingEnabled = true;
            this.filterEditDropBox.ItemHeight = 14;
            this.filterEditDropBox.Location = new System.Drawing.Point(94, 190);
            this.filterEditDropBox.Name = "filterEditDropBox";
            this.filterEditDropBox.Size = new System.Drawing.Size(136, 22);
            this.filterEditDropBox.TabIndex = 5;
            this.filterEditDropBox.SelectedIndexChanged += new System.EventHandler(this.filterEditDropBox_SelectedIndexChanged);
            this.filterEditDropBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FilterDropBox_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 14);
            this.label4.TabIndex = 40;
            this.label4.Text = "Special functions:";
            // 
            // AddFilter
            // 
            this.AcceptButton = this.saveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(238, 362);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.filterEditDropBox);
            this.Controls.Add(this.filterOpDropBox);
            this.Controls.Add(this.filterInputDropBox);
            this.Controls.Add(this.editHeaderNameLbl);
            this.Controls.Add(this.editHeaderNameBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.saveAllChkBox);
            this.Controls.Add(this.filterEditValBox);
            this.Controls.Add(this.filterEditNewValueLbl);
            this.Controls.Add(this.filterEditColBox);
            this.Controls.Add(this.filterEditLbl);
            this.Controls.Add(this.columnBox);
            this.Controls.Add(this.columnLbl);
            this.Controls.Add(this.rangeMaxBox);
            this.Controls.Add(this.matchBox);
            this.Controls.Add(this.rangeMaxLbl);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.rangeMinMatchLbl);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddFilter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddFilter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label rangeMinMatchLbl;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label rangeMaxLbl;
        private System.Windows.Forms.TextBox matchBox;
        private System.Windows.Forms.TextBox rangeMaxBox;
        private System.Windows.Forms.Label columnLbl;
        private System.Windows.Forms.TextBox columnBox;
        private System.Windows.Forms.Label filterEditLbl;
        private System.Windows.Forms.TextBox filterEditColBox;
        private System.Windows.Forms.Label filterEditNewValueLbl;
        private System.Windows.Forms.TextBox filterEditValBox;
        private System.Windows.Forms.CheckBox saveAllChkBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox editHeaderNameBox;
        private System.Windows.Forms.Label editHeaderNameLbl;
        private System.Windows.Forms.ComboBox filterInputDropBox;
        private System.Windows.Forms.ComboBox filterOpDropBox;
        private System.Windows.Forms.ComboBox filterEditDropBox;
        private System.Windows.Forms.Label label4;
    }
}