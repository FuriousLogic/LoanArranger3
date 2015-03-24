using System;
using System.Windows.Forms;

using LA3.Model;

namespace LA3
{
    public partial class FrmPayments : Form
    {
        private readonly LA_Entities _db = new LA_Entities();

        public FrmPayments(int accountID)
        {
            InitializeComponent();

            Account a = _db.Accounts.Find(accountID);
            foreach (var p in a.Payments)
            {
                var paidBy = "";
                if (p.PaidByAccountId != 0)
                    paidBy = _db.Accounts.Find(p.PaidByAccountId).InvoiceCode;

                object[] row = { p.Timestamp.ToString("dd/MMM/yyyy"), p.Amount.ToString("£0.00"), p.Type, paidBy };
                dgPayments.Rows.Add(row);
            }

            ShowDialog();
        }

        private void frmPayments_Load(object sender, EventArgs e)
        {

        }
    }
}
