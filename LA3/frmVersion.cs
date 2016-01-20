using System;
using System.Windows.Forms;

namespace LA3
{
    public partial class FrmVersion : Form
    {
        public FrmVersion()
        {
            InitializeComponent();
        }

        private void frmVersion_Load(object sender, EventArgs e)
        {
            const string indent = "   ";
            var s = "";
            s += "0.3.2.0" + Environment.NewLine;
            s += indent + "Enh: Better error handling for reports." + Environment.NewLine;
            s += "0.3.1.0" + Environment.NewLine;
            s += indent + "Fix: Payoff amount not being saved." + Environment.NewLine;
            s += "0.3.0.0" + Environment.NewLine;
            s += indent + "Entire backend ripped out and replaced with new code based on Entity Framework." + Environment.NewLine;
            s += "0.2.2.0" + Environment.NewLine;
            s += indent + "Sundries Report.  Lists Sundries entered since a certain date." + Environment.NewLine;
            s += "0.2.1.0" + Environment.NewLine;
            s += indent + "Calculate APR" + Environment.NewLine;
            s += indent + "Include APR on Agreement" + Environment.NewLine;
            s += "0.2.0.0" + Environment.NewLine;
            s += indent + "Calculate cashback repayment on early completion" + Environment.NewLine;
            s += indent + "Increase Payment Types to Regular, Sundry & Repayment" + Environment.NewLine;
            s += "0.1.9.0" + Environment.NewLine;
            s += indent + "Allow payments to put account into credit." + Environment.NewLine;
            s += indent + "Payoff old accounts shows amount remaining in bottom corner." + Environment.NewLine;
            s += indent + "Final payment triggers status change on Account." + Environment.NewLine;
            s += indent + "New Accounts apper in Print Agreements Queue." + Environment.NewLine;
            s += indent + "Better Customer search facility on Sundries" + Environment.NewLine;
            s += "0.1.8.0" + Environment.NewLine;
            s += indent + "This version window doesn't crash..." + Environment.NewLine;
            s += indent + "Payments window only shows customers for that day." + Environment.NewLine;
            s += indent + "Amount collected entered" + Environment.NewLine;
            s += indent + "Report produced after payments entered" + Environment.NewLine;
            s += "0.1.7.0" + Environment.NewLine;
            s += indent + "Database Backup" + Environment.NewLine;
            s += indent + "Report showing all account activity for a month" + Environment.NewLine;
            s += indent + "Payments Due shown in Surname, Forename, CustomerID, Net Value order" + Environment.NewLine;
            s += "0.1.6.0" + Environment.NewLine;
            s += indent + "Payment fields are NOT prepopulated" + Environment.NewLine;
            s += indent + "Can enter zero payment" + Environment.NewLine;
            s += indent + "Version Page" + Environment.NewLine;
            s += indent + "Make all pages sizeable" + Environment.NewLine;
            s += indent + "Consistant order of Accounts on Payments screen" + Environment.NewLine;
            s += indent + "Show 'Not Customer's day' on Payments screen" + Environment.NewLine;
            s += indent + "Show all collector's potential payments" + Environment.NewLine;
            txtVersions.Text = s;
            txtVersions.Select(0, 0);
        }
    }
}
