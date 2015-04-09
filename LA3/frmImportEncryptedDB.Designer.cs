namespace LA3
{
    partial class frmImportEncryptedDB
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
            this.txtEncryptedDatabaseFile = new System.Windows.Forms.TextBox();
            this.btnEncryptedDataFile = new System.Windows.Forms.Button();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnImportDatabase = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Encrypted Data File";
            // 
            // txtEncryptedDatabaseFile
            // 
            this.txtEncryptedDatabaseFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEncryptedDatabaseFile.Location = new System.Drawing.Point(119, 10);
            this.txtEncryptedDatabaseFile.Name = "txtEncryptedDatabaseFile";
            this.txtEncryptedDatabaseFile.ReadOnly = true;
            this.txtEncryptedDatabaseFile.Size = new System.Drawing.Size(339, 20);
            this.txtEncryptedDatabaseFile.TabIndex = 1;
            // 
            // btnEncryptedDataFile
            // 
            this.btnEncryptedDataFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEncryptedDataFile.Location = new System.Drawing.Point(464, 8);
            this.btnEncryptedDataFile.Name = "btnEncryptedDataFile";
            this.btnEncryptedDataFile.Size = new System.Drawing.Size(28, 23);
            this.btnEncryptedDataFile.TabIndex = 2;
            this.btnEncryptedDataFile.Text = "...";
            this.btnEncryptedDataFile.UseVisualStyleBackColor = true;
            this.btnEncryptedDataFile.Click += new System.EventHandler(this.btnEncryptedDataFile_Click);
            // 
            // txtKey
            // 
            this.txtKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKey.Location = new System.Drawing.Point(119, 37);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(339, 20);
            this.txtKey.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Key";
            // 
            // btnImportDatabase
            // 
            this.btnImportDatabase.Location = new System.Drawing.Point(119, 63);
            this.btnImportDatabase.Name = "btnImportDatabase";
            this.btnImportDatabase.Size = new System.Drawing.Size(116, 23);
            this.btnImportDatabase.TabIndex = 5;
            this.btnImportDatabase.Text = "Import Database";
            this.btnImportDatabase.UseVisualStyleBackColor = true;
            this.btnImportDatabase.Click += new System.EventHandler(this.btnImportDatabase_Click);
            // 
            // frmImportEncryptedDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 198);
            this.Controls.Add(this.btnImportDatabase);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.btnEncryptedDataFile);
            this.Controls.Add(this.txtEncryptedDatabaseFile);
            this.Controls.Add(this.label1);
            this.Name = "frmImportEncryptedDB";
            this.Text = "Import Encrypted DB";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEncryptedDatabaseFile;
        private System.Windows.Forms.Button btnEncryptedDataFile;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnImportDatabase;
    }
}