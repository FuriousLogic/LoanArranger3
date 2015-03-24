using System;
using System.Windows.Forms;

//using LA3_Model.Reports;

namespace LA3
{
    public partial class CntReportByDebt : UserControl
    {
        public CntReportByDebt()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var debt = 0;
            if (!int.TryParse(txtDebt.Text, out debt)) return;

            var reports = new Reports.Reports();
            string file = reports.ByDebt(debt);

            System.Diagnostics.Process.Start(file);
        }

        private void cntReportByDebt_Load(object sender, EventArgs e)
        {
            txtDebt.Focus();
        }
    }
}
