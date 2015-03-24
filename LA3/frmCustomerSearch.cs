using System;
using System.Linq;
using System.Windows.Forms;

using LA3.Model;

namespace LA3
{
    public partial class FrmCustomerSearch : Form
    {
        private int _currentCustomerID;
        private readonly LA_Entities _db = new LA_Entities();

        public int CurrentCustomerID
        {
            get { return _currentCustomerID; }
        }


        public FrmCustomerSearch(string surname)
        {
            InitializeComponent();

            var customers = _db.Customers.Where(c => c.Surname.Contains(surname)).ToList();
            dgCustomers.AutoGenerateColumns = false;
            dgCustomers.DataSource = customers;

            ShowDialog();
        }

        private void frmCustomerSearch_Load(object sender, EventArgs e)
        {

        }

        private void dgCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _currentCustomerID = (int)dgCustomers.Rows[e.RowIndex].Cells[0].Value;
            Hide();
        }

        private void dgCustomers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Return) return;
            if (dgCustomers.SelectedRows.Count != 1) return;
            _currentCustomerID = (int)dgCustomers.SelectedRows[0].Cells[0].Value;
            //currentCustomerID = (int)dgCustomers.Rows[dgCustomers.SelectedRows[0].Index].Cells[0].Value;
            Hide();
        }
    }
}