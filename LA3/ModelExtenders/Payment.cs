using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace LA3.Model
{
    partial class Payment
    {
        public string Type
        {
            get { return IsSundry ? "Sundry" : ""; }
        }

        public static IEnumerable<Payment> GetSundryPaymentsFromDate(DateTime fromDate)
        {
            var db = new LA_Entities();
            var payments = (from p in db.Payments where p.IsSundry && p.Timestamp >= fromDate orderby p.Timestamp descending, p.Account.Customer.Surname select p).ToList();
            return payments;
        }
    }
}
