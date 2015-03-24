using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

using LA3.Model;

namespace LA3
{
    public partial class CntCustomer : UserControl
    {
        private int _currentCustomerID;
        public event DelNewAccount EvNewAccount;
        public event DelLoadAccount EvLoadAccount;
        public event DelShowStatusText EvShowStatusText;
        public event DelBackToMain EvBackToMain;
        //private LA_Entities _db = new LA_Entities();

        public CntCustomer()
        {
            InitializeComponent();
        }

        private void cntCustomer_Load(object sender, EventArgs e)
        {
            var db = new LA_Entities();

            cmbCollector.DataSource = (from c in db.Collectors select c).ToList();
            cmbCollector.DisplayMember = "CollectorName";
            cmbCollector.ValueMember = "Id";

            ClearFields();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            if (EvShowStatusText != null) EvShowStatusText("");
        }

        private void ClearFields()
        {
            var db = new LA_Entities();
            if (_currentCustomerID > 0)
            {
                Customer c = db.Customers.Find(_currentCustomerID);
                c.LockedByUser = "";
                db.SaveChanges();
            }
            _currentCustomerID = 0;
            txtAddress.Text = "";
            txtForename.Text = "";
            txtMaxLoan.Text = "";
            txtNotes.Text = "";
            txtPhoneNumber.Text = "";
            txtPostCode.Text = "";
            txtStartDate.Text = "";
            txtSurname.Text = "";

            cmbCollectionDay.SelectedIndex = -1;
            cmbCollector.SelectedIndex = -1;

            dgAccounts.DataSource = null;
            btnSearch.Enabled = true;

            ClearErrors();

            btnDelete.Enabled = false;
            btnNewAccount.Enabled = false;
            BtnSave.Enabled = false;
            btnSearch.Enabled = true;

            txtSurname.Focus();
        }

        private void ClearErrors()
        {
            epAddress.SetError(txtAddress, "");
            epCollectionDay.SetError(cmbCollectionDay, "");
            epCollector.SetError(cmbCollector, "");
            epForename.SetError(txtForename, "");
            epSurname.SetError(txtSurname, "");
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!IsValid())
                return;
            SaveCustomer();
            ShowCustomer();
        }

        private void SaveCustomer()
        {
            var db = new LA_Entities();
            Customer customer;
            if (_currentCustomerID == 0)
            {
                customer = new Customer();
                db.Customers.Add(customer);
            }
            else
                customer = db.Customers.Find(_currentCustomerID);

            if (txtMaxLoan.Text.Trim().Length == 0)
                txtMaxLoan.Text = "0";

            customer.Address = txtAddress.Text.Trim();
            customer.Collector_Id = ((Collector)cmbCollector.SelectedItem).Id;
            customer.Forename = txtForename.Text.Trim();
            customer.Maxloan = int.Parse(txtMaxLoan.Text);
            customer.Notes = txtNotes.Text.Trim();
            customer.PhoneNumber = txtPhoneNumber.Text.Trim();
            customer.PostCode = txtPostCode.Text.Trim();
            customer.PreferredDay = cmbCollectionDay.SelectedIndex;
            customer.Surname = txtSurname.Text.Trim();
            db.SaveChanges();
            _currentCustomerID = customer.Id;

            if (EvShowStatusText != null) EvShowStatusText("Customer: '" + customer.Surname + "' Saved");
        }

        private bool IsValid()
        {
            ClearErrors();
            bool returnValue = true;
            if (txtSurname.Text.Trim().Length == 0)
            {
                epSurname.SetError(txtSurname, "Enter a surname");
                returnValue = false;
            }
            if (txtForename.Text.Trim().Length == 0)
            {
                epForename.SetError(txtForename, "Enter a forename");
                returnValue = false;
            }
            if (cmbCollector.SelectedIndex == -1)
            {
                epCollector.SetError(cmbCollector, "Select a collector");
                returnValue = false;
            }
            if (cmbCollectionDay.SelectedIndex == -1)
            {
                epCollectionDay.SetError(cmbCollectionDay, "Select a preferred collection day");
                returnValue = false;
            }
            if (txtAddress.Text.Trim().Length == 0)
            {
                epAddress.SetError(txtAddress, "Enter an address");
                returnValue = false;
            }
            return returnValue;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSurname.Text.Trim().Length == 0)
                return;

            var frm = new FrmCustomerSearch(txtSurname.Text.Trim());

            if (frm.CurrentCustomerID > 0)
            {
                ShowCustomer(frm.CurrentCustomerID);
                btnSearch.Enabled = false;
            }
            frm.Dispose();
        }

        public void ShowCustomer()
        {
            if (_currentCustomerID == 0)
                ClearFields();
            else
                ShowCustomer(_currentCustomerID);
        }
        public void ShowCustomer(int customerID)
        {
            var db = new LA_Entities();
            var customer = db.Customers.Find(customerID);

            //Is this customer locked by someone else?
            if (!String.IsNullOrEmpty(customer.LockedByUser) && customer.LockedByUser != Properties.Settings.Default.User)
            {
                //Is it to be unlocked?
                if (MessageBox.Show("This customer is currently locked by " + customer.LockedByUser + ".  Do you want to unlock it?", "Customer Locked", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    customer.LockedByUser = "";
                    db.SaveChanges();
                }
                else
                {
                    if (EvBackToMain != null) EvBackToMain();
                    return;
                }
            }

            _currentCustomerID = customer.Id;
            txtSurname.Text = customer.Surname;
            txtStartDate.Text = customer.StartDate.ToString("dd MMMM yyyy");
            txtPostCode.Text = customer.PostCode;
            txtPhoneNumber.Text = customer.PhoneNumber;
            txtNotes.Text = customer.Notes;
            txtMaxLoan.Text = customer.Maxloan.ToString(CultureInfo.InvariantCulture);
            txtForename.Text = customer.Forename;
            txtAddress.Text = customer.Address;
            cmbCollectionDay.SelectedIndex = customer.PreferredDay;
            cmbCollector.SelectedValue = customer.Collector.Id;
            customer.LockedByUser = Properties.Settings.Default.User;
            db.SaveChanges();

            dgAccounts.AutoGenerateColumns = false;
            var accountsToShow = customer.Accounts.ToList().Where(account => !account.CurrentStatus.IsDeleted).ToList();
            dgAccounts.DataSource = accountsToShow;

            btnDelete.Enabled = true;
            btnNewAccount.Enabled = true;
            BtnSave.Enabled = true;
            btnSearch.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var db = new LA_Entities();
            var name = txtForename.Text.Trim() + " " + txtSurname.Text.Trim();
            if (MessageBox.Show("Delete " + name, "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            //Get the customer
            Customer cust = db.Customers.Find(_currentCustomerID);

            //Check Accounts
            bool canDelete = true;
            foreach (Account a in cust.Accounts)
            {
                if (a.CurrentStatus.IsCreated && a.Outstanding > 0)
                    canDelete = false;
            }

            if (!canDelete)
            {
                MessageBox.Show("This customer has outstanding accounts and, therefore, cannot be deleted.", "No Deletion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Delete
            cust.IsDeleted = true;
            db.SaveChanges();

            if (EvShowStatusText != null) EvShowStatusText(cust.FullName + " deleted.");
            ClearFields();
        }

        private void btnNewAccount_Click(object sender, EventArgs e)
        {
            if (!IsValid())
                return;
            SaveCustomer();
            if (EvNewAccount != null) { EvNewAccount(_currentCustomerID); }
        }

        private void dgAccounts_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var accountID = (int)dgAccounts.SelectedRows[0].Cells[0].Value;
            if (EvLoadAccount != null) { EvLoadAccount(accountID); }
        }

        private void txtSurname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && btnSearch.Enabled) btnSearch_Click(this, e);
        }
    }
}
