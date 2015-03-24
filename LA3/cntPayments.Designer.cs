namespace LA3
{
    partial class CntPayments
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CntPayments));
            this.dgPayments = new System.Windows.Forms.DataGridView();
            this.AccountID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Outstanding = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpectedPayment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Payment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentDue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCollector = new System.Windows.Forms.ComboBox();
            this.dtCollection = new System.Windows.Forms.DateTimePicker();
            this.btnAccept = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAmountCollected = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.epAmountProvided = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblTotal = new System.Windows.Forms.Label();
            this.picLoader = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgPayments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAmountProvided)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            this.SuspendLayout();
            // 
            // dgPayments
            // 
            this.dgPayments.AllowUserToAddRows = false;
            this.dgPayments.AllowUserToDeleteRows = false;
            this.dgPayments.AllowUserToResizeRows = false;
            this.dgPayments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPayments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPayments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AccountID,
            this.InvoiceCode,
            this.Customer,
            this.Surname,
            this.Address,
            this.NetValue,
            this.Outstanding,
            this.ExpectedPayment,
            this.Payment,
            this.PaymentDue});
            this.dgPayments.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgPayments.Location = new System.Drawing.Point(3, 33);
            this.dgPayments.MultiSelect = false;
            this.dgPayments.Name = "dgPayments";
            this.dgPayments.RowHeadersVisible = false;
            this.dgPayments.Size = new System.Drawing.Size(691, 370);
            this.dgPayments.TabIndex = 0;
            this.dgPayments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPayments_CellContentClick);
            this.dgPayments.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPayments_CellEnter);
            this.dgPayments.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPayments_CellLeave);
            this.dgPayments.Sorted += new System.EventHandler(this.dgPayments_Sorted);
            // 
            // AccountID
            // 
            this.AccountID.DataPropertyName = "accountID";
            this.AccountID.HeaderText = "AccountID";
            this.AccountID.Name = "AccountID";
            this.AccountID.Visible = false;
            this.AccountID.Width = 64;
            // 
            // InvoiceCode
            // 
            this.InvoiceCode.DataPropertyName = "InvoiceCode";
            this.InvoiceCode.HeaderText = "Account Code";
            this.InvoiceCode.Name = "InvoiceCode";
            this.InvoiceCode.ReadOnly = true;
            // 
            // Customer
            // 
            this.Customer.DataPropertyName = "forename";
            this.Customer.HeaderText = "Forename";
            this.Customer.Name = "Customer";
            this.Customer.ReadOnly = true;
            this.Customer.Width = 79;
            // 
            // Surname
            // 
            this.Surname.DataPropertyName = "surname";
            this.Surname.HeaderText = "Surname";
            this.Surname.Name = "Surname";
            this.Surname.ReadOnly = true;
            this.Surname.Width = 74;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "address";
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            this.Address.Width = 70;
            // 
            // NetValue
            // 
            this.NetValue.DataPropertyName = "Net";
            dataGridViewCellStyle1.Format = "£0.00";
            this.NetValue.DefaultCellStyle = dataGridViewCellStyle1;
            this.NetValue.HeaderText = "Net Value";
            this.NetValue.Name = "NetValue";
            this.NetValue.ReadOnly = true;
            this.NetValue.Width = 79;
            // 
            // Outstanding
            // 
            this.Outstanding.DataPropertyName = "Outstanding";
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.Outstanding.DefaultCellStyle = dataGridViewCellStyle2;
            this.Outstanding.HeaderText = "Outstanding";
            this.Outstanding.Name = "Outstanding";
            this.Outstanding.ReadOnly = true;
            this.Outstanding.Width = 89;
            // 
            // ExpectedPayment
            // 
            this.ExpectedPayment.DataPropertyName = "expectedPayment";
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.ExpectedPayment.DefaultCellStyle = dataGridViewCellStyle3;
            this.ExpectedPayment.HeaderText = "Expected £";
            this.ExpectedPayment.Name = "ExpectedPayment";
            this.ExpectedPayment.ReadOnly = true;
            this.ExpectedPayment.Width = 86;
            // 
            // Payment
            // 
            this.Payment.DataPropertyName = "amountpaid";
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.Payment.DefaultCellStyle = dataGridViewCellStyle4;
            this.Payment.HeaderText = "Payment";
            this.Payment.Name = "Payment";
            this.Payment.Width = 73;
            // 
            // PaymentDue
            // 
            this.PaymentDue.DataPropertyName = "nextPayment";
            dataGridViewCellStyle5.Format = "dd/MMM/yyyy";
            dataGridViewCellStyle5.NullValue = null;
            this.PaymentDue.DefaultCellStyle = dataGridViewCellStyle5;
            this.PaymentDue.HeaderText = "Payment Due";
            this.PaymentDue.Name = "PaymentDue";
            this.PaymentDue.ReadOnly = true;
            this.PaymentDue.Width = 96;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Collector";
            // 
            // cmbCollector
            // 
            this.cmbCollector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCollector.FormattingEnabled = true;
            this.cmbCollector.Location = new System.Drawing.Point(60, 4);
            this.cmbCollector.Name = "cmbCollector";
            this.cmbCollector.Size = new System.Drawing.Size(133, 21);
            this.cmbCollector.TabIndex = 2;
            this.cmbCollector.SelectedIndexChanged += new System.EventHandler(this.cmbCollector_SelectedIndexChanged);
            // 
            // dtCollection
            // 
            this.dtCollection.CustomFormat = "ddd: dd MMM yyyy";
            this.dtCollection.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtCollection.Location = new System.Drawing.Point(200, 4);
            this.dtCollection.Name = "dtCollection";
            this.dtCollection.Size = new System.Drawing.Size(164, 20);
            this.dtCollection.TabIndex = 3;
            this.dtCollection.ValueChanged += new System.EventHandler(this.dtCollection_ValueChanged);
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.Location = new System.Drawing.Point(619, 431);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 4;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.PaleGreen;
            this.panel2.Location = new System.Drawing.Point(9, 437);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(20, 20);
            this.panel2.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 443);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Paid";
            // 
            // txtAmountCollected
            // 
            this.txtAmountCollected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAmountCollected.Location = new System.Drawing.Point(484, 434);
            this.txtAmountCollected.Name = "txtAmountCollected";
            this.txtAmountCollected.Size = new System.Drawing.Size(100, 20);
            this.txtAmountCollected.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(388, 437);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Amount Collected";
            // 
            // epAmountProvided
            // 
            this.epAmountProvided.ContainerControl = this;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotal.Location = new System.Drawing.Point(484, 411);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(100, 20);
            this.lblTotal.TabIndex = 11;
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picLoader
            // 
            this.picLoader.Image = ((System.Drawing.Image)(resources.GetObject("picLoader.Image")));
            this.picLoader.Location = new System.Drawing.Point(391, 4);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(221, 21);
            this.picLoader.TabIndex = 12;
            this.picLoader.TabStop = false;
            this.picLoader.Visible = false;
            // 
            // CntPayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picLoader);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAmountCollected);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.dtCollection);
            this.Controls.Add(this.cmbCollector);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgPayments);
            this.Name = "CntPayments";
            this.Size = new System.Drawing.Size(700, 457);
            this.Load += new System.EventHandler(this.cntPayments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPayments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAmountProvided)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgPayments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCollector;
        private System.Windows.Forms.DateTimePicker dtCollection;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAmountCollected;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider epAmountProvided;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountID;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Surname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Outstanding;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpectedPayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Payment;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentDue;
        private System.Windows.Forms.PictureBox picLoader;
    }
}
