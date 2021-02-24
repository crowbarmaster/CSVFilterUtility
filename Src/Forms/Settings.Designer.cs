
namespace ExcelAddIn1
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.inputLocationLbl = new System.Windows.Forms.Label();
            this.outputLocationLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.inputLocationBtn = new System.Windows.Forms.Button();
            this.outputLocationBtn = new System.Windows.Forms.Button();
            this.filterInputDefaultDropbox = new System.Windows.Forms.ComboBox();
            this.setDefaultListBtn = new System.Windows.Forms.Button();
            this.saveSettingsBtn = new System.Windows.Forms.Button();
            this.filterOpDefaultDropBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // inputLocationLbl
            // 
            this.inputLocationLbl.AutoSize = true;
            this.inputLocationLbl.Location = new System.Drawing.Point(5, 14);
            this.inputLocationLbl.Name = "inputLocationLbl";
            this.inputLocationLbl.Size = new System.Drawing.Size(126, 13);
            this.inputLocationLbl.TabIndex = 0;
            this.inputLocationLbl.Text = "Default input file location:";
            // 
            // outputLocationLbl
            // 
            this.outputLocationLbl.AutoSize = true;
            this.outputLocationLbl.Location = new System.Drawing.Point(5, 63);
            this.outputLocationLbl.Name = "outputLocationLbl";
            this.outputLocationLbl.Size = new System.Drawing.Size(133, 13);
            this.outputLocationLbl.TabIndex = 1;
            this.outputLocationLbl.Text = "Default output file location:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Default input filter type:";
            // 
            // inputLocationBtn
            // 
            this.inputLocationBtn.Location = new System.Drawing.Point(126, 29);
            this.inputLocationBtn.Name = "inputLocationBtn";
            this.inputLocationBtn.Size = new System.Drawing.Size(160, 23);
            this.inputLocationBtn.TabIndex = 3;
            this.inputLocationBtn.Text = "Select directory...";
            this.inputLocationBtn.UseVisualStyleBackColor = true;
            this.inputLocationBtn.Click += new System.EventHandler(this.inputLocationBtn_Click);
            // 
            // outputLocationBtn
            // 
            this.outputLocationBtn.Location = new System.Drawing.Point(126, 77);
            this.outputLocationBtn.Name = "outputLocationBtn";
            this.outputLocationBtn.Size = new System.Drawing.Size(160, 23);
            this.outputLocationBtn.TabIndex = 4;
            this.outputLocationBtn.Text = "Select directory...";
            this.outputLocationBtn.UseVisualStyleBackColor = true;
            this.outputLocationBtn.Click += new System.EventHandler(this.outputLocationBtn_Click);
            // 
            // filterInputDefaultDropbox
            // 
            this.filterInputDefaultDropbox.BackColor = System.Drawing.SystemColors.Control;
            this.filterInputDefaultDropbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterInputDefaultDropbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filterInputDefaultDropbox.FormattingEnabled = true;
            this.filterInputDefaultDropbox.Location = new System.Drawing.Point(185, 116);
            this.filterInputDefaultDropbox.Name = "filterInputDefaultDropbox";
            this.filterInputDefaultDropbox.Size = new System.Drawing.Size(149, 21);
            this.filterInputDefaultDropbox.TabIndex = 5;
            this.filterInputDefaultDropbox.SelectedIndexChanged += new System.EventHandler(this.filterInputDefaultDropbox_SelectedIndexChanged);
            // 
            // setDefaultListBtn
            // 
            this.setDefaultListBtn.Location = new System.Drawing.Point(121, 170);
            this.setDefaultListBtn.Name = "setDefaultListBtn";
            this.setDefaultListBtn.Size = new System.Drawing.Size(173, 23);
            this.setDefaultListBtn.TabIndex = 6;
            this.setDefaultListBtn.Text = "Set current filter list as default";
            this.setDefaultListBtn.UseVisualStyleBackColor = true;
            this.setDefaultListBtn.Click += new System.EventHandler(this.setDefaultListBtn_Click);
            // 
            // saveSettingsBtn
            // 
            this.saveSettingsBtn.Location = new System.Drawing.Point(121, 199);
            this.saveSettingsBtn.Name = "saveSettingsBtn";
            this.saveSettingsBtn.Size = new System.Drawing.Size(173, 23);
            this.saveSettingsBtn.TabIndex = 7;
            this.saveSettingsBtn.Text = "Save settings";
            this.saveSettingsBtn.UseVisualStyleBackColor = true;
            this.saveSettingsBtn.Click += new System.EventHandler(this.saveSettingsBtn_Click);
            // 
            // filterOpDefaultDropBox
            // 
            this.filterOpDefaultDropBox.BackColor = System.Drawing.SystemColors.Control;
            this.filterOpDefaultDropBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterOpDefaultDropBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filterOpDefaultDropBox.FormattingEnabled = true;
            this.filterOpDefaultDropBox.Location = new System.Drawing.Point(185, 143);
            this.filterOpDefaultDropBox.Name = "filterOpDefaultDropBox";
            this.filterOpDefaultDropBox.Size = new System.Drawing.Size(149, 21);
            this.filterOpDefaultDropBox.TabIndex = 9;
            this.filterOpDefaultDropBox.SelectedIndexChanged += new System.EventHandler(this.filterOpDefaultDropBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Default filter Operation:";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(426, 234);
            this.Controls.Add(this.filterOpDefaultDropBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.saveSettingsBtn);
            this.Controls.Add(this.setDefaultListBtn);
            this.Controls.Add(this.filterInputDefaultDropbox);
            this.Controls.Add(this.outputLocationBtn);
            this.Controls.Add(this.inputLocationBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.outputLocationLbl);
            this.Controls.Add(this.inputLocationLbl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label inputLocationLbl;
        private System.Windows.Forms.Label outputLocationLbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button inputLocationBtn;
        private System.Windows.Forms.Button outputLocationBtn;
        private System.Windows.Forms.ComboBox filterInputDefaultDropbox;
        private System.Windows.Forms.Button setDefaultListBtn;
        private System.Windows.Forms.Button saveSettingsBtn;
        private System.Windows.Forms.ComboBox filterOpDefaultDropBox;
        private System.Windows.Forms.Label label4;
    }
}