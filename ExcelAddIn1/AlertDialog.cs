using System;
using System.Windows.Forms;

namespace ExcelAddIn1
{
    public partial class AlertDialog : Form
    {

        public AlertDialog(string errMsg, string msgDetail)
        {
            InitializeComponent();
            errLbl.Text = errMsg;
            msgLbl.Text = msgDetail;
        }

        private void OkayBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
