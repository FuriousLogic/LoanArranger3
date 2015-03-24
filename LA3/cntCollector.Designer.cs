namespace LA3
{
    partial class CntCollector
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
            this.lstCollectors = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCollectorName = new System.Windows.Forms.TextBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.epName = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnDelete = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumberOfCustomers = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.epName)).BeginInit();
            this.SuspendLayout();
            // 
            // lstCollectors
            // 
            this.lstCollectors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lstCollectors.FormattingEnabled = true;
            this.lstCollectors.Location = new System.Drawing.Point(3, 3);
            this.lstCollectors.Name = "lstCollectors";
            this.lstCollectors.Size = new System.Drawing.Size(170, 238);
            this.lstCollectors.TabIndex = 0;
            this.lstCollectors.SelectedIndexChanged += new System.EventHandler(this.lstCollectors_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(178, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Notes";
            // 
            // txtCollectorName
            // 
            this.txtCollectorName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCollectorName.Location = new System.Drawing.Point(220, 3);
            this.txtCollectorName.MaxLength = 50;
            this.txtCollectorName.Name = "txtCollectorName";
            this.txtCollectorName.Size = new System.Drawing.Size(188, 20);
            this.txtCollectorName.TabIndex = 3;
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotes.Location = new System.Drawing.Point(220, 29);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(356, 101);
            this.txtNotes.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(501, 218);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(420, 218);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // epName
            // 
            this.epName.ContainerControl = this;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(339, 218);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(178, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Number of customers";
            // 
            // txtNumberOfCustomers
            // 
            this.txtNumberOfCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumberOfCustomers.Location = new System.Drawing.Point(291, 136);
            this.txtNumberOfCustomers.MaxLength = 50;
            this.txtNumberOfCustomers.Name = "txtNumberOfCustomers";
            this.txtNumberOfCustomers.ReadOnly = true;
            this.txtNumberOfCustomers.Size = new System.Drawing.Size(43, 20);
            this.txtNumberOfCustomers.TabIndex = 9;
            // 
            // cntCollector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtNumberOfCustomers);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.txtCollectorName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstCollectors);
            this.Name = "CntCollector";
            this.Size = new System.Drawing.Size(600, 258);
            this.Load += new System.EventHandler(this.Collector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epName)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstCollectors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCollectorName;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ErrorProvider epName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtNumberOfCustomers;
        private System.Windows.Forms.Label label3;
    }
}
