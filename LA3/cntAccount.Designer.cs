namespace LA3
{
    partial class CntAccount
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtInvoiceCode = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCustomerNotes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNetValue = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtInterest = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.udPaymentPeriod = new System.Windows.Forms.NumericUpDown();
            this.cmbPeriod = new System.Windows.Forms.ComboBox();
            this.txtOutstanding = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPayment = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtRebate = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtOverdue = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtGrossValue = new System.Windows.Forms.TextBox();
            this.dtNextPayment = new System.Windows.Forms.DateTimePicker();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnPayments = new System.Windows.Forms.Button();
            this.btnSundry = new System.Windows.Forms.Button();
            this.btnChart = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.udPaymentPeriod)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Invoice Code";
            // 
            // txtInvoiceCode
            // 
            this.txtInvoiceCode.Location = new System.Drawing.Point(91, 4);
            this.txtInvoiceCode.Name = "txtInvoiceCode";
            this.txtInvoiceCode.Size = new System.Drawing.Size(100, 20);
            this.txtInvoiceCode.TabIndex = 1;
            this.txtInvoiceCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInvoiceCode_KeyPress);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(91, 31);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(207, 20);
            this.txtCustomerName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(91, 57);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(207, 66);
            this.txtAddress.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Address";
            // 
            // txtCustomerNotes
            // 
            this.txtCustomerNotes.Location = new System.Drawing.Point(91, 155);
            this.txtCustomerNotes.Multiline = true;
            this.txtCustomerNotes.Name = "txtCustomerNotes";
            this.txtCustomerNotes.Size = new System.Drawing.Size(207, 54);
            this.txtCustomerNotes.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Customer Notes";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(91, 215);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(207, 54);
            this.txtNotes.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Account Notes";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(91, 129);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.ReadOnly = true;
            this.txtPhoneNumber.Size = new System.Drawing.Size(207, 20);
            this.txtPhoneNumber.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Phone";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(334, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Created";
            // 
            // txtStartDate
            // 
            this.txtStartDate.Location = new System.Drawing.Point(413, 4);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.ReadOnly = true;
            this.txtStartDate.Size = new System.Drawing.Size(143, 20);
            this.txtStartDate.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(334, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Net Value";
            // 
            // txtNetValue
            // 
            this.txtNetValue.Location = new System.Drawing.Point(413, 30);
            this.txtNetValue.Name = "txtNetValue";
            this.txtNetValue.Size = new System.Drawing.Size(143, 20);
            this.txtNetValue.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(334, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Gross Value";
            // 
            // txtInterest
            // 
            this.txtInterest.Location = new System.Drawing.Point(413, 56);
            this.txtInterest.Name = "txtInterest";
            this.txtInterest.Size = new System.Drawing.Size(143, 20);
            this.txtInterest.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(334, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Interest";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(334, 110);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Pay every";
            // 
            // udPaymentPeriod
            // 
            this.udPaymentPeriod.Location = new System.Drawing.Point(413, 108);
            this.udPaymentPeriod.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.udPaymentPeriod.Name = "udPaymentPeriod";
            this.udPaymentPeriod.Size = new System.Drawing.Size(34, 20);
            this.udPaymentPeriod.TabIndex = 6;
            // 
            // cmbPeriod
            // 
            this.cmbPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriod.FormattingEnabled = true;
            this.cmbPeriod.Items.AddRange(new object[] {
            "Week(s)",
            "Month(s)"});
            this.cmbPeriod.Location = new System.Drawing.Point(460, 107);
            this.cmbPeriod.Name = "cmbPeriod";
            this.cmbPeriod.Size = new System.Drawing.Size(96, 21);
            this.cmbPeriod.TabIndex = 7;
            // 
            // txtOutstanding
            // 
            this.txtOutstanding.Location = new System.Drawing.Point(413, 135);
            this.txtOutstanding.Name = "txtOutstanding";
            this.txtOutstanding.ReadOnly = true;
            this.txtOutstanding.Size = new System.Drawing.Size(143, 20);
            this.txtOutstanding.TabIndex = 23;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(334, 138);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "Outstanding";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(334, 165);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 13);
            this.label13.TabIndex = 26;
            this.label13.Text = "Payment";
            // 
            // txtPayment
            // 
            this.txtPayment.Location = new System.Drawing.Point(413, 161);
            this.txtPayment.Name = "txtPayment";
            this.txtPayment.Size = new System.Drawing.Size(143, 20);
            this.txtPayment.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(334, 190);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 13);
            this.label14.TabIndex = 28;
            this.label14.Text = "Next Payment";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(334, 216);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 13);
            this.label15.TabIndex = 30;
            this.label15.Text = "Rebate";
            // 
            // txtRebate
            // 
            this.txtRebate.Location = new System.Drawing.Point(413, 213);
            this.txtRebate.Name = "txtRebate";
            this.txtRebate.ReadOnly = true;
            this.txtRebate.Size = new System.Drawing.Size(143, 20);
            this.txtRebate.TabIndex = 29;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(334, 242);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 13);
            this.label16.TabIndex = 32;
            this.label16.Text = "Overdue";
            // 
            // txtOverdue
            // 
            this.txtOverdue.Location = new System.Drawing.Point(413, 239);
            this.txtOverdue.Name = "txtOverdue";
            this.txtOverdue.ReadOnly = true;
            this.txtOverdue.Size = new System.Drawing.Size(143, 20);
            this.txtOverdue.TabIndex = 31;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(480, 275);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtGrossValue
            // 
            this.txtGrossValue.Location = new System.Drawing.Point(413, 81);
            this.txtGrossValue.Name = "txtGrossValue";
            this.txtGrossValue.ReadOnly = true;
            this.txtGrossValue.Size = new System.Drawing.Size(143, 20);
            this.txtGrossValue.TabIndex = 5;
            // 
            // dtNextPayment
            // 
            this.dtNextPayment.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNextPayment.Location = new System.Drawing.Point(413, 187);
            this.dtNextPayment.Name = "dtNextPayment";
            this.dtNextPayment.Size = new System.Drawing.Size(143, 20);
            this.dtNextPayment.TabIndex = 8;
            this.dtNextPayment.ValueChanged += new System.EventHandler(this.dtNextPayment_ValueChanged);
            // 
            // btnCustomer
            // 
            this.btnCustomer.Location = new System.Drawing.Point(400, 275);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(75, 23);
            this.btnCustomer.TabIndex = 11;
            this.btnCustomer.Text = "Customer";
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(319, 275);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 33;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(157, 275);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 34;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnPayments
            // 
            this.btnPayments.Location = new System.Drawing.Point(238, 275);
            this.btnPayments.Name = "btnPayments";
            this.btnPayments.Size = new System.Drawing.Size(75, 23);
            this.btnPayments.TabIndex = 35;
            this.btnPayments.Text = "Payments";
            this.btnPayments.UseVisualStyleBackColor = true;
            this.btnPayments.Click += new System.EventHandler(this.btnPayments_Click);
            // 
            // btnSundry
            // 
            this.btnSundry.Location = new System.Drawing.Point(76, 275);
            this.btnSundry.Name = "btnSundry";
            this.btnSundry.Size = new System.Drawing.Size(75, 23);
            this.btnSundry.TabIndex = 36;
            this.btnSundry.Text = "Sundry";
            this.btnSundry.UseVisualStyleBackColor = true;
            this.btnSundry.Click += new System.EventHandler(this.btnSundry_Click);
            // 
            // btnChart
            // 
            this.btnChart.Location = new System.Drawing.Point(3, 275);
            this.btnChart.Name = "btnChart";
            this.btnChart.Size = new System.Drawing.Size(67, 23);
            this.btnChart.TabIndex = 37;
            this.btnChart.Text = "Chart";
            this.btnChart.UseVisualStyleBackColor = true;
            this.btnChart.Click += new System.EventHandler(this.btnChart_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.DarkRed;
            this.lblStatus.Location = new System.Drawing.Point(198, 7);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(35, 13);
            this.lblStatus.TabIndex = 38;
            this.lblStatus.Text = "status";
            this.lblStatus.Visible = false;
            // 
            // CntAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnChart);
            this.Controls.Add(this.btnSundry);
            this.Controls.Add(this.btnPayments);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCustomer);
            this.Controls.Add(this.dtNextPayment);
            this.Controls.Add(this.txtGrossValue);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtOverdue);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtRebate);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtPayment);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtOutstanding);
            this.Controls.Add(this.cmbPeriod);
            this.Controls.Add(this.udPaymentPeriod);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtInterest);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtNetValue);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtStartDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCustomerNotes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.txtInvoiceCode);
            this.Controls.Add(this.label1);
            this.Name = "CntAccount";
            this.Size = new System.Drawing.Size(581, 308);
            this.Load += new System.EventHandler(this.cntAccount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.udPaymentPeriod)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInvoiceCode;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCustomerNotes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNetValue;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtInterest;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown udPaymentPeriod;
        private System.Windows.Forms.ComboBox cmbPeriod;
        private System.Windows.Forms.TextBox txtOutstanding;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtPayment;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtRebate;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtOverdue;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtGrossValue;
        private System.Windows.Forms.DateTimePicker dtNextPayment;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnPayments;
        private System.Windows.Forms.Button btnSundry;
        private System.Windows.Forms.Button btnChart;
        private System.Windows.Forms.Label lblStatus;
    }
}
