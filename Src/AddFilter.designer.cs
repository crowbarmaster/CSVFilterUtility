
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
            this.label1 = new System.Windows.Forms.Label();
            this.rangeMinMatchLbl = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.rangeMaxLbl = new System.Windows.Forms.Label();
            this.matchBox = new System.Windows.Forms.TextBox();
            this.rangeMaxBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.columnBox = new System.Windows.Forms.TextBox();
            this.greaterChkBox = new System.Windows.Forms.CheckBox();
            this.lesserChkBox = new System.Windows.Forms.CheckBox();
            this.rangeChkBox = new System.Windows.Forms.CheckBox();
            this.greaterEqualChkBox = new System.Windows.Forms.CheckBox();
            this.lessEqualChkBox = new System.Windows.Forms.CheckBox();
            this.filterEditLbl = new System.Windows.Forms.Label();
            this.filterEditChkBox = new System.Windows.Forms.CheckBox();
            this.filterEditColBox = new System.Windows.Forms.TextBox();
            this.filterEditNewValueLbl = new System.Windows.Forms.Label();
            this.filterEditValBox = new System.Windows.Forms.TextBox();
            this.startsWithChkBox = new System.Windows.Forms.CheckBox();
            this.filterInsertChkBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.saveAllChkBox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.stringChkBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.daysOldChkBox = new System.Windows.Forms.CheckBox();
            this.numChkBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.containsChkBox = new System.Windows.Forms.CheckBox();
            this.notEqualChkBox = new System.Windows.Forms.CheckBox();
            this.matchChkBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Searched value is:";
            // 
            // rangeMinMatchLbl
            // 
            this.rangeMinMatchLbl.AutoSize = true;
            this.rangeMinMatchLbl.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rangeMinMatchLbl.Location = new System.Drawing.Point(12, 234);
            this.rangeMinMatchLbl.Name = "rangeMinMatchLbl";
            this.rangeMinMatchLbl.Size = new System.Drawing.Size(82, 14);
            this.rangeMinMatchLbl.TabIndex = 3;
            this.rangeMinMatchLbl.Text = "Minimum value:";
            // 
            // saveBtn
            // 
            this.saveBtn.Enabled = false;
            this.saveBtn.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Location = new System.Drawing.Point(12, 447);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(217, 28);
            this.saveBtn.TabIndex = 20;
            this.saveBtn.Text = "Save Filter";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // rangeMaxLbl
            // 
            this.rangeMaxLbl.AutoSize = true;
            this.rangeMaxLbl.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rangeMaxLbl.Location = new System.Drawing.Point(9, 258);
            this.rangeMaxLbl.Name = "rangeMaxLbl";
            this.rangeMaxLbl.Size = new System.Drawing.Size(84, 14);
            this.rangeMaxLbl.TabIndex = 5;
            this.rangeMaxLbl.Text = "Maximum value:";
            // 
            // matchBox
            // 
            this.matchBox.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matchBox.Location = new System.Drawing.Point(93, 230);
            this.matchBox.Name = "matchBox";
            this.matchBox.Size = new System.Drawing.Size(136, 20);
            this.matchBox.TabIndex = 12;
            this.matchBox.TextChanged += new System.EventHandler(this.rangeMinMatchBox_TextChanged);
            // 
            // rangeMaxBox
            // 
            this.rangeMaxBox.Enabled = false;
            this.rangeMaxBox.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rangeMaxBox.Location = new System.Drawing.Point(93, 255);
            this.rangeMaxBox.Name = "rangeMaxBox";
            this.rangeMaxBox.Size = new System.Drawing.Size(136, 20);
            this.rangeMaxBox.TabIndex = 13;
            this.rangeMaxBox.TextChanged += new System.EventHandler(this.rangeMaxBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 285);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "Search column:";
            // 
            // columnBox
            // 
            this.columnBox.Enabled = false;
            this.columnBox.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.columnBox.Location = new System.Drawing.Point(93, 282);
            this.columnBox.Name = "columnBox";
            this.columnBox.Size = new System.Drawing.Size(36, 20);
            this.columnBox.TabIndex = 14;
            this.columnBox.TextChanged += new System.EventHandler(this.columnBox_TextChanged);
            // 
            // greaterChkBox
            // 
            this.greaterChkBox.AutoSize = true;
            this.greaterChkBox.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.greaterChkBox.Location = new System.Drawing.Point(6, 149);
            this.greaterChkBox.Name = "greaterChkBox";
            this.greaterChkBox.Size = new System.Drawing.Size(84, 18);
            this.greaterChkBox.TabIndex = 7;
            this.greaterChkBox.Text = "Greater than";
            this.greaterChkBox.UseVisualStyleBackColor = true;
            // 
            // lesserChkBox
            // 
            this.lesserChkBox.AutoSize = true;
            this.lesserChkBox.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lesserChkBox.Location = new System.Drawing.Point(133, 149);
            this.lesserChkBox.Name = "lesserChkBox";
            this.lesserChkBox.Size = new System.Drawing.Size(70, 18);
            this.lesserChkBox.TabIndex = 8;
            this.lesserChkBox.Text = "Less than";
            this.lesserChkBox.UseVisualStyleBackColor = true;
            // 
            // rangeChkBox
            // 
            this.rangeChkBox.AutoSize = true;
            this.rangeChkBox.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rangeChkBox.Location = new System.Drawing.Point(6, 198);
            this.rangeChkBox.Name = "rangeChkBox";
            this.rangeChkBox.Size = new System.Drawing.Size(67, 18);
            this.rangeChkBox.TabIndex = 11;
            this.rangeChkBox.Text = "By range";
            this.rangeChkBox.UseVisualStyleBackColor = true;
            // 
            // greaterEqualChkBox
            // 
            this.greaterEqualChkBox.AutoSize = true;
            this.greaterEqualChkBox.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.greaterEqualChkBox.Location = new System.Drawing.Point(6, 174);
            this.greaterEqualChkBox.Name = "greaterEqualChkBox";
            this.greaterEqualChkBox.Size = new System.Drawing.Size(112, 18);
            this.greaterEqualChkBox.TabIndex = 9;
            this.greaterEqualChkBox.Text = "Greater or equal to";
            this.greaterEqualChkBox.UseVisualStyleBackColor = true;
            // 
            // lessEqualChkBox
            // 
            this.lessEqualChkBox.AutoSize = true;
            this.lessEqualChkBox.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lessEqualChkBox.Location = new System.Drawing.Point(133, 174);
            this.lessEqualChkBox.Name = "lessEqualChkBox";
            this.lessEqualChkBox.Size = new System.Drawing.Size(98, 18);
            this.lessEqualChkBox.TabIndex = 10;
            this.lessEqualChkBox.Text = "Less or equal to";
            this.lessEqualChkBox.UseVisualStyleBackColor = true;
            // 
            // filterEditLbl
            // 
            this.filterEditLbl.AutoSize = true;
            this.filterEditLbl.Enabled = false;
            this.filterEditLbl.Location = new System.Drawing.Point(9, 369);
            this.filterEditLbl.Name = "filterEditLbl";
            this.filterEditLbl.Size = new System.Drawing.Size(171, 14);
            this.filterEditLbl.TabIndex = 11;
            this.filterEditLbl.Text = "When a match is made, set column:";
            // 
            // filterEditChkBox
            // 
            this.filterEditChkBox.AutoSize = true;
            this.filterEditChkBox.Enabled = false;
            this.filterEditChkBox.Location = new System.Drawing.Point(93, 315);
            this.filterEditChkBox.Name = "filterEditChkBox";
            this.filterEditChkBox.Size = new System.Drawing.Size(94, 18);
            this.filterEditChkBox.TabIndex = 15;
            this.filterEditChkBox.Text = "Edits a column";
            this.filterEditChkBox.UseVisualStyleBackColor = true;
            // 
            // filterEditColBox
            // 
            this.filterEditColBox.Enabled = false;
            this.filterEditColBox.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterEditColBox.Location = new System.Drawing.Point(186, 363);
            this.filterEditColBox.Name = "filterEditColBox";
            this.filterEditColBox.Size = new System.Drawing.Size(36, 20);
            this.filterEditColBox.TabIndex = 17;
            this.filterEditColBox.TextChanged += new System.EventHandler(this.filterEditColBox_TextChanged);
            // 
            // filterEditNewValueLbl
            // 
            this.filterEditNewValueLbl.AutoSize = true;
            this.filterEditNewValueLbl.Enabled = false;
            this.filterEditNewValueLbl.Location = new System.Drawing.Point(11, 388);
            this.filterEditNewValueLbl.Name = "filterEditNewValueLbl";
            this.filterEditNewValueLbl.Size = new System.Drawing.Size(57, 14);
            this.filterEditNewValueLbl.TabIndex = 14;
            this.filterEditNewValueLbl.Text = "New value:";
            // 
            // filterEditValBox
            // 
            this.filterEditValBox.Enabled = false;
            this.filterEditValBox.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterEditValBox.Location = new System.Drawing.Point(75, 390);
            this.filterEditValBox.Name = "filterEditValBox";
            this.filterEditValBox.Size = new System.Drawing.Size(147, 20);
            this.filterEditValBox.TabIndex = 18;
            this.filterEditValBox.TextChanged += new System.EventHandler(this.filterEditValBox_TextChanged);
            // 
            // startsWithChkBox
            // 
            this.startsWithChkBox.AutoSize = true;
            this.startsWithChkBox.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startsWithChkBox.Location = new System.Drawing.Point(6, 102);
            this.startsWithChkBox.Name = "startsWithChkBox";
            this.startsWithChkBox.Size = new System.Drawing.Size(75, 18);
            this.startsWithChkBox.TabIndex = 3;
            this.startsWithChkBox.Text = "Starts with";
            this.startsWithChkBox.UseVisualStyleBackColor = true;
            // 
            // filterInsertChkBox
            // 
            this.filterInsertChkBox.AutoSize = true;
            this.filterInsertChkBox.Enabled = false;
            this.filterInsertChkBox.Location = new System.Drawing.Point(93, 339);
            this.filterInsertChkBox.Name = "filterInsertChkBox";
            this.filterInsertChkBox.Size = new System.Drawing.Size(102, 18);
            this.filterInsertChkBox.TabIndex = 16;
            this.filterInsertChkBox.Text = "Inserts a column";
            this.filterInsertChkBox.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 311);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 14);
            this.label5.TabIndex = 24;
            this.label5.Text = "This filter:";
            // 
            // saveAllChkBox
            // 
            this.saveAllChkBox.AutoSize = true;
            this.saveAllChkBox.Enabled = false;
            this.saveAllChkBox.Location = new System.Drawing.Point(75, 425);
            this.saveAllChkBox.Name = "saveAllChkBox";
            this.saveAllChkBox.Size = new System.Drawing.Size(85, 18);
            this.saveAllChkBox.TabIndex = 19;
            this.saveAllChkBox.Text = "Save all lines";
            this.saveAllChkBox.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Location = new System.Drawing.Point(4, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(231, 2);
            this.label7.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(4, 309);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(231, 2);
            this.label8.TabIndex = 28;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Location = new System.Drawing.Point(4, 419);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(231, 2);
            this.label9.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(4, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(231, 2);
            this.label6.TabIndex = 36;
            // 
            // stringChkBox
            // 
            this.stringChkBox.AutoSize = true;
            this.stringChkBox.Location = new System.Drawing.Point(6, 54);
            this.stringChkBox.Name = "stringChkBox";
            this.stringChkBox.Size = new System.Drawing.Size(72, 18);
            this.stringChkBox.TabIndex = 2;
            this.stringChkBox.Text = "Plain text";
            this.stringChkBox.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(151, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 14);
            this.label4.TabIndex = 34;
            this.label4.Text = "XXX days old";
            // 
            // daysOldChkBox
            // 
            this.daysOldChkBox.AutoSize = true;
            this.daysOldChkBox.Location = new System.Drawing.Point(133, 33);
            this.daysOldChkBox.Name = "daysOldChkBox";
            this.daysOldChkBox.Size = new System.Drawing.Size(15, 14);
            this.daysOldChkBox.TabIndex = 1;
            this.daysOldChkBox.UseVisualStyleBackColor = true;
            // 
            // numChkBox
            // 
            this.numChkBox.AutoSize = true;
            this.numChkBox.Checked = true;
            this.numChkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.numChkBox.Location = new System.Drawing.Point(6, 31);
            this.numChkBox.Name = "numChkBox";
            this.numChkBox.Size = new System.Drawing.Size(92, 18);
            this.numChkBox.TabIndex = 0;
            this.numChkBox.Text = "Numeric value";
            this.numChkBox.UseVisualStyleBackColor = true;
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
            // containsChkBox
            // 
            this.containsChkBox.AutoSize = true;
            this.containsChkBox.Enabled = false;
            this.containsChkBox.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.containsChkBox.Location = new System.Drawing.Point(133, 102);
            this.containsChkBox.Name = "containsChkBox";
            this.containsChkBox.Size = new System.Drawing.Size(67, 18);
            this.containsChkBox.TabIndex = 4;
            this.containsChkBox.Text = "Contains";
            this.containsChkBox.UseVisualStyleBackColor = true;
            // 
            // notEqualChkBox
            // 
            this.notEqualChkBox.AutoSize = true;
            this.notEqualChkBox.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notEqualChkBox.Location = new System.Drawing.Point(133, 126);
            this.notEqualChkBox.Name = "notEqualChkBox";
            this.notEqualChkBox.Size = new System.Drawing.Size(83, 18);
            this.notEqualChkBox.TabIndex = 6;
            this.notEqualChkBox.Text = "Not equal to";
            this.notEqualChkBox.UseVisualStyleBackColor = true;
            // 
            // matchChkBox
            // 
            this.matchChkBox.AutoSize = true;
            this.matchChkBox.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matchChkBox.Location = new System.Drawing.Point(6, 126);
            this.matchChkBox.Name = "matchChkBox";
            this.matchChkBox.Size = new System.Drawing.Size(64, 18);
            this.matchChkBox.TabIndex = 5;
            this.matchChkBox.Text = "Equal to";
            this.matchChkBox.UseVisualStyleBackColor = true;
            // 
            // AddFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 482);
            this.Controls.Add(this.notEqualChkBox);
            this.Controls.Add(this.matchChkBox);
            this.Controls.Add(this.containsChkBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.stringChkBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.daysOldChkBox);
            this.Controls.Add(this.numChkBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.saveAllChkBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.filterInsertChkBox);
            this.Controls.Add(this.startsWithChkBox);
            this.Controls.Add(this.filterEditValBox);
            this.Controls.Add(this.filterEditNewValueLbl);
            this.Controls.Add(this.filterEditColBox);
            this.Controls.Add(this.filterEditChkBox);
            this.Controls.Add(this.filterEditLbl);
            this.Controls.Add(this.lessEqualChkBox);
            this.Controls.Add(this.greaterEqualChkBox);
            this.Controls.Add(this.rangeChkBox);
            this.Controls.Add(this.lesserChkBox);
            this.Controls.Add(this.greaterChkBox);
            this.Controls.Add(this.columnBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rangeMaxBox);
            this.Controls.Add(this.matchBox);
            this.Controls.Add(this.rangeMaxLbl);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.rangeMinMatchLbl);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "AddFilter";
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox columnBox;
        private System.Windows.Forms.CheckBox greaterChkBox;
        private System.Windows.Forms.CheckBox lesserChkBox;
        private System.Windows.Forms.CheckBox rangeChkBox;
        private System.Windows.Forms.CheckBox greaterEqualChkBox;
        private System.Windows.Forms.CheckBox lessEqualChkBox;
        private System.Windows.Forms.Label filterEditLbl;
        private System.Windows.Forms.CheckBox filterEditChkBox;
        private System.Windows.Forms.TextBox filterEditColBox;
        private System.Windows.Forms.Label filterEditNewValueLbl;
        private System.Windows.Forms.TextBox filterEditValBox;
        private System.Windows.Forms.CheckBox startsWithChkBox;
        private System.Windows.Forms.CheckBox filterInsertChkBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox saveAllChkBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox stringChkBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox daysOldChkBox;
        private System.Windows.Forms.CheckBox numChkBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox containsChkBox;
        private System.Windows.Forms.CheckBox notEqualChkBox;
        private System.Windows.Forms.CheckBox matchChkBox;
    }
}