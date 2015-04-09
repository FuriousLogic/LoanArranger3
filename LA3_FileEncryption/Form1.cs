using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Encryption;

namespace LA3_FileEncryption
{
    public partial class FrmEncrypt : Form
    {
        public FrmEncrypt()
        {
            InitializeComponent();
        }

        private void btnPlainText_Click(object sender, EventArgs e)
        {
            btnEncrypt.Enabled = false; 

            var ofd = new OpenFileDialog
            {
                Multiselect = false,
                Title = @"Choose file to encrypt"
            };
            var dialogResult = ofd.ShowDialog();
            if (dialogResult != DialogResult.OK) return;

            txtPlainTextFile.Text = ofd.FileName;
            btnEncrypt.Enabled = true;
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            var plainTextFilePath = txtPlainTextFile.Text;
            if (!File.Exists(plainTextFilePath)) return;
            if (txtKey.Text.Trim().Length == 0) return;

            var key = txtKey.Text.Trim();
            const string targetDirectory = @"C:\Users\Barry\Documents\My Dropbox\ClickOnceDeployment\LoanArrangerEncryptedData";
            var encryptedFilename = string.Format("LA3_Data_{0}.enc", DateTime.Now.ToString("yyyyMMddHHmmss"));
            var encryptFile = Symmetric.EncryptFile(plainTextFilePath, key, targetDirectory, encryptedFilename);

            txtKey.Text = "";
            MessageBox.Show(string.Format("File encrypted to [{0}]", encryptFile), @"Encrypted", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
