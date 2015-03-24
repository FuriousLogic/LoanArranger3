using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using LA3.Model;
using LA3.Reports;

namespace LA3
{
    public partial class CntPayments : UserControl
    {
        private readonly LA_Entities _db = new LA_Entities();
        private const string Total = "total";
        private const string Counter = "counter";

        readonly BackgroundWorker _bgw = new BackgroundWorker { WorkerReportsProgress = true, WorkerSupportsCancellation = true };

        public CntPayments()
        {
            InitializeComponent();

            _bgw.DoWork += bgw_DoWork;
            _bgw.ProgressChanged += bgw_ProgressChanged;
            _bgw.RunWorkerCompleted += bgw_RunWorkerCompleted;
        }

        private void cntPayments_Load(object sender, EventArgs e)
        {
            dgPayments.AutoGenerateColumns = false;
            Clear();
            ShowPayments();
        }

        public void Clear()
        {
            var collectors = (from c in _db.Collectors orderby c.CollectorName select c).ToList();
            collectors.Insert(0, new Collector());
            cmbCollector.ValueMember = "CollectorID";
            cmbCollector.DisplayMember = "CollectorName";
            cmbCollector.DataSource = collectors;
            dtCollection.Value = DateTime.Now;
            dgPayments.DataSource = null;
        }

        private void cmbCollector_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowPayments();
        }
        private void ShowPayments()
        {
            //Clear the payments
            dgPayments.DataSource = null;

            //Do we need to continue?
            if (cmbCollector.SelectedIndex == -1) return;
            if (String.IsNullOrEmpty(((Collector)cmbCollector.SelectedItem).CollectorName)) return;

            cmbCollector.Enabled = false;
            dtCollection.Enabled = false;
            dgPayments.Rows.Clear();
            var collector = (Collector)cmbCollector.SelectedItem;

            picLoader.Visible = true;

            _bgw.RunWorkerAsync(collector);
        }

        void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null) return;
            if (e.Cancelled) return;
            if (e.Result == null) return;

            var result = (DataTable)e.Result;
            dgPayments.DataSource = result;

            ShowTotal();
            cmbCollector.Enabled = true;
            dtCollection.Enabled = true;

            picLoader.Visible = false;
        }

        void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            var collector = (Collector)e.Argument;
            var accountsForCollection = collector.GetAccountsForCollection(dtCollection.Value);

            if (accountsForCollection.Count == 0)
                MessageBox.Show("No Results", "LA3", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //var rows = new List<PaymentInfo>();
            var rows = new DataTable();
            rows.Columns.Add("AccountId", typeof(string));
            rows.Columns.Add("InvoiceCode", typeof(string));
            rows.Columns.Add("Forename", typeof(string));
            rows.Columns.Add("Surname", typeof(string));
            rows.Columns.Add("Address", typeof(string));
            rows.Columns.Add("Net", typeof(double));
            rows.Columns.Add("Outstanding", typeof(double));
            rows.Columns.Add("ExpectedPayment", typeof(double));
            rows.Columns.Add("Amountpaid", typeof(double));
            rows.Columns.Add("NextPayment", typeof(DateTime));

            foreach (var a in accountsForCollection)
            {
                ////Only show account if it's the customer's day OR the account collection day
                //var showThisOne = (int)collectionDay.DayOfWeek == a.Customer.PreferredDay || collectionDay == a.NextPaymentDate;
                //if (!showThisOne) continue;
                var paymentMade = (from p in a.Payments where p.Timestamp.Date == dtCollection.Value.Date && p.IsSundry == false select p).FirstOrDefault();

                var newRow = rows.NewRow();
                newRow["AccountId"] = a.Id;
                newRow["InvoiceCode"] = a.InvoiceCode;
                newRow["Forename"] = a.Customer.Forename;
                newRow["Surname"] = a.Customer.Surname;
                newRow["Address"] = a.Customer.AddressFirstLine;
                newRow["Net"] = a.NetValue;
                newRow["Outstanding"] = a.Outstanding;
                newRow["ExpectedPayment"] = a.Payment;
                newRow["Amountpaid"] = (paymentMade == null) ? 0 : paymentMade.Amount;
                newRow["NextPayment"] = a.NextPaymentDate;
                rows.Rows.Add(newRow);
            }

            e.Result = rows;
        }

        private void ShowTotal()
        {
            var total = 0.0;
            foreach (DataGridViewRow gridRow in dgPayments.Rows)
            {
                var backColour = Color.White;
                var id = Convert.ToInt32(gridRow.Cells["AccountId"].Value);
                var account = _db.Accounts.Find(id);
                if (account == null) continue;

                var paymentCell = gridRow.Cells["Payment"];

                var paymentMade = (from p in account.Payments where p.Timestamp.Date == dtCollection.Value.Date && p.IsSundry == false select p).FirstOrDefault();
                if (paymentMade != null)
                {
                    backColour = Color.PaleGreen;
                    paymentCell.ReadOnly = true;
                }
                else
                    paymentCell.ReadOnly = false;

                var sPayment = paymentCell.EditedFormattedValue.ToString();
                double payment;
                if (double.TryParse(sPayment, out payment))
                {
                    gridRow.Cells["Payment"].Style.BackColor = backColour;
                    gridRow.Cells["Payment"].Style.ForeColor = Color.Black;
                    gridRow.Cells["Payment"].Value = payment.ToString("N2");
                    total += payment;
                }
                else
                {
                    gridRow.Cells["Payment"].Style.BackColor = Color.Red;
                    gridRow.Cells["Payment"].Style.ForeColor = Color.White;
                }
            }
            lblTotal.Text = total.ToString("C2");
        }

        private void dtCollection_ValueChanged(object sender, EventArgs e)
        {
            ShowPayments();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgPayments.Rows)
            {
                var paymentCell = row.Cells["Payment"];
                if (paymentCell.Style.BackColor == Color.Red)
                {
                    MessageBox.Show("Fix invalid Payment data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //Validate Amount Taken
            epAmountProvided.Clear();
            if (String.IsNullOrEmpty(txtAmountCollected.Text))
            {
                epAmountProvided.SetError(txtAmountCollected, "Enter a value");
                return;
            }
            if (!Functions.IsPosDbl(txtAmountCollected.Text))
            {
                epAmountProvided.SetError(txtAmountCollected, "Enter a positive numeric value");
                return;
            }

            //Validate Payments
            bool isValid = true;
            foreach (DataGridViewRow r in dgPayments.Rows)
            {
                DataGridViewCell paymentCell = r.Cells["Payment"];
                if (!paymentCell.ReadOnly)
                {
                    bool cellOk = true;
                    if (paymentCell.Value.ToString() == "") paymentCell.Value = "0";
                    if (!Functions.IsDbl(paymentCell.Value.ToString()))
                        cellOk = false;
                    else
                    {
                        double val = Convert.ToDouble(paymentCell.Value);
                        if (val < 0) cellOk = false;
                    }
                    if (!cellOk)
                    {
                        isValid = false;
                        paymentCell.Style.BackColor = Color.LightPink;
                        continue;
                    }

                    //Is this account being overpaid?
                    float payment = float.Parse(paymentCell.Value.ToString());
                    float outstanding = float.Parse(r.Cells["Outstanding"].Value.ToString());
                    if (outstanding < payment)
                    {
                        isValid = false;
                        paymentCell.Style.BackColor = Color.LightPink;
                    }
                    else
                        paymentCell.Style.BackColor = Color.Khaki;
                }
            }
            if (!isValid)
            {
                MessageBox.Show("Check entered values", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            foreach (DataGridViewRow r in dgPayments.Rows)
            {
                DataGridViewCell paymentCell = r.Cells["Payment"];
                if (!paymentCell.ReadOnly)
                {
                    int accountID = int.Parse(r.Cells[0].Value.ToString());
                    float payment = float.Parse(paymentCell.Value.ToString());
                    if (payment > 0)
                    {
                        Account a = _db.Accounts.Find(accountID);
                        var p = new Payment
                        {
                            Amount = payment,
                            IsSundry = false,
                            Note = "",
                            Timestamp = dtCollection.Value
                        };
                        a.Payments.Add(p);
                        _db.SaveChanges();
                    }
                }
            }
            ShowPayments();

            //Print Report
            var collectorID = ((Collector)(cmbCollector.SelectedValue)).Id;
            var reports = new Reports.Reports();
            var file = reports.PaymentsTaken(collectorID, dtCollection.Value, Convert.ToDouble(txtAmountCollected.Text));
            Process.Start(file);

            Cursor.Current = Cursors.Default;
        }

        private void dgPayments_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //ShowTotal();
        }

        private void dgPayments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                dgPayments.Sort(dgPayments.Columns[e.ColumnIndex], ListSortDirection.Ascending);
                return;
            }

            dgPayments.CurrentCell = dgPayments.Rows[e.RowIndex].Cells[e.ColumnIndex];
            dgPayments.BeginEdit(true);
        }

        private void dgPayments_Sorted(object sender, EventArgs e)
        {
            ShowTotal();
        }

        private void dgPayments_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                dgPayments.Sort(dgPayments.Columns[e.ColumnIndex], ListSortDirection.Ascending);
                return;
            }

            dgPayments.CurrentCell = dgPayments.Rows[e.RowIndex].Cells[e.ColumnIndex];
            dgPayments.BeginEdit(true);
        }
    }

    internal class LoadProgress
    {
        public int Value { get; set; }
        public int Max { get; set; }
    }
}
