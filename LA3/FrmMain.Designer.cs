namespace LA3
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collectorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sundriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.owingByCollectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notPaidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byDebtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printAgreementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lastMonthsPaymentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sundriesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sateliteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.lblCaption = new System.Windows.Forms.Label();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.ssMainLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lnkVersion = new System.Windows.Forms.LinkLabel();
            this.mnuMain.SuspendLayout();
            this.ssMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.sateliteToolStripMenuItem,
            this.adminToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(723, 24);
            this.mnuMain.TabIndex = 0;
            this.mnuMain.Text = "menuStrip1";
            // 
            // mainToolStripMenuItem
            // 
            this.mainToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.collectorsToolStripMenuItem,
            this.customersToolStripMenuItem,
            this.accountsToolStripMenuItem,
            this.paymentsToolStripMenuItem,
            this.sundriesToolStripMenuItem});
            this.mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            this.mainToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.mainToolStripMenuItem.Text = "Main";
            // 
            // collectorsToolStripMenuItem
            // 
            this.collectorsToolStripMenuItem.Name = "collectorsToolStripMenuItem";
            this.collectorsToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.collectorsToolStripMenuItem.Text = "Collectors";
            this.collectorsToolStripMenuItem.Click += new System.EventHandler(this.collectorsToolStripMenuItem_Click);
            // 
            // customersToolStripMenuItem
            // 
            this.customersToolStripMenuItem.Name = "customersToolStripMenuItem";
            this.customersToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.customersToolStripMenuItem.Text = "Customers";
            this.customersToolStripMenuItem.Click += new System.EventHandler(this.customersToolStripMenuItem_Click);
            // 
            // accountsToolStripMenuItem
            // 
            this.accountsToolStripMenuItem.Name = "accountsToolStripMenuItem";
            this.accountsToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.accountsToolStripMenuItem.Text = "Accounts";
            this.accountsToolStripMenuItem.Click += new System.EventHandler(this.accountsToolStripMenuItem_Click);
            // 
            // paymentsToolStripMenuItem
            // 
            this.paymentsToolStripMenuItem.Name = "paymentsToolStripMenuItem";
            this.paymentsToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.paymentsToolStripMenuItem.Text = "Payments";
            this.paymentsToolStripMenuItem.Click += new System.EventHandler(this.paymentsToolStripMenuItem_Click);
            // 
            // sundriesToolStripMenuItem
            // 
            this.sundriesToolStripMenuItem.Name = "sundriesToolStripMenuItem";
            this.sundriesToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.sundriesToolStripMenuItem.Text = "Sundries";
            this.sundriesToolStripMenuItem.Click += new System.EventHandler(this.sundriesToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.owingByCollectorToolStripMenuItem,
            this.notPaidToolStripMenuItem,
            this.byDebtToolStripMenuItem,
            this.printAgreementsToolStripMenuItem,
            this.lastMonthsPaymentsToolStripMenuItem,
            this.sundriesToolStripMenuItem1});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // owingByCollectorToolStripMenuItem
            // 
            this.owingByCollectorToolStripMenuItem.Name = "owingByCollectorToolStripMenuItem";
            this.owingByCollectorToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.owingByCollectorToolStripMenuItem.Text = "Owing By Collector";
            this.owingByCollectorToolStripMenuItem.Click += new System.EventHandler(this.owingByCollectorToolStripMenuItem_Click);
            // 
            // notPaidToolStripMenuItem
            // 
            this.notPaidToolStripMenuItem.Name = "notPaidToolStripMenuItem";
            this.notPaidToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.notPaidToolStripMenuItem.Text = "Not Paid";
            this.notPaidToolStripMenuItem.Click += new System.EventHandler(this.notPaidToolStripMenuItem_Click);
            // 
            // byDebtToolStripMenuItem
            // 
            this.byDebtToolStripMenuItem.Name = "byDebtToolStripMenuItem";
            this.byDebtToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.byDebtToolStripMenuItem.Text = "By Debt";
            this.byDebtToolStripMenuItem.Click += new System.EventHandler(this.byDebtToolStripMenuItem_Click);
            // 
            // printAgreementsToolStripMenuItem
            // 
            this.printAgreementsToolStripMenuItem.Name = "printAgreementsToolStripMenuItem";
            this.printAgreementsToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.printAgreementsToolStripMenuItem.Text = "Print Agreements";
            this.printAgreementsToolStripMenuItem.Click += new System.EventHandler(this.printAgreementsToolStripMenuItem_Click);
            // 
            // lastMonthsPaymentsToolStripMenuItem
            // 
            this.lastMonthsPaymentsToolStripMenuItem.Name = "lastMonthsPaymentsToolStripMenuItem";
            this.lastMonthsPaymentsToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.lastMonthsPaymentsToolStripMenuItem.Text = "Business By Month";
            this.lastMonthsPaymentsToolStripMenuItem.Click += new System.EventHandler(this.lastMonthsPaymentsToolStripMenuItem_Click);
            // 
            // sundriesToolStripMenuItem1
            // 
            this.sundriesToolStripMenuItem1.Name = "sundriesToolStripMenuItem1";
            this.sundriesToolStripMenuItem1.Size = new System.Drawing.Size(176, 22);
            this.sundriesToolStripMenuItem1.Text = "Sundries";
            this.sundriesToolStripMenuItem1.Click += new System.EventHandler(this.sundriesToolStripMenuItem1_Click);
            // 
            // sateliteToolStripMenuItem
            // 
            this.sateliteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportDataToolStripMenuItem});
            this.sateliteToolStripMenuItem.Name = "sateliteToolStripMenuItem";
            this.sateliteToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.sateliteToolStripMenuItem.Text = "Satelite";
            this.sateliteToolStripMenuItem.Click += new System.EventHandler(this.sateliteToolStripMenuItem_Click);
            // 
            // exportDataToolStripMenuItem
            // 
            this.exportDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kayToolStripMenuItem});
            this.exportDataToolStripMenuItem.Name = "exportDataToolStripMenuItem";
            this.exportDataToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.exportDataToolStripMenuItem.Text = "Export Data";
            this.exportDataToolStripMenuItem.Click += new System.EventHandler(this.exportDataToolStripMenuItem_Click);
            // 
            // kayToolStripMenuItem
            // 
            this.kayToolStripMenuItem.Name = "kayToolStripMenuItem";
            this.kayToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.kayToolStripMenuItem.Text = "Kay";
            this.kayToolStripMenuItem.Click += new System.EventHandler(this.kayToolStripMenuItem_Click);
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backupDatabaseToolStripMenuItem});
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.adminToolStripMenuItem.Text = "Admin";
            // 
            // backupDatabaseToolStripMenuItem
            // 
            this.backupDatabaseToolStripMenuItem.Name = "backupDatabaseToolStripMenuItem";
            this.backupDatabaseToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.backupDatabaseToolStripMenuItem.Text = "Backup Database";
            this.backupDatabaseToolStripMenuItem.Click += new System.EventHandler(this.backupDatabaseToolStripMenuItem_Click);
            // 
            // pnlControl
            // 
            this.pnlControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlControl.Location = new System.Drawing.Point(18, 59);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(693, 386);
            this.pnlControl.TabIndex = 1;
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.Location = new System.Drawing.Point(12, 34);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(0, 20);
            this.lblCaption.TabIndex = 2;
            // 
            // ssMain
            // 
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ssMainLabel});
            this.ssMain.Location = new System.Drawing.Point(0, 457);
            this.ssMain.Name = "ssMain";
            this.ssMain.Size = new System.Drawing.Size(723, 22);
            this.ssMain.TabIndex = 3;
            this.ssMain.Text = "statusStrip1";
            // 
            // ssMainLabel
            // 
            this.ssMainLabel.Name = "ssMainLabel";
            this.ssMainLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // lnkVersion
            // 
            this.lnkVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkVersion.AutoSize = true;
            this.lnkVersion.Location = new System.Drawing.Point(670, 9);
            this.lnkVersion.Name = "lnkVersion";
            this.lnkVersion.Size = new System.Drawing.Size(41, 13);
            this.lnkVersion.TabIndex = 4;
            this.lnkVersion.TabStop = true;
            this.lnkVersion.Text = "version";
            this.lnkVersion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkVersion_LinkClicked);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 479);
            this.Controls.Add(this.lnkVersion);
            this.Controls.Add(this.ssMain);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.mnuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMain;
            this.Name = "FrmMain";
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ssMain.ResumeLayout(false);
            this.ssMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem collectorsToolStripMenuItem;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.ToolStripMenuItem customersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sundriesToolStripMenuItem;
        private System.Windows.Forms.StatusStrip ssMain;
        private System.Windows.Forms.ToolStripStatusLabel ssMainLabel;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem owingByCollectorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notPaidToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byDebtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printAgreementsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lastMonthsPaymentsToolStripMenuItem;
        private System.Windows.Forms.LinkLabel lnkVersion;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sateliteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sundriesToolStripMenuItem1;
    }
}