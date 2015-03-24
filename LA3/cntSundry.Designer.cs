namespace LA3
{
    partial class CntSundry
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CntSundry));
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.cmbAccounts = new System.Windows.Forms.ComboBox();
            this.txtNetValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLeftToPay = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCreated = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOverdue = new System.Windows.Forms.TextBox();
            this.txtSundry = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnPaySundry = new System.Windows.Forms.Button();
            this.epSundryAmount = new System.Windows.Forms.ErrorProvider(this.components);
            this.dtPayment = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSummaryCustomer = new System.Windows.Forms.TextBox();
            this.txtSummaryAccount = new System.Windows.Forms.TextBox();
            this.txtSummaryDate = new System.Windows.Forms.TextBox();
            this.txtSummaryPayment = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.epSundryAmount)).BeginInit();
            this.pnlSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Customers";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(7, 54);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(292, 20);
            this.txtCustomer.TabIndex = 3;
            // 
            // cmbAccounts
            // 
            this.cmbAccounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccounts.FormattingEnabled = true;
            this.cmbAccounts.Location = new System.Drawing.Point(7, 81);
            this.cmbAccounts.Name = "cmbAccounts";
            this.cmbAccounts.Size = new System.Drawing.Size(292, 21);
            this.cmbAccounts.TabIndex = 4;
            this.cmbAccounts.SelectedIndexChanged += new System.EventHandler(this.cmbAccounts_SelectedIndexChanged);
            // 
            // txtNetValue
            // 
            this.txtNetValue.Location = new System.Drawing.Point(199, 108);
            this.txtNetValue.Name = "txtNetValue";
            this.txtNetValue.ReadOnly = true;
            this.txtNetValue.Size = new System.Drawing.Size(100, 20);
            this.txtNetValue.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Net Value";
            // 
            // txtLeftToPay
            // 
            this.txtLeftToPay.Location = new System.Drawing.Point(199, 134);
            this.txtLeftToPay.Name = "txtLeftToPay";
            this.txtLeftToPay.ReadOnly = true;
            this.txtLeftToPay.Size = new System.Drawing.Size(100, 20);
            this.txtLeftToPay.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Left To Pay";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Created";
            // 
            // txtCreated
            // 
            this.txtCreated.Location = new System.Drawing.Point(199, 160);
            this.txtCreated.Name = "txtCreated";
            this.txtCreated.ReadOnly = true;
            this.txtCreated.Size = new System.Drawing.Size(100, 20);
            this.txtCreated.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Overdue";
            // 
            // txtOverdue
            // 
            this.txtOverdue.Location = new System.Drawing.Point(199, 186);
            this.txtOverdue.Name = "txtOverdue";
            this.txtOverdue.ReadOnly = true;
            this.txtOverdue.Size = new System.Drawing.Size(100, 20);
            this.txtOverdue.TabIndex = 11;
            // 
            // txtSundry
            // 
            this.txtSundry.Location = new System.Drawing.Point(199, 238);
            this.txtSundry.Name = "txtSundry";
            this.txtSundry.Size = new System.Drawing.Size(100, 20);
            this.txtSundry.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Sundry Amount";
            // 
            // btnPaySundry
            // 
            this.btnPaySundry.Enabled = false;
            this.btnPaySundry.Location = new System.Drawing.Point(223, 265);
            this.btnPaySundry.Name = "btnPaySundry";
            this.btnPaySundry.Size = new System.Drawing.Size(75, 23);
            this.btnPaySundry.TabIndex = 15;
            this.btnPaySundry.Text = "Pay Sundry";
            this.btnPaySundry.UseVisualStyleBackColor = true;
            this.btnPaySundry.Click += new System.EventHandler(this.btnPaySundry_Click);
            // 
            // epSundryAmount
            // 
            this.epSundryAmount.ContainerControl = this;
            // 
            // dtPayment
            // 
            this.dtPayment.Location = new System.Drawing.Point(130, 212);
            this.dtPayment.Name = "dtPayment";
            this.dtPayment.Size = new System.Drawing.Size(169, 20);
            this.dtPayment.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 219);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Payment Date";
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(7, 28);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(264, 20);
            this.txtSurname.TabIndex = 18;
            this.txtSurname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSurname_KeyPress);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(277, 25);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(22, 24);
            this.btnSearch.TabIndex = 25;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pnlSummary
            // 
            this.pnlSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSummary.Controls.Add(this.label12);
            this.pnlSummary.Controls.Add(this.txtSummaryPayment);
            this.pnlSummary.Controls.Add(this.txtSummaryDate);
            this.pnlSummary.Controls.Add(this.txtSummaryAccount);
            this.pnlSummary.Controls.Add(this.txtSummaryCustomer);
            this.pnlSummary.Controls.Add(this.label11);
            this.pnlSummary.Controls.Add(this.label10);
            this.pnlSummary.Controls.Add(this.label9);
            this.pnlSummary.Controls.Add(this.label8);
            this.pnlSummary.Location = new System.Drawing.Point(314, 108);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(290, 150);
            this.pnlSummary.TabIndex = 26;
            this.pnlSummary.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Customer:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Account:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Date:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 107);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Payment:";
            // 
            // txtSummaryCustomer
            // 
            this.txtSummaryCustomer.Location = new System.Drawing.Point(82, 29);
            this.txtSummaryCustomer.Name = "txtSummaryCustomer";
            this.txtSummaryCustomer.ReadOnly = true;
            this.txtSummaryCustomer.Size = new System.Drawing.Size(204, 20);
            this.txtSummaryCustomer.TabIndex = 4;
            // 
            // txtSummaryAccount
            // 
            this.txtSummaryAccount.Location = new System.Drawing.Point(82, 52);
            this.txtSummaryAccount.Name = "txtSummaryAccount";
            this.txtSummaryAccount.ReadOnly = true;
            this.txtSummaryAccount.Size = new System.Drawing.Size(204, 20);
            this.txtSummaryAccount.TabIndex = 5;
            // 
            // txtSummaryDate
            // 
            this.txtSummaryDate.Location = new System.Drawing.Point(82, 78);
            this.txtSummaryDate.Name = "txtSummaryDate";
            this.txtSummaryDate.ReadOnly = true;
            this.txtSummaryDate.Size = new System.Drawing.Size(204, 20);
            this.txtSummaryDate.TabIndex = 6;
            // 
            // txtSummaryPayment
            // 
            this.txtSummaryPayment.Location = new System.Drawing.Point(82, 104);
            this.txtSummaryPayment.Name = "txtSummaryPayment";
            this.txtSummaryPayment.ReadOnly = true;
            this.txtSummaryPayment.Size = new System.Drawing.Size(204, 20);
            this.txtSummaryPayment.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(118, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "Last Payment Made";
            // 
            // CntSundry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtPayment);
            this.Controls.Add(this.btnPaySundry);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSundry);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtOverdue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCreated);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLeftToPay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNetValue);
            this.Controls.Add(this.cmbAccounts);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.label1);
            this.Name = "CntSundry";
            this.Size = new System.Drawing.Size(616, 303);
            this.Load += new System.EventHandler(this.cntSundry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epSundryAmount)).EndInit();
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummary.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.ComboBox cmbAccounts;
        private System.Windows.Forms.TextBox txtNetValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLeftToPay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCreated;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOverdue;
        private System.Windows.Forms.TextBox txtSundry;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnPaySundry;
        private System.Windows.Forms.ErrorProvider epSundryAmount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtPayment;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSummaryPayment;
        private System.Windows.Forms.TextBox txtSummaryDate;
        private System.Windows.Forms.TextBox txtSummaryAccount;
        private System.Windows.Forms.TextBox txtSummaryCustomer;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;

    }
}
