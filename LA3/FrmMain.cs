using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//using Microsoft.SqlServer.Management.Smo;
//using Microsoft.SqlServer.Management.Common;

using LA3.Model;

public delegate void DelNewAccount(int customerID);
public delegate void DelLoadAccount(int accountID);
public delegate void DelShowCustomer(int customerID);
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

        private readonly string _appPath = "";

        public FrmMain()
        {
            //bug: form never dislayed
            InitializeComponent();

            _appPath = Application.ExecutablePath;
            var n = _appPath.LastIndexOf(@"\", StringComparison.Ordinal);
            _appPath = _appPath.Substring(0, n + 1);

            //DB Import?
            if (!Properties.Settings.Default.ImportDB) return;

            //Do you want to overwrite?
            var dialogResult = MessageBox.Show("Do you want to overwrite the DB?", "New DB", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dialogResult != DialogResult.Yes) return;

            //Select DB File
            var ofd = new OpenFileDialog { Multiselect = false };
            var result = ofd.ShowDialog();
            if (result != DialogResult.OK) return;
            var scriptFileName = ofd.FileName;

            //Does DB Exist?
            var canConnectToDb = true;
            var db = new LA_Entities();
            var serverName = db.Database.Connection.DataSource;
            var databaseName = db.Database.Connection.Database;
            var connectionString = string.Format("Server={0};Database=master;Trusted_Connection=True;", serverName);
            var sqlConnection = new SqlConnection(connectionString);
            try
            {
                //var collectors = (from c in db.Collectors select c).ToList();
                var sqlFindDb = string.Format("select count(*) from master.dbo.sysdatabases where name = '{0}'", databaseName);
                var da = new SqlDataAdapter();
                var sqlCommand = new SqlCommand(sqlFindDb, sqlConnection);
                da.SelectCommand = sqlCommand;
                var ds = new DataSet();
                sqlConnection.Open();
                da.Fill(ds);
                sqlConnection.Close();
                var sCount = ds.Tables[0].Rows[0][0].ToString();
                int count;
                if (!int.TryParse(sCount, out count)) canConnectToDb = false;
                if (count == 0) canConnectToDb = false;
            }
            catch (Exception e)
            {
                canConnectToDb = false;
            }

            //Remove existing Db
            if (canConnectToDb)
            {
                var sqlDropDatabase = string.Format("ALTER DATABASE {0} SET SINGLE_USER WITH ROLLBACK IMMEDIATE{1}drop database [{0}]", databaseName, Environment.NewLine);
                var sqlCommand = new SqlCommand(sqlDropDatabase, sqlConnection);
                sqlConnection.Open();
                var executeNonQuery = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            //Create blank DB
            var sqlCreateDatabase = string.Format("create database [{0}]", databaseName);
            var command = new SqlCommand(sqlCreateDatabase, sqlConnection);
            sqlConnection.Open();
            command.ExecuteNonQuery();

            //todo:Decrypt

            //Run script to rebuild db
            //var script = File.ReadAllText(scriptFileName);
            var scriptBatch = new StringBuilder();
            using (var reader = new StreamReader(scriptFileName))
            {
                while (true)
                {
                    var line = reader.ReadLine();
                    if (line == null) break;
                    //if (line.ToUpper().Contains(" ANSI_NULLS ")) continue;
                    if (line.TrimStart().StartsWith("--")) continue;
                    if (line.Equals("go", StringComparison.InvariantCultureIgnoreCase))
                    {
                        var s = scriptBatch.ToString();
                        command = new SqlCommand(s, sqlConnection);
                        command.ExecuteNonQuery();
                        scriptBatch.Clear();
                    }
                    else
                    {
                        if (line.Trim().Length > 0)
                            scriptBatch.AppendLine(line);
                    }
                }
            }

            if (scriptBatch.ToString().Trim().Length > 0)
            {
                command = new SqlCommand(scriptBatch.ToString(), sqlConnection);
                command.ExecuteNonQuery();

            }
            sqlConnection.Close();

            MessageBox.Show(@"New Database Loaded");
        }

        private void collectorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _cCollector.ClearFields();
            ShowControl(_cCollector, "Collectors");
        }

        private void ShowControl(Control userControl, string caption)
        {
            lblCaption.Text = caption;
            pnlControl.Controls.Clear();
            pnlControl.Controls.Add(userControl);
            userControl.Anchor = AnchorStyles.Right;
            userControl.Dock = DockStyle.Fill;
            ssMainLabel.Text = "";
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowControl(_cCustomer, "Customers");
            _cCustomer.ShowCustomer();
        }

        void cust_evLoadAccount(int accountID)
        {
            ShowControl(_cAccount, "Accounts");
            _cAccount.LoadAccount(accountID);
        }

        void cust_evNewAccount(int customerID)
        {
            ShowControl(_cAccount, "Accounts");
            _cAccount.CreateNewAccount(customerID);
        }

        void acc_evShowCustomer(int customerID)
        {
            ShowControl(_cCustomer, "Customers");
            _cCustomer.ShowCustomer(customerID);
        }

        private void accountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _cAccount.ClearAccount();
            ShowControl(_cAccount, "Accounts");
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            InitialiseControls();

            //Show Version from AssemblyInfo.cs
            Version ver = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            Text = "Loan Arranger III:";
            lnkVersion.Text = "v." + ver.Major.ToString(CultureInfo.InvariantCulture) + "." + ver.Minor.ToString(CultureInfo.InvariantCulture) + "." + ver.Build.ToString(CultureInfo.InvariantCulture) + "." + ver.Revision.ToString(CultureInfo.InvariantCulture);

            //Check for User
            if (String.IsNullOrEmpty(Properties.Settings.Default.User))
            {
                MessageBox.Show("Setup the 'User' item in AppSettings within app.config", "Configuration Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            else
            {
                Text += " (" + Properties.Settings.Default.User + ")";
            }

            //Show Satelite menu
            sateliteToolStripMenuItem.Enabled = Convert.ToBoolean(ConfigurationManager.AppSettings["ShowSateliteMenu"]);
        }

        private void InitialiseControls()
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

        void BackToMain()
        {
            lblCaption.Text = "";
            pnlControl.Controls.Clear();
            ssMainLabel.Text = "";
        }

        void acc_evShowSundry(Account account)
        {
            ShowControl(_cSundry, "Sundry");
            _cSundry.Account = account;
        }

        private void EvShowStatusText(string msg)
        {
            ssMainLabel.Text = msg;
        }

        private void paymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _cPayment.Clear();
            ShowControl(_cPayment, "Payments");
        }

        private void sundriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _cSundry.Clear();
            ShowControl(_cSundry, "Sundries");
        }

        private void owingByCollectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var reports = new Reports.Reports();
            string file = reports.OwingByCollector();

            System.Diagnostics.Process.Start(file);
        }

        private void notPaidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowControl(_cReportNotPaid, "Report - Not Paid");
        }

        private void byDebtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowControl(_cReportByDebt, "Report - By Debt");
        }

        private void printAgreementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowControl(_cPrintAgreement, "Print Agreements");
        }

        private void lastMonthsPaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowControl(_cLastMonthsPayments, "Last Month's Payments");
        }

        private void lnkVersion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var f = new FrmVersion();
            f.ShowDialog();
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
            ShowControl(_cReportSundries, "Sundries Report");
        }
    }
}