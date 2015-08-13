using System;
using System.Linq;
using System.Windows.Forms;

using LA3.Model;
//using LA3_Model.Reports;

namespace LA3
{
    public partial class CntAccount : UserControl
    {
        private Account _currentAccount;
        public event DelShowStatusText EvShowStatusText;
        public event DelShowSundry EvShowSundry;
        public event DelShowCustomer EvShowCustomer;
        public event DelBackToMain EvBackToMain; 
        private LA_Entities _db = new LA_Entities();

        #region Constructors
        public CntAccount()
        {
            InitializeComponent();
        }
        #endregion

        #region Private Functions
        private void ShowAccount()
        {
            if (_currentAccount == null)
            {
                ClearAccount();
            }
            else
            {

                if (_currentAccount.Customer_Id == 0)
                {
                    ClearAccount();
                }
                else
                {
                    lblStatus.Visible = false;
                    if (!_currentAccount.CurrentStatus.IsCreated)
                    {
                        lblStatus.Visible = true;
                        lblStatus.Text = _currentAccount.CurrentStatus.Status;
                    }

                    txtInvoiceCode.Text = _currentAccount.InvoiceCode;
                    txtInterest.Text = _currentAccount.Interest.ToString("0.00");
                    txtNetValue.Text = _currentAccount.NetValue.ToString("0.00");
                    txtGrossValue.Text = _currentAccount.GrossValue.ToString("0.00");
                    dtNextPayment.Value = _currentAccount.NextPaymentDate;
                    txtNotes.Text = _currentAccount.Notes;
                    txtOutstanding.Text = _currentAccount.Outstanding.ToString("0.00");
                    txtOverdue.Text = _currentAccount.Overdue.ToString("0.00");
                    txtPayment.Text = _currentAccount.Payment.ToString("0.00");
                    txtRebate.Text = _currentAccount.Rebate.ToString("0.00");
                    txtStartDate.Text = _currentAccount.StartDate.ToString("dd MMM yyyy");
                    udPaymentPeriod.Value = _currentAccount.PaymentPeriod;

                    cmbPeriod.SelectedIndex = 0;
                    if (_currentAccount.PayMonthly)
                        cmbPeriod.SelectedIndex = 1;

                    //Get Customer Details
                    var customer = _db.Customers.Find(_currentAccount.Customer_Id);
                    if (customer == null) throw new Exception(string.Format("Can't find Customer [{0}]", _currentAccount.Customer_Id));

                    txtAddress.Text = customer.Address;
                    txtCustomerName.Text = customer.FullName;
                    txtCustomerNotes.Text = customer.Notes;
                    txtPhoneNumber.Text = customer.PhoneNumber;

                    txtInvoiceCode.ReadOnly = true;
                    txtInterest.ReadOnly = true;
                    txtNetValue.ReadOnly = true;
                    txtGrossValue.ReadOnly = true;
                    txtPayment.ReadOnly = false;
                    udPaymentPeriod.Enabled = true;
                    cmbPeriod.Enabled = true;
                    txtCustomerNotes.ReadOnly = false;
                    txtNotes.ReadOnly = false;
                    dtNextPayment.Enabled = true;

                    btnCustomer.Enabled = true;
                    btnDelete.Enabled = true;
                    btnSundry.Enabled = true;
                    btnSave.Enabled = true;
                    btnPayments.Enabled = true;

                    //If this is a brand new account
                    if (_currentAccount.Id == 0)
                    {
                        txtNetValue.ReadOnly = false;
                        txtGrossValue.ReadOnly = false;
                    }


                }
            }

            //Set focus
            txtCustomerNotes.Focus();
        }
        private void cntAccount_Load(object sender, EventArgs e)
        {
            _db = new LA_Entities();

            dtNextPayment.CustomFormat = "ddd: dd-MMM-yyyy";
            ClearAccount();
            txtInvoiceCode.Focus();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsValid())
                return;

            SaveValues();
            ShowAccount();
        }
        private void SaveValues()
        {
            bool isNewAccount = (_currentAccount.Id == 0);

            _currentAccount.Customer.Notes = txtCustomerNotes.Text;
            _currentAccount.GrossValue = float.Parse(txtGrossValue.Text);
            _currentAccount.LastChecked = DateTime.Now;
            _currentAccount.NetValue = float.Parse(txtNetValue.Text);
            _currentAccount.Notes = txtNotes.Text.Trim();
            _currentAccount.Payment = float.Parse(txtPayment.Text);
            _currentAccount.PaymentPeriod = (int)udPaymentPeriod.Value;
            _currentAccount.PayMonthly = (cmbPeriod.SelectedIndex == 1);
            _currentAccount.NextPaymentDate = dtNextPayment.Value;
            if (isNewAccount) _db.Accounts.Add(_currentAccount);
            _db.SaveChanges();

            if (isNewAccount)
            {
                var canBePaidOff = _currentAccount.Customer.Accounts.Where(account => account.Id != _currentAccount.Id).Where(account => account.CurrentStatus.IsCreated && account.Outstanding > 0).ToList();

                //Can other accounts be paid off?

                if (canBePaidOff.Count > 0)
                    new FrmPayOffAccounts(_currentAccount.Id, canBePaidOff);
            }

            if (EvShowStatusText != null) EvShowStatusText("Account: '" + _currentAccount.InvoiceCode + "' Saved");
        }

        private bool IsValid()
        {
            bool returnValue = true;
            ClearErrorProviders();

            if (!Functions.IsPosDbl(txtGrossValue.Text))
            {
                epGrossValue.SetError(txtGrossValue, "Must be positive number");
                returnValue = false;
            }
            if (cmbPeriod.SelectedIndex == -1)
            {
                epIsMonthly.SetError(cmbPeriod, "Select a payment period");
                returnValue = false;
            }
            if (!Functions.IsPosDbl(txtNetValue.Text))
            {
                epNetValue.SetError(txtNetValue, "Must be positive number");
                returnValue = false;
            }
            else
            {
                if (_currentAccount.Customer.Maxloan > 0)
                {
                    double d = double.Parse(txtNetValue.Text);
                    if (_currentAccount.Customer.Maxloan < d)
                    {
                        epNetValue.SetError(txtNetValue, "Max Loan: " + _currentAccount.Customer.Maxloan.ToString("£0.00"));
                        returnValue = false;
                    }
                }
            }
            if (!Functions.IsPosDbl(txtPayment.Text))
            {
                epPayment.SetError(txtPayment, "Must be positive number");
                returnValue = false;
            }
            if (udPaymentPeriod.Value == 0)
            {
                epPaymentPeriod.SetError(udPaymentPeriod, "Must be positive number");
                returnValue = false;
            }

            if (returnValue)
            {
                double net = double.Parse(txtNetValue.Text);
                double gross = double.Parse(txtGrossValue.Text);
                if (net >= gross)
                {
                    epGrossValue.SetError(txtGrossValue, "Must be more than net");
                    returnValue = false;
                }
            }

            return returnValue;
        }
        private void ClearErrorProviders()
        {
            epGrossValue.SetError(txtGrossValue, "");
            epIsMonthly.SetError(cmbPeriod, "");
            epNetValue.SetError(txtNetValue, "");
            epPayment.SetError(txtPayment, "");
            epPaymentPeriod.SetError(udPaymentPeriod, "");
        }

        private void dtNextPayment_ValueChanged(object sender, EventArgs e)
        {
            if (_currentAccount == null)
                return;

            var customer = _db.Customers.Find(_currentAccount.Customer_Id);
            if (customer == null) throw new Exception(string.Format("Can't find Customer [{0}]", _currentAccount.Customer_Id));

            if ((int)dtNextPayment.Value.DayOfWeek != customer.PreferredDay)
            {
                if (MessageBox.Show("This day does not match the customer's preferred day.  Do you want to change the customer's preferred day to " + dtNextPayment.Value.DayOfWeek.ToString() + "?", "Day Change", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    customer.PreferredDay = (int)dtNextPayment.Value.DayOfWeek;
                    _db.SaveChanges();
                }
            }
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            if (!IsValid())
                return;

            SaveValues();
            if (EvShowCustomer != null) { EvShowCustomer(_currentAccount.Customer.Id); }
        }

        private void txtInvoiceCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtInvoiceCode.Text.Trim().Length != 8) return;

                if (_currentAccount != null)
                    _currentAccount.LockedByUser = "";

                int yr;
                int inv;
                if (!int.TryParse(txtInvoiceCode.Text.Substring(1, 2), out yr)) return;
                if (!int.TryParse(txtInvoiceCode.Text.Substring(4), out inv)) return;
                _currentAccount = (from a in _db.Accounts where a.StartDate.Year == yr && a.InvoiceNumber == inv select a).FirstOrDefault();
                if (_currentAccount != null) ShowAccount();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (_currentAccount != null)
            {
                _currentAccount.LockedByUser = "";
                _db.SaveChanges();
                _currentAccount = null;
            }
            ShowAccount();
            txtInvoiceCode.Focus();
            if (EvShowStatusText != null) EvShowStatusText("");
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            new FrmPayments(_currentAccount.Id);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete this account.  Are you sure?", "Delete Account", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            var newStatus = (from s in _db.AccountStatus where s.Status == "Deleted" select s).FirstOrDefault();
            if (newStatus == null) return;

            _db.AccountStatusChanges.Add(
                new AccountStatusChange
                    {
                        Account_Id = _currentAccount.Id,
                        AccountStatus_Id = newStatus.Id,
                        Timestamp = DateTime.Now
                    });
            _db.SaveChanges();
            if (EvShowStatusText != null) EvShowStatusText("Account: " + _currentAccount.InvoiceCode + ". Deleted");
            ClearAccount();
        }
        #endregion

        #region Public Functions
        public void ClearAccount()
        {
            if (_currentAccount != null)
            {
                _currentAccount.LockedByUser = "";
                _db.SaveChanges();
                _currentAccount = null;
            }

            txtInvoiceCode.Text = "";
            txtInterest.Text = "";
            txtNetValue.Text = "";
            txtGrossValue.Text = "";
            dtNextPayment.Value = DateTime.Now;
            txtNotes.Text = "";
            txtOutstanding.Text = "";
            txtOverdue.Text = "";
            txtPayment.Text = "";
            txtRebate.Text = "";
            txtStartDate.Text = "";
            udPaymentPeriod.Value = 0;
            cmbPeriod.SelectedIndex = -1;

            //Get Customer Details
            txtAddress.Text = "";
            txtCustomerName.Text = "";
            txtCustomerNotes.Text = "";
            txtPhoneNumber.Text = "";

            txtInvoiceCode.ReadOnly = false;
            txtInterest.ReadOnly = true;
            txtNetValue.ReadOnly = true;
            txtGrossValue.ReadOnly = true;
            txtPayment.ReadOnly = true;
            udPaymentPeriod.Enabled = false;
            cmbPeriod.Enabled = false;
            txtCustomerNotes.ReadOnly = true;
            txtNotes.ReadOnly = true;
            dtNextPayment.Enabled = false;

            btnCustomer.Enabled = false;
            btnDelete.Enabled = false;
            btnSundry.Enabled = false;
            btnSave.Enabled = false;
            btnPayments.Enabled = false;

            txtInvoiceCode.Focus();
        }
        public void CreateNewAccount(int customerID)
        {
            //Get next invoice number
            int lastInvoiceNumber = (from a in _db.Accounts where a.StartDate.Year == DateTime.Today.Year orderby a.InvoiceNumber descending select a.InvoiceNumber).FirstOrDefault();

            //Create new Account
            var accountStatus = (from stat in _db.AccountStatus where stat.Status.Equals("created", StringComparison.InvariantCultureIgnoreCase) select stat).FirstOrDefault();
            if (accountStatus == null) throw new Exception("Error creating new Account");
            _currentAccount = new Account
            {
                Customer_Id = customerID,
                GrossValue = 0,
                InvoiceNumber = lastInvoiceNumber + 1,
                LastChecked = DateTime.Now,
                LockedByUser = Properties.Settings.Default.User,
                NetValue = 0,
                NextPaymentDate = DateTime.Now,
                Notes = "",
                Payment = 0,
                PaymentPeriod = 0,
                PayMonthly = false,
                PrintedForm = false,
                StartDate = DateTime.Now
            };
            _currentAccount.AccountStatusChanges.Add(new AccountStatusChange
            {
                AccountStatus = accountStatus,
                Timestamp = DateTime.Now
            });
            _db.Accounts.Add(_currentAccount);

            ShowAccount();
        }
        public void LoadAccount(int accountID)
        {
            _currentAccount = _db.Accounts.Find(accountID);

            //Is this account locked by someone else?
            if (_currentAccount.LockedByUser.Length > 0 && _currentAccount.LockedByUser != Properties.Settings.Default.User)
            {
                //Is it to be unlocked?
                if (MessageBox.Show("This account is currently locked by " + _currentAccount.LockedByUser + ".  Do you want to unlock it?", "Account Locked", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _currentAccount.LockedByUser = "";
                    _db.SaveChanges();
                }
                else
                {
                    _currentAccount = null;
                    if (EvBackToMain != null) EvBackToMain();
                    return;
                }
            }

            _currentAccount.LockedByUser = Properties.Settings.Default.User;
            ShowAccount();
        }
        #endregion

        private void btnSundry_Click(object sender, EventArgs e)
        {
            if (EvShowSundry != null) EvShowSundry(_currentAccount);
        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            //ChartEngine engine = new ChartEngine();
            //engine.Size = new Size(600, 600);
            //engine.ShowXValues = false;
            //engine.ShowYValues = true;

            //ChartCollection charts = new ChartCollection(engine);
            //ChartPointCollection pointsPlanned = new ChartPointCollection();
            //ChartPointCollection pointsActual = new ChartPointCollection();
            //engine.Charts = charts;

            ////Draw line of planned payments
            //Chart linePlanned = new LineChart(pointsPlanned, Color.Black);
            //linePlanned.Legend = "Planned Payments";
            //linePlanned.ShowLegend = true;
            //linePlanned.ShowLineMarkers = false;
            //float paid = currentAccount.Payment;
            //DateTime paymentDate = currentAccount.FirstPayment;
            //while (paid < currentAccount.GrossValue && paymentDate.Date <= DateTime.Now.Date)
            //{
            //    pointsPlanned.Add(new ChartPoint(paymentDate.Ticks.ToString(), paid));

            //    //Increment amount paid
            //    if (currentAccount.GrossValue - paid < currentAccount.Payment)
            //        paid = currentAccount.GrossValue;
            //    else
            //        paid += currentAccount.Payment;

            //    //Increment date
            //    if (currentAccount.PayMonthly)
            //        paymentDate = paymentDate.AddMonths(currentAccount.PaymentPeriod);
            //    else
            //        paymentDate = paymentDate.AddDays(7 * currentAccount.PaymentPeriod);
            //}

            ////Draw line of actual payments
            //Chart lineActual = new LineChart(pointsActual, Color.Green);
            //lineActual.Legend = "Actual Payments";
            //lineActual.ShowLegend = true;
            //lineActual.ShowLineMarkers = false;
            //paid = 0;
            //foreach (Payment p in currentAccount.Payments)
            //{
            //    paid += p.Amount;
            //    pointsActual.Add(new ChartPoint(p.Timestamp.Ticks.ToString(), paid));
            //}

            ////Add the line to the chart
            //charts.Add(linePlanned);
            //charts.Add(lineActual);

            //frmChart frm = new frmChart();
            //frm.Image = engine.GetBitmap();
        }
    }
}
