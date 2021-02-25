
namespace ExcelAddIn1
{
    partial class AlertDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlertDialog));
            this.errLbl = new System.Windows.Forms.Label();
            this.msgLbl = new System.Windows.Forms.Label();
            this.OkayBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // errLbl
            // 
            this.errLbl.AutoSize = true;
            this.errLbl.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errLbl.Location = new System.Drawing.Point(12, 18);
            this.errLbl.Name = "errLbl";
            this.errLbl.Size = new System.Drawing.Size(82, 15);
            this.errLbl.TabIndex = 0;
            this.errLbl.Text = "Error message";
            // 
            // msgLbl
            // 
            this.msgLbl.AutoSize = true;
            this.msgLbl.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msgLbl.Location = new System.Drawing.Point(12, 46);
            this.msgLbl.Name = "msgLbl";
            this.msgLbl.Size = new System.Drawing.Size(96, 15);
            this.msgLbl.TabIndex = 1;
            this.msgLbl.Text = "Message Details";
            // 
            // OkayBtn
            // 
            this.OkayBtn.Location = new System.Drawing.Point(350, 79);
            this.OkayBtn.Name = "OkayBtn";
            this.OkayBtn.Size = new System.Drawing.Size(75, 23);
            this.OkayBtn.TabIndex = 2;
            this.OkayBtn.Text = "OK";
            this.OkayBtn.UseVisualStyleBackColor = true;
            this.OkayBtn.Click += new System.EventHandler(this.OkayBtn_Click);
            // 
            // AlertDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(777, 114);
            this.Controls.Add(this.OkayBtn);
            this.Controls.Add(this.msgLbl);
            this.Controls.Add(this.errLbl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AlertDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Error!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label errLbl;
        private System.Windows.Forms.Label msgLbl;
        private System.Windows.Forms.Button OkayBtn;
    }
}