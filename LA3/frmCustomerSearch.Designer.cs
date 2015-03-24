namespace LA3
{
    partial class FrmCustomerSearch
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
            this.dgCustomers = new System.Windows.Forms.DataGridView();
            this.CustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Forename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PostCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgCustomers
            // 
            this.dgCustomers.AllowUserToAddRows = false;
            this.dgCustomers.AllowUserToDeleteRows = false;
            this.dgCustomers.AllowUserToOrderColumns = true;
            this.dgCustomers.AllowUserToResizeRows = false;
            this.dgCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCustomers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerID,
            this.Surname,
            this.Forename,
            this.Address,
            this.PostCode});
            this.dgCustomers.Location = new System.Drawing.Point(12, 12);
            this.dgCustomers.MultiSelect = false;
            this.dgCustomers.Name = "dgCustomers";
            this.dgCustomers.ReadOnly = true;
            this.dgCustomers.RowHeadersVisible = false;
            this.dgCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCustomers.Size = new System.Drawing.Size(476, 388);
            this.dgCustomers.TabIndex = 0;
            this.dgCustomers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCustomers_CellDoubleClick);
            this.dgCustomers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgCustomers_KeyDown);
            // 
            // CustomerID
            // 
            this.CustomerID.DataPropertyName = "Id";
            this.CustomerID.HeaderText = "CustomerID";
            this.CustomerID.Name = "CustomerID";
            this.CustomerID.ReadOnly = true;
            this.CustomerID.Visible = false;
            this.CustomerID.Width = 68;
            // 
            // Surname
            // 
            this.Surname.DataPropertyName = "Surname";
            this.Surname.HeaderText = "Surname";
            this.Surname.Name = "Surname";
            this.Surname.ReadOnly = true;
            this.Surname.Width = 74;
            // 
            // Forename
            // 
            this.Forename.DataPropertyName = "Forename";
            this.Forename.HeaderText = "Forename";
            this.Forename.Name = "Forename";
            this.Forename.ReadOnly = true;
            this.Forename.Width = 79;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            this.Address.Width = 70;
            // 
            // PostCode
            // 
            this.PostCode.DataPropertyName = "PostCode";
            this.PostCode.HeaderText = "Post Code";
            this.PostCode.Name = "PostCode";
            this.PostCode.ReadOnly = true;
            this.PostCode.Width = 81;
            // 
            // frmCustomerSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 412);
            this.Controls.Add(this.dgCustomers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmCustomerSearch";
            this.ShowInTaskbar = false;
            this.Text = "Customer Search";
            this.Load += new System.EventHandler(this.frmCustomerSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgCustomers;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Surname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Forename;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn PostCode;
    }
}