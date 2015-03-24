using System;
using System.Windows.Forms;

namespace LA3
{
    public partial class CntReportNotPaid : UserControl
    {
        public CntReportNotPaid()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int weeks;
            try
            {
                weeks = int.Parse(txtWeeks.Text);
            }
            catch (Exception)
            {
                return;
            }

            var reports = new Reports.Reports();
            string file = reports.NotPaid(weeks);

            System.Diagnostics.Process.Start(file);
        }

        private void cntReportNotPaid_Load(object sender, EventArgs e)
        {
            txtWeeks.Focus();
        }
    }
}
