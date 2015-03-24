namespace LA3
{
    partial class FrmPayOffAccounts
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNetValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtValueRemaining = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgAccounts = new System.Windows.Forms.DataGridView();
            this.btnPayment = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.AccountID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Outstanding = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Overdue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rebate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Payment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgAccounts)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Accounts to Pay Off";
            // 
            // txtNetValue
            // 
            this.txtNetValue.Location = new System.Drawing.Point(486, 4);
            this.txtNetValue.Name = "txtNetValue";
            this.txtNetValue.ReadOnly = true;
            this.txtNetValue.Size = new System.Drawing.Size(100, 20);
            this.txtNetValue.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(371, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Donor Account Value";
            // 
            // txtValueRemaining
            // 
            this.txtValueRemaining.Location = new System.Drawing.Point(486, 339);
            this.txtValueRemaining.Name = "txtValueRemaining";
            this.txtValueRemaining.ReadOnly = true;
            this.txtValueRemaining.Size = new System.Drawing.Size(100, 20);
            this.txtValueRemaining.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(318, 346);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Donor Account Value Remaining";
            // 
            // dgAccounts
            // 
            this.dgAccounts.AllowUserToAddRows = false;
            this.dgAccounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAccounts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AccountID,
            this.StartDate,
            this.NetValue,
            this.Outstanding,
            this.Overdue,
            this.Rebate,
            this.Payment});
            this.dgAccounts.Location = new System.Drawing.Point(12, 27);
            this.dgAccounts.Name = "dgAccounts";
            this.dgAccounts.RowHeadersVisible = false;
            this.dgAccounts.Size = new System.Drawing.Size(574, 306);
            this.dgAccounts.TabIndex = 6;
            this.dgAccounts.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgAccounts_CellValueChanged);
            // 
            // btnPayment
            // 
            this.btnPayment.Location = new System.Drawing.Point(454, 366);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(131, 23);
            this.btnPayment.TabIndex = 7;
            this.btnPayment.Text = "Register Payments";
            this.btnPayment.UseVisualStyleBackColor = true;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 397);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(599, 22);
            this.statusStrip1.TabIndex = 8;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // AccountID
            // 
            this.AccountID.HeaderText = "AccountID";
            this.AccountID.Name = "AccountID";
            this.AccountID.ReadOnly = true;
            this.AccountID.Visible = false;
            this.AccountID.Width = 64;
            // 
            // StartDate
            // 
            this.StartDate.HeaderText = "Start Date";
            this.StartDate.Name = "StartDate";
            this.StartDate.ReadOnly = true;
            this.StartDate.Width = 80;
            // 
            // NetValue
            // 
            this.NetValue.HeaderText = "Net Value";
            this.NetValue.Name = "NetValue";
            this.NetValue.ReadOnly = true;
            this.NetValue.Width = 79;
            // 
            // Outstanding
            // 
            this.Outstanding.HeaderText = "Outstanding";
            this.Outstanding.Name = "Outstanding";
            this.Outstanding.ReadOnly = true;
            this.Outstanding.Width = 89;
            // 
            // Overdue
            // 
            this.Overdue.HeaderText = "Overdue";
            this.Overdue.Name = "Overdue";
            this.Overdue.ReadOnly = true;
            this.Overdue.Width = 73;
            // 
            // Rebate
            // 
            this.Rebate.HeaderText = "Rebate";
            this.Rebate.Name = "Rebate";
            this.Rebate.ReadOnly = true;
            this.Rebate.Width = 67;
            // 
            // Payment
            // 
            this.Payment.HeaderText = "Payment";
            this.Payment.Name = "Payment";
            this.Payment.Width = 73;
            // 
            // frmPayOffAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 419);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnPayment);
            this.Controls.Add(this.dgAccounts);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtValueRemaining);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNetValue);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmPayOffAccounts";
            this.Text = "frmPayOffAccounts";
            ((System.ComponentModel.ISupportInitialize)(this.dgAccounts)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNetValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtValueRemaining;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgAccounts;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Outstanding;
        private System.Windows.Forms.DataGridViewTextBoxColumn Overdue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rebate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Payment;
    }
}