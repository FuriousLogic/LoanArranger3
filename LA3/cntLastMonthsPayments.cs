using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

//using LA3_Model.Reports;

namespace LA3
{
    public partial class CntLastMonthsPayments : UserControl
    {
        public CntLastMonthsPayments()
        {
            InitializeComponent();
        }

        private void cntLastMonthsPayments_Load(object sender, EventArgs e)
        {
            DateTime month = DateTime.Today.AddMonths(-1);
            ddMonth.Items.Clear();
            ddMonth.FormatString = "yyyy, MMMM";
            for (int i = 0; i < 12; i++)
            {
                ddMonth.Items.Add(month.AddMonths(i * -1));
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (ddMonth.SelectedItem == null) return;
            ddMonth.Enabled = false;
            btnShow.Enabled = false;
            lblWait.Visible = true;
            pbThrobber.Visible = true;

            var bgw = new BackgroundWorker {WorkerReportsProgress = true, WorkerSupportsCancellation = true};
            bgw.DoWork += bgw_DoWork;
            bgw.ProgressChanged += bgw_ProgressChanged;
            bgw.RunWorkerCompleted += bgw_RunWorkerCompleted;
            bgw.RunWorkerAsync((DateTime)ddMonth.SelectedItem);
        }

        void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ddMonth.Enabled = true;
            btnShow.Enabled = true;
            lblWait.Visible = false;
            pbThrobber.Visible = false;

            //frmPDF pdf = new frmPDF();
            //pdf.Path = pdfPath;
        }

        void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            var month = (DateTime) e.Argument;
            var reports = new Reports.Reports();
            string pdfPath = reports.MonthAudit(month);
            Process.Start(pdfPath);
        }
    }
}
