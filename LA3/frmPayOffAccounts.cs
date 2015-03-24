using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

using LA3.Model;


namespace LA3
{
    public partial class FrmPayOffAccounts : Form
    {
        private Account _parentAccount;
        private readonly List<int> _accountIDs = new List<int>();
        private readonly LA_Entities _db = new LA_Entities();

        public FrmPayOffAccounts(int parentID, IEnumerable<Account> accounts)
        {
            InitializeComponent();
            ShowAccounts(parentID, accounts);
            ShowDialog();
        }

        private void ShowAccounts(int parentID, IEnumerable<Account> accounts)
        {
            _parentAccount = _db.Accounts.Find(parentID);
            txtNetValue.Text = _parentAccount.NetValue.ToString("£0.00");

            _accountIDs.Clear();
            dgAccounts.Rows.Clear();
            foreach (Account account in accounts)
            {
                _accountIDs.Add(account.Id);

                object[] row = { 
                                   account.Id.ToString(CultureInfo.InvariantCulture), 
                                   account.StartDate.ToString("dd/MMM/yyyy"), 
                                   account.NetValue.ToString("£0.00"), 
                                   account.Outstanding.ToString("£0.00"), 
                                   account.Overdue.ToString("£0.00"), 
                                   account.Rebate.ToString("£0.00"),
                                   "0.00" 
                               };
                dgAccounts.Rows.Add(row);
            }

            ShowRemainingValue();
        }
        private void ShowRemainingValue()
        {
            //parent account was coming through as null...
            if (_parentAccount == null)
                return;

            var remainingValue = _parentAccount.NetValue;
            foreach (var sPayment in from DataGridViewRow r in dgAccounts.Rows select r.Cells["Payment"].Value.ToString())
            {
                if (!Functions.IsDbl(sPayment)) return;
                var payment = double.Parse(sPayment);
                remainingValue = remainingValue - payment;
            }
            txtValueRemaining.Text = remainingValue.ToString("£0.00");
        }

        private void dgAccounts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ShowRemainingValue();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            //Validate Payments
            var isValid = true;
            foreach (DataGridViewRow r in dgAccounts.Rows)
            {
                var paymentCell = r.Cells["Payment"];
                var payment = (paymentCell.Value == null) ? 0F : float.Parse(paymentCell.Value.ToString());
                if (payment < 0)
                {
                    isValid = false;
                    paymentCell.Style.BackColor = Color.Red;
                }
                else if (payment > 0)
                {
                    //Is this account being overpaid?
                    var outstanding = float.Parse(r.Cells["Outstanding"].Value.ToString().TrimStart('£'));
                    if (outstanding < payment)
                    {
                        isValid = false;
                        paymentCell.Style.BackColor = Color.Red;
                    }
                    else
                        paymentCell.Style.BackColor = Color.White;
                }
            }
            if (!isValid)
                return;

            float totalPayments = 0;
            foreach (DataGridViewRow r in dgAccounts.Rows)
            {
                var paymentCell = r.Cells["Payment"];
                var payeeIdValue = int.Parse(r.Cells[0].Value.ToString());
                var paymentValue = float.Parse(paymentCell.Value.ToString());
                if (paymentValue <= 0) continue;

                var newPayment = new Payment
                {
                    Account_Id = payeeIdValue,
                    Amount = paymentValue,
                    Timestamp = DateTime.Now,
                    PaidByAccountId = _parentAccount.Id,
                    IsSundry = true,
                    Note = ""
                };
                _db.Payments.Add(newPayment);
                totalPayments += paymentValue;
            }
            _db.SaveChanges();

            toolStripStatusLabel1.Text = "Payments made: " + totalPayments.ToString("£0.00");

            var accounts = _accountIDs.Select(id => _db.Accounts.Find(id)).ToList();
            ShowAccounts(_parentAccount.Id, accounts);
        }
    }
}
