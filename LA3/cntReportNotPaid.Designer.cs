namespace LA3
{
    partial class CntReportNotPaid
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
            this.txtWeeks = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtWeeks
            // 
            this.txtWeeks.Location = new System.Drawing.Point(104, 3);
            this.txtWeeks.Name = "txtWeeks";
            this.txtWeeks.Size = new System.Drawing.Size(100, 20);
            this.txtWeeks.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Number of Weeks";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(104, 30);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cntReportNotPaid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtWeeks);
            this.Name = "CntReportNotPaid";
            this.Size = new System.Drawing.Size(290, 95);
            this.Load += new System.EventHandler(this.cntReportNotPaid_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtWeeks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
    }
}
