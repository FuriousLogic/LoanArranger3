namespace LA3
{
    partial class CntCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CntCustomer));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPostCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMaxLoan = new System.Windows.Forms.MaskedTextBox();
            this.cmbCollectionDay = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbCollector = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.epSurname = new System.Windows.Forms.ErrorProvider(this.components);
            this.epAddress = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtForename = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.epForename = new System.Windows.Forms.ErrorProvider(this.components);
            this.epCollectionDay = new System.Windows.Forms.ErrorProvider(this.components);
            this.epCollector = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnNewAccount = new System.Windows.Forms.Button();
            this.dgAccounts = new System.Windows.Forms.DataGridView();
            this.AccountID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Account = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Net = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gross = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Outstanding = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.epSurname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epForename)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCollectionDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCollector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAccounts)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Surname";
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(67, 4);
            this.txtSurname.MaxLength = 50;
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(220, 20);
            this.txtSurname.TabIndex = 1;
            this.txtSurname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSurname_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(67, 56);
            this.txtAddress.MaxLength = 255;
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAddress.Size = new System.Drawing.Size(220, 76);
            this.txtAddress.TabIndex = 3;
            // 
            // txtPostCode
            // 
            this.txtPostCode.Location = new System.Drawing.Point(67, 138);
            this.txtPostCode.Name = "txtPostCode";
            this.txtPostCode.Size = new System.Drawing.Size(100, 20);
            this.txtPostCode.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Post Code";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(67, 164);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(220, 20);
            this.txtPhoneNumber.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Phone";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(409, 110);
            this.txtNotes.MaxLength = 255;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(183, 74);
            this.txtNotes.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(347, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Notes";
            // 
            // txtStartDate
            // 
            this.txtStartDate.Location = new System.Drawing.Point(409, 4);
            this.txtStartDate.MaxLength = 50;
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.ReadOnly = true;
            this.txtStartDate.Size = new System.Drawing.Size(183, 20);
            this.txtStartDate.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(328, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Start Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(328, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Max Loan (£)";
            // 
            // txtMaxLoan
            // 
            this.txtMaxLoan.Location = new System.Drawing.Point(409, 30);
            this.txtMaxLoan.Mask = "99999";
            this.txtMaxLoan.Name = "txtMaxLoan";
            this.txtMaxLoan.Size = new System.Drawing.Size(74, 20);
            this.txtMaxLoan.TabIndex = 6;
            // 
            // cmbCollectionDay
            // 
            this.cmbCollectionDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCollectionDay.FormattingEnabled = true;
            this.cmbCollectionDay.Items.AddRange(new object[] {
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday"});
            this.cmbCollectionDay.Location = new System.Drawing.Point(409, 56);
            this.cmbCollectionDay.Name = "cmbCollectionDay";
            this.cmbCollectionDay.Size = new System.Drawing.Size(121, 21);
            this.cmbCollectionDay.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(328, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Collection Day";
            // 
            // cmbCollector
            // 
            this.cmbCollector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCollector.FormattingEnabled = true;
            this.cmbCollector.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.cmbCollector.Location = new System.Drawing.Point(409, 83);
            this.cmbCollector.Name = "cmbCollector";
            this.cmbCollector.Size = new System.Drawing.Size(121, 21);
            this.cmbCollector.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(328, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Collector";
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.Location = new System.Drawing.Point(517, 330);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 19;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(436, 330);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 20;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(355, 330);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 21;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // epSurname
            // 
            this.epSurname.ContainerControl = this;
            // 
            // epAddress
            // 
            this.epAddress.ContainerControl = this;
            // 
            // txtForename
            // 
            this.txtForename.Location = new System.Drawing.Point(67, 30);
            this.txtForename.MaxLength = 50;
            this.txtForename.Name = "txtForename";
            this.txtForename.Size = new System.Drawing.Size(220, 20);
            this.txtForename.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Forename";
            // 
            // epForename
            // 
            this.epForename.ContainerControl = this;
            // 
            // epCollectionDay
            // 
            this.epCollectionDay.ContainerControl = this;
            // 
            // epCollector
            // 
            this.epCollector.ContainerControl = this;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(293, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(22, 24);
            this.btnSearch.TabIndex = 24;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnNewAccount
            // 
            this.btnNewAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewAccount.Location = new System.Drawing.Point(266, 330);
            this.btnNewAccount.Name = "btnNewAccount";
            this.btnNewAccount.Size = new System.Drawing.Size(83, 23);
            this.btnNewAccount.TabIndex = 25;
            this.btnNewAccount.Text = "New Account";
            this.btnNewAccount.UseVisualStyleBackColor = true;
            this.btnNewAccount.Click += new System.EventHandler(this.btnNewAccount_Click);
            // 
            // dgAccounts
            // 
            this.dgAccounts.AllowUserToAddRows = false;
            this.dgAccounts.AllowUserToDeleteRows = false;
            this.dgAccounts.AllowUserToResizeRows = false;
            this.dgAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgAccounts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAccounts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AccountID,
            this.Account,
            this.StartDate,
            this.Net,
            this.Gross,
            this.Outstanding});
            this.dgAccounts.Location = new System.Drawing.Point(67, 190);
            this.dgAccounts.MultiSelect = false;
            this.dgAccounts.Name = "dgAccounts";
            this.dgAccounts.ReadOnly = true;
            this.dgAccounts.RowHeadersVisible = false;
            this.dgAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgAccounts.Size = new System.Drawing.Size(525, 134);
            this.dgAccounts.TabIndex = 26;
            this.dgAccounts.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgAccounts_CellMouseDoubleClick);
            // 
            // AccountID
            // 
            this.AccountID.DataPropertyName = "Id";
            this.AccountID.HeaderText = "AccountID";
            this.AccountID.Name = "AccountID";
            this.AccountID.ReadOnly = true;
            this.AccountID.Visible = false;
            // 
            // Account
            // 
            this.Account.DataPropertyName = "InvoiceCode";
            this.Account.HeaderText = "InvoiceCode";
            this.Account.Name = "Account";
            this.Account.ReadOnly = true;
            // 
            // StartDate
            // 
            this.StartDate.DataPropertyName = "StartDate";
            dataGridViewCellStyle1.Format = "dd MMM yyyy";
            this.StartDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.StartDate.HeaderText = "Started";
            this.StartDate.Name = "StartDate";
            this.StartDate.ReadOnly = true;
            // 
            // Net
            // 
            this.Net.DataPropertyName = "NetValue";
            dataGridViewCellStyle2.Format = "£0.00";
            this.Net.DefaultCellStyle = dataGridViewCellStyle2;
            this.Net.HeaderText = "Net";
            this.Net.Name = "Net";
            this.Net.ReadOnly = true;
            // 
            // Gross
            // 
            this.Gross.DataPropertyName = "GrossValue";
            dataGridViewCellStyle3.Format = "£0.00";
            this.Gross.DefaultCellStyle = dataGridViewCellStyle3;
            this.Gross.HeaderText = "Gross";
            this.Gross.Name = "Gross";
            this.Gross.ReadOnly = true;
            // 
            // Outstanding
            // 
            this.Outstanding.DataPropertyName = "Outstanding";
            dataGridViewCellStyle4.Format = "£0.00";
            this.Outstanding.DefaultCellStyle = dataGridViewCellStyle4;
            this.Outstanding.HeaderText = "Outstanding";
            this.Outstanding.Name = "Outstanding";
            this.Outstanding.ReadOnly = true;
            // 
            // cntCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.dgAccounts);
            this.Controls.Add(this.btnNewAccount);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtForename);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbCollector);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbCollectionDay);
            this.Controls.Add(this.txtMaxLoan);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtStartDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPostCode);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.label1);
            this.Name = "CntCustomer";
            this.Size = new System.Drawing.Size(603, 362);
            this.Load += new System.EventHandler(this.cntCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epSurname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epForename)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCollectionDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCollector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAccounts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtPostCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox txtMaxLoan;
        private System.Windows.Forms.ComboBox cmbCollectionDay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbCollector;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ErrorProvider epSurname;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtForename;
        private System.Windows.Forms.ErrorProvider epAddress;
        private System.Windows.Forms.ErrorProvider epForename;
        private System.Windows.Forms.ErrorProvider epCollectionDay;
        private System.Windows.Forms.ErrorProvider epCollector;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnNewAccount;
        private System.Windows.Forms.DataGridView dgAccounts;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Account;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Net;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gross;
        private System.Windows.Forms.DataGridViewTextBoxColumn Outstanding;
    }
}
