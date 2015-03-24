using System;
using System.Windows.Forms;

//using LA3_Model.Reports;

namespace LA3
{
    public partial class CntReportSundries : UserControl
    {
        public CntReportSundries()
        {
            InitializeComponent();
        }

        private void cntReportSundries_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var reports = new Reports.Reports();
            string file = Reports.Reports.Sundries(dpSundry.Value);

            System.Diagnostics.Process.Start(file);
        }
    }
}
