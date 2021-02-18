using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcelAddIn1
{
    public partial class StartBtn
    {
       
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
            
        }

        private void ShowParser_Click(object sender, RibbonControlEventArgs e)
        {

            ThisAddIn.mainWindow = new Main();
            ThisAddIn.mainWindow.Show();
            ThisAddIn.mainWindow.FormClosing += ShowParser_Close;
        }

        private void ShowParser_Close(object sender, EventArgs e)
        {
            ThisAddIn.mainWindow.Dispose();
        }
    }
}
