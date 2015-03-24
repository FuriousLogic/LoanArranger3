namespace LA3
{
    partial class FrmVersion
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
            this.txtVersions = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtVersions
            // 
            this.txtVersions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVersions.Location = new System.Drawing.Point(12, 12);
            this.txtVersions.Multiline = true;
            this.txtVersions.Name = "txtVersions";
            this.txtVersions.ReadOnly = true;
            this.txtVersions.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtVersions.Size = new System.Drawing.Size(534, 315);
            this.txtVersions.TabIndex = 0;
            this.txtVersions.WordWrap = false;
            // 
            // FrmVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 339);
            this.Controls.Add(this.txtVersions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmVersion";
            this.Text = "Versions";
            this.Load += new System.EventHandler(this.frmVersion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtVersions;
    }
}