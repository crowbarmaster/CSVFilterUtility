using System;
using System.Windows.Forms;

namespace ExcelAddIn1
{
    public partial class CancelDialog : Form
    {
        public string EditLblText;
        public CancelDialog()
        {
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;
            Shown += CancelDialog_Shown;
        }

        private void CancelDialog_Shown(object sender, EventArgs e)
        {
            if(EditLblText != null)
            {
                editLbl.Text = EditLblText;
            }
        }

        private void yesBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void noBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
