using System;
using System.Linq;
using System.Windows.Forms;

using LA3.Model;

namespace LA3
{
    public partial class CntSundry : UserControl
    {
        private Customer _selectedCustomer;
        private Account _selectedAccount;
        private readonly LA_Entities _db = new LA_Entities();

        public CntSundry()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            txtSurname.Text = "";
            txtCustomer.Text = "";
            cmbAccounts.DataSource = null;
            txtSundry.Text = "";
            epSundryAmount.SetError(txtSundry, "");
            dtPayment.Value = DateTime.Now;
            _selectedAccount = null;
            _selectedCustomer = null;
        }

        private void cntSundry_Load(object sender, EventArgs e)
        {
            Clear();
        }

        public Account Account
        {
            get { return _selectedAccount; }
            set
            {
                _selectedAccount = value;
                SelectCustomer(_selectedAccount.Customer.Id);
            }
        }

        private void SelectCustomer(int customerID)
        {
            _selectedCustomer = _db.Customers.Find(customerID);
            txtCustomer.Text = _selectedCustomer.FullName;

            cmbAccounts.DataSource = null;
            cmbAccounts.ValueMember = "AccountID";
            cmbAccounts.DisplayMember = "InvoiceCode";
            cmbAccounts.DataSource = _selectedCustomer.Accounts.ToList();
        }

        private void cmbAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAccounts.SelectedIndex == -1)
            {
                txtCreated.Text = "";
                txtLeftToPay.Text = "";
                txtNetValue.Text = "";
                txtOverdue.Text = "";
                return;
            }

            _selectedAccount = (Account)cmbAccounts.SelectedItem;

            btnPaySundry.Enabled = true;

            //Make sure it's a live account
            if (!_selectedAccount.CurrentStatus.IsCreated)
            {
                string msg = "This account was ";
                if (_selectedAccount.CurrentStatus.IsCompleted) msg += "Completed ";
                if (_selectedAccount.CurrentStatus.IsDeleted) msg += "Deleted ";

                AccountStatusChange accountStatusChange = (from asc in _selectedAccount.AccountStatusChanges orderby asc.Timestamp descending select asc).FirstOrDefault();
                if (accountStatusChange == null) return;

                msg += "on " + accountStatusChange.Timestamp.ToString("dd/MMM/yyyy");
                MessageBox.Show(msg);
                btnPaySundry.Enabled = false;
            }

            txtCreated.Text = _selectedAccount.StartDate.ToString("dd/MMM/yyyy");
            txtLeftToPay.Text = _selectedAccount.Outstanding.ToString("£0.00");
            txtNetValue.Text = _selectedAccount.NetValue.ToString("£0.00");
            txtOverdue.Text = _selectedAccount.Overdue.ToString("£0.00");
        }

        private void btnPaySundry_Click(object sender, EventArgs e)
        {
            epSundryAmount.SetError(txtSundry, "");

            if (!Functions.IsPosDbl(txtSundry.Text))
            {
                epSundryAmount.SetError(txtSundry, "Must be a positive number");
                return;
            }

            float payment = float.Parse(txtSundry.Text);

            if (payment > _selectedAccount.Outstanding)
            {
                epSundryAmount.SetError(txtSundry, "This account only owes £" + _selectedAccount.Outstanding.ToString("0.00"));
                return;
            }

            _db.Payments.Add(
                new Payment
                    {
                        Account_Id = _selectedAccount.Id,
                        Amount = payment,
                        IsSundry = true,
                        Note = "",
                        PaidByAccountId = 0,
                        Timestamp = dtPayment.Value
                    });
            _db.SaveChanges();
            if (_selectedAccount.Outstanding <= 0)
            {
                AccountStatus accountStatus = (from s in _db.AccountStatus where s.Status == "Completed" select s).FirstOrDefault();
                if (accountStatus == null) return;

                _db.AccountStatusChanges.Add(new AccountStatusChange
                    {
                        Account_Id = _selectedAccount.Id,
                        AccountStatus_Id = accountStatus.Id,
                        Timestamp = DateTime.Now
                    });
                _db.SaveChanges();
                MessageBox.Show("This account is now Completed.");
            }

            //Summary
            txtSummaryCustomer.Text = _selectedCustomer.FullName;
            txtSummaryAccount.Text = _selectedAccount.InvoiceCode;
            txtSummaryDate.Text = dtPayment.Value.ToString("dd/MMM/yyyy");
            txtSummaryPayment.Text = payment.ToString("C2");
            pnlSummary.Visible = true;

            Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            CustomerSearch();
        }

        private void CustomerSearch()
        {
            if (txtSurname.Text.Trim().Length == 0)
                return;

            var frm = new FrmCustomerSearch(txtSurname.Text.Trim());

            if (frm.CurrentCustomerID > 0)
                SelectCustomer(frm.CurrentCustomerID);
            frm.Dispose();
        }

        private void txtSurname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && btnSearch.Enabled) CustomerSearch();
        }
    }
}
