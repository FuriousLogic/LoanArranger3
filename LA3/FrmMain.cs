using System;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;

using LA3.Model;
using LA3.Properties;

public delegate void DelNewAccount(int customerId);
public delegate void DelLoadAccount(int accountId);
public delegate void DelShowCustomer(int customerId);
public delegate void DelShowStatusText(string message);
public delegate void DelShowSundry(Account account);
public delegate void DelBackToMain();

namespace LA3
{
    public partial class FrmMain : Form
    {
        private CntSundry _cSundry;
        private CntCollector _cCollector;
        private CntPayments _cPayment;
        private CntAccount _cAccount;
        private CntCustomer _cCustomer;
        private CntReportNotPaid _cReportNotPaid;
        private CntReportByDebt _cReportByDebt;
        private CntPrintAgreement _cPrintAgreement;
        private CntLastMonthsPayments _cLastMonthsPayments;
        private CntReportSundries _cReportSundries;

        public FrmMain()
        {
            //bug: form never dislayed
            InitializeComponent();

            //var appPath = Application.ExecutablePath;
            //var n = appPath.LastIndexOf(@"\", StringComparison.Ordinal);
            //appPath = appPath.Substring(0, n + 1);

            //todo: Lose this?
            //DB Import?
            if (!Properties.Settings.Default.ImportDB) return;

            //Do you want to overwrite?
            var dialogResult = MessageBox.Show("Do you want to overwrite the DB?", "New DB", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dialogResult != DialogResult.Yes) return;

            var frmImportEncryptedDb = new frmImportEncryptedDB();
            frmImportEncryptedDb.ShowDialog();

        }

        private void collectorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _cCollector.ClearFields();
                ShowControl(_cCollector, "Collectors");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void ShowControl(Control userControl, string caption)
        {
            try
            {
                lblCaption.Text = caption;
                pnlControl.Controls.Clear();
                pnlControl.Controls.Add(userControl);
                userControl.Anchor = AnchorStyles.Right;
                userControl.Dock = DockStyle.Fill;
                ssMainLabel.Text = "";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ShowControl(_cCustomer, "Customers");
                _cCustomer.ShowCustomer();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        void cust_evLoadAccount(int accountID)
        {
            try
            {
                ShowControl(_cAccount, "Accounts");
                _cAccount.LoadAccount(accountID);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        void cust_evNewAccount(int customerID)
        {
            try
            {
                ShowControl(_cAccount, "Accounts");
                _cAccount.CreateNewAccount(customerID);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        void acc_evShowCustomer(int customerID)
        {
            try
            {
                ShowControl(_cCustomer, "Customers");
                _cCustomer.ShowCustomer(customerID);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void accountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _cAccount.ClearAccount();
                ShowControl(_cAccount, "Accounts");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                InitialiseControls();

                //Show Version from AssemblyInfo.cs
                Version ver = Assembly.GetExecutingAssembly().GetName().Version;
                Text = "Loan Arranger III:";
                lnkVersion.Text = "v." + ver.Major.ToString(CultureInfo.InvariantCulture) + "." + ver.Minor.ToString(CultureInfo.InvariantCulture) + "." + ver.Build.ToString(CultureInfo.InvariantCulture) + "." + ver.Revision.ToString(CultureInfo.InvariantCulture);

                //Check for User
                if (String.IsNullOrEmpty(Settings.Default.User))
                {
                    MessageBox.Show("Setup the 'User' item in AppSettings within app.config", "Configuration Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
                else
                {
                    Text += " (" + Settings.Default.User + ")";
                }

                //Show Satelite menu
                sateliteToolStripMenuItem.Enabled = Convert.ToBoolean(ConfigurationManager.AppSettings["ShowSateliteMenu"]);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void InitialiseControls()
        {
            try
            {
                _cAccount = new CntAccount();
                _cAccount.EvShowCustomer += acc_evShowCustomer;
                _cAccount.EvShowStatusText += EvShowStatusText;
                _cAccount.EvShowSundry += acc_evShowSundry;
                _cAccount.EvBackToMain += BackToMain;

                _cCustomer = new CntCustomer();
                _cCustomer.EvNewAccount += cust_evNewAccount;
                _cCustomer.EvLoadAccount += cust_evLoadAccount;
                _cCustomer.EvShowStatusText += EvShowStatusText;
                _cCustomer.EvBackToMain += BackToMain;

                _cCollector = new CntCollector();
                _cCollector.EvShowStatusText += EvShowStatusText;

                _cPayment = new CntPayments();
                _cSundry = new CntSundry();
                _cReportNotPaid = new CntReportNotPaid();
                _cReportByDebt = new CntReportByDebt();
                _cPrintAgreement = new CntPrintAgreement();
                _cLastMonthsPayments = new CntLastMonthsPayments();
                _cReportSundries = new CntReportSundries();

                //cPrintAgreement.Anchor = AnchorStyles.Bottom & AnchorStyles.Top;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        void BackToMain()
        {
            try
            {
                lblCaption.Text = "";
                pnlControl.Controls.Clear();
                ssMainLabel.Text = "";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        void acc_evShowSundry(Account account)
        {
            try
            {
                ShowControl(_cSundry, "Sundry");
                _cSundry.Account = account;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void EvShowStatusText(string msg)
        {
            try
            {
                ssMainLabel.Text = msg;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void paymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _cPayment.Clear();
                ShowControl(_cPayment, "Payments");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void sundriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _cSundry.Clear();
                ShowControl(_cSundry, "Sundries");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void owingByCollectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var reports = new Reports.Reports();
                var file = reports.OwingByCollector();

                Process.Start(file);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void notPaidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ShowControl(_cReportNotPaid, "Report - Not Paid");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void byDebtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ShowControl(_cReportByDebt, "Report - By Debt");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void printAgreementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ShowControl(_cPrintAgreement, "Print Agreements");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void lastMonthsPaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ShowControl(_cLastMonthsPayments, "Last Month's Payments");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void lnkVersion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                var f = new FrmVersion();
                f.ShowDialog();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void backupDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Backup oBackup = new Backup();

            //ServerConnection conn = new ServerConnection(@"(local)\SQLEXPRESS");

            ////Create the SMO server object using connection
            //Server oSQLServer = new Server(conn);

            ////set the path where backup file will be stored
            //string OrigBackupPath = oSQLServer.Information.MasterDBPath.Replace(@"\DATA", @"\Backup\LA3_" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".BAK");

            ////create SMO.Backupdevice object
            //BackupDeviceItem bkDevItem = new BackupDeviceItem(OrigBackupPath, DeviceType.File);

            //oBackup.Action = BackupActionType.Database;
            //oBackup.Database = "LoanArranger3";
            //oBackup.Devices.Add(bkDevItem);
            //oBackup.Initialize = true;
            //oBackup.Checksum = true;
            //oBackup.ContinueAfterError = true;
            //oBackup.Incremental = false;
            //oBackup.LogTruncation = BackupTruncateLogType.Truncate;

            ////Backup SQL database;
            //oBackup.SqlBackup(oSQLServer);

            //MessageBox.Show("Database backed up to: " + OrigBackupPath, "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exportDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void sateliteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void kayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Collector c = new Collector(340);
            //List<Account> accounts = c.GetSataliteData();
            //c.Dispose();
            //MessageBox.Show(accounts.Count.ToString());
        }

        private void sundriesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                ShowControl(_cReportSundries, "Sundries Report");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}