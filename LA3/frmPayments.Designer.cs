namespace LA3
{
    partial class FrmPayments
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
            this.dgPayments = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Payment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sundry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaidBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgPayments)).BeginInit();
            this.SuspendLayout();
            // 
            // dgPayments
            // 
            this.dgPayments.AllowUserToAddRows = false;
            this.dgPayments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPayments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPayments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.Payment,
            this.Sundry,
            this.PaidBy});
            this.dgPayments.Location = new System.Drawing.Point(13, 13);
            this.dgPayments.Name = "dgPayments";
            this.dgPayments.RowHeadersVisible = false;
            this.dgPayments.Size = new System.Drawing.Size(556, 379);
            this.dgPayments.TabIndex = 0;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 55;
            // 
            // Payment
            // 
            this.Payment.HeaderText = "Payment";
            this.Payment.Name = "Payment";
            this.Payment.ReadOnly = true;
            this.Payment.Width = 73;
            // 
            // Sundry
            // 
            this.Sundry.HeaderText = "Sundry";
            this.Sundry.Name = "Sundry";
            this.Sundry.ReadOnly = true;
            this.Sundry.Width = 65;
            // 
            // PaidBy
            // 
            this.PaidBy.HeaderText = "Paid By";
            this.PaidBy.Name = "PaidBy";
            this.PaidBy.ReadOnly = true;
            this.PaidBy.Width = 68;
            // 
            // FrmPayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 404);
            this.Controls.Add(this.dgPayments);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmPayments";
            this.Text = "Payments";
            this.Load += new System.EventHandler(this.frmPayments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPayments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgPayments;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Payment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sundry;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaidBy;
    }
}