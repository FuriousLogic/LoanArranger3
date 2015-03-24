namespace LA3
{
    partial class CntLastMonthsPayments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CntLastMonthsPayments));
            this.ddMonth = new System.Windows.Forms.ComboBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.lblWait = new System.Windows.Forms.Label();
            this.pbThrobber = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbThrobber)).BeginInit();
            this.SuspendLayout();
            // 
            // ddMonth
            // 
            this.ddMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddMonth.FormattingEnabled = true;
            this.ddMonth.Location = new System.Drawing.Point(4, 4);
            this.ddMonth.Name = "ddMonth";
            this.ddMonth.Size = new System.Drawing.Size(143, 21);
            this.ddMonth.TabIndex = 0;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(4, 32);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(143, 23);
            this.btnShow.TabIndex = 1;
            this.btnShow.Text = "Show Payments";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // lblWait
            // 
            this.lblWait.AutoSize = true;
            this.lblWait.Location = new System.Drawing.Point(32, 73);
            this.lblWait.Name = "lblWait";
            this.lblWait.Size = new System.Drawing.Size(73, 13);
            this.lblWait.TabIndex = 2;
            this.lblWait.Text = "Please Wait...";
            this.lblWait.Visible = false;
            // 
            // pbThrobber
            // 
            this.pbThrobber.Image = ((System.Drawing.Image)(resources.GetObject("pbThrobber.Image")));
            this.pbThrobber.Location = new System.Drawing.Point(35, 98);
            this.pbThrobber.Name = "pbThrobber";
            this.pbThrobber.Size = new System.Drawing.Size(56, 21);
            this.pbThrobber.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbThrobber.TabIndex = 3;
            this.pbThrobber.TabStop = false;
            this.pbThrobber.Visible = false;
            // 
            // cntLastMonthsPayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbThrobber);
            this.Controls.Add(this.lblWait);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.ddMonth);
            this.Name = "CntLastMonthsPayments";
            this.Size = new System.Drawing.Size(150, 130);
            this.Load += new System.EventHandler(this.cntLastMonthsPayments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbThrobber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddMonth;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Label lblWait;
        private System.Windows.Forms.PictureBox pbThrobber;
    }
}
