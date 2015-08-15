using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Encryption;
using LA3.Model;

namespace LA3
{
    public partial class frmImportEncryptedDB : Form
    {
        public frmImportEncryptedDB()
        {
            InitializeComponent();
        }

        private void btnEncryptedDataFile_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                Multiselect = false
            };
            var dr = ofd.ShowDialog();
            if (dr != DialogResult.OK)
            {
                txtEncryptedDatabaseFile.Text = "";
                return;
            }

            txtEncryptedDatabaseFile.Text = ofd.FileName;
        }

        private void btnImportDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEncryptedDatabaseFile.Text.Trim().Length == 0) return;
                if (txtKey.Text.Trim().Length == 0) return;



                //*****************************************************************************
                //Does DB Exist?
                var canConnectToDb = true;
                var db = new LA_Entities();
                var serverName = db.Database.Connection.DataSource;
                var databaseName = db.Database.Connection.Database;
                var connectionString = string.Format("Server={0};Database=master;Trusted_Connection=True;", serverName);
                var sqlConnection = new SqlConnection(connectionString);
                try
                {
                    //var collectors = (from c in db.Collectors select c).ToList();
                    var sqlFindDb = string.Format("select count(*) from master.dbo.sysdatabases where name = '{0}'", databaseName);
                    var da = new SqlDataAdapter();
                    var sqlCommand = new SqlCommand(sqlFindDb, sqlConnection);
                    da.SelectCommand = sqlCommand;
                    var ds = new DataSet();
                    sqlConnection.Open();
                    da.Fill(ds);
                    sqlConnection.Close();
                    var sCount = ds.Tables[0].Rows[0][0].ToString();
                    int count;
                    if (!int.TryParse(sCount, out count)) canConnectToDb = false;
                    if (count == 0) canConnectToDb = false;
                }
                catch (Exception)
                {
                    canConnectToDb = false;
                }

                //Remove existing Db
                if (canConnectToDb)
                {
                    var sqlDropDatabase = string.Format("ALTER DATABASE {0} SET SINGLE_USER WITH ROLLBACK IMMEDIATE{1}drop database [{0}]", databaseName, Environment.NewLine);
                    var sqlCommand = new SqlCommand(sqlDropDatabase, sqlConnection);
                    sqlConnection.Open();
                    var executeNonQuery = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                //Create blank DB
                var sqlCreateDatabase = string.Format("create database [{0}]", databaseName);
                var command = new SqlCommand(sqlCreateDatabase, sqlConnection);
                sqlConnection.Open();
                command.ExecuteNonQuery();

                //Decrypt
                var encryptedFilepath = txtEncryptedDatabaseFile.Text.Trim();
                var key = txtKey.Text.Trim();
                var decryptFilePath = Symmetric.DecryptFile(encryptedFilepath, key, Path.GetTempPath());

                //Run script to rebuild db
                //var script = File.ReadAllText(scriptFileName);
                //SqlCommand command;
                sqlConnection.Open();
                var scriptBatch = new StringBuilder();
                using (var reader = new StreamReader(decryptFilePath))
                {
                    while (true)
                    {
                        var line = reader.ReadLine();
                        if (line == null) break;
                        //if (line.ToUpper().Contains(" ANSI_NULLS ")) continue;
                        if (line.TrimStart().StartsWith("--")) continue;
                        if (line.Equals("go", StringComparison.InvariantCultureIgnoreCase))
                        {
                            var s = scriptBatch.ToString();
                            command = new SqlCommand(s, sqlConnection);
                            command.ExecuteNonQuery();
                            scriptBatch.Clear();
                        }
                        else
                        {
                            if (line.Trim().Length > 0)
                                scriptBatch.AppendLine(line);
                        }
                    }
                }

                if (scriptBatch.ToString().Trim().Length > 0)
                {
                    command = new SqlCommand(scriptBatch.ToString(), sqlConnection);
                    command.ExecuteNonQuery();

                }
                sqlConnection.Close();

                MessageBox.Show(@"New Database Loaded");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
