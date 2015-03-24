using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
 
using LA3.Model;

namespace LA3
{
    public partial class CntCollector : UserControl
    {
        public event DelShowStatusText EvShowStatusText;
        private readonly LA_Entities _db = new LA_Entities();

        public CntCollector()
        {
            InitializeComponent();
        }

        private void Collector_Load(object sender, EventArgs e)
        {
            PopulateList();
        }

        private void PopulateList()
        {
            lstCollectors.DataSource = null;
            lstCollectors.Items.Clear();
            IList<Collector> collectors = (from c in _db.Collectors orderby c.CollectorName select c).ToList();
            lstCollectors.DataSource = collectors;
            lstCollectors.DisplayMember = "CollectorName";
            ClearFields();
        }

        private void lstCollectors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCollectors.SelectedIndex == -1)
                return;

            txtCollectorName.Text = ((Collector)lstCollectors.SelectedItem).CollectorName;
            txtNotes.Text = ((Collector)lstCollectors.SelectedItem).Notes;
            txtNumberOfCustomers.Text = ((Collector)lstCollectors.SelectedItem).Customers.Count.ToString(CultureInfo.InvariantCulture);
            btnDelete.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            if (EvShowStatusText != null) EvShowStatusText("");
        }

        public void ClearFields()
        {
            txtCollectorName.Text = "";
            txtNotes.Text = "";
            txtNumberOfCustomers.Text = "";
            epName.SetError(txtCollectorName, "");
            btnDelete.Enabled = false;

            epName.SetError(txtCollectorName, "");

            lstCollectors.SelectedItems.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsValid())
                return;

            var c = new Collector();
            if(lstCollectors.SelectedItem!=null)
                c = (Collector)lstCollectors.SelectedItem;
            c.CollectorName = txtCollectorName.Text.Trim();
            c.Notes = txtNotes.Text.Trim();
            _db.SaveChanges();
            if (EvShowStatusText != null) EvShowStatusText("Collector: " +c.CollectorName+ ". Saved");
            PopulateList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var c = (Collector)lstCollectors.SelectedItem;
            if (c.Customers.Count > 0)
                MessageBox.Show("This Collector has customers", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                _db.Collectors.Remove(c);
                _db.SaveChanges();
                if (EvShowStatusText != null) EvShowStatusText("Collector: " + c.CollectorName + ". Deleted");
            }

            PopulateList();
        }
        private bool IsValid()
        {
            bool returnValue = true;
            if (txtCollectorName.Text.Trim().Length == 0)
            {
                epName.SetError(txtCollectorName, "Enter a name");
                returnValue = false;
            }
            return returnValue;
        }
    }
}
