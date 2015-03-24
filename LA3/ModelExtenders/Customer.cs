using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using iTextSharp.text.io;

namespace LA3.Model
{
    public partial class Customer
    {
        public string FullName
        {
            get
            {
                string rv = Forename.Trim();
                if (rv.Length > 0) rv += " ";
                rv += Surname.Trim();
                return rv;
            }
        }

        public string AddressFirstLine
        {
            get
            {
                string rv = Address;
                if (rv.IndexOf(Environment.NewLine, System.StringComparison.Ordinal) >= 0)
                {
                    rv = rv.Substring(0, rv.IndexOf(Environment.NewLine, System.StringComparison.Ordinal));
                }
                return rv.Trim();
            }
        }
    }
}
