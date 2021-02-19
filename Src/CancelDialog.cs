using System;
using System.Windows.Forms;

namespace ExcelAddIn1
{
    public partial class CancelDialog : Form
    {
        public CancelDialog()
        {
            InitializeComponent();
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
    }
}
