using System;
using System.Collections.Generic;
using System.Linq;

namespace LA3.Model
{
    public partial class Collector
    {
        public int CustomersWithAccountsCount
        {
            get
            {
                var db = new LA_Entities();
                var result = db.CustomersWithAccountsCount(Id).FirstOrDefault();
                if (result == null)
                    throw new Exception("CustomersWithAccountsCount: Can't find result");
                return (int)result;
            }
        }
        public int LiveCustomersCount
        {
            get
            {
                var db = new LA_Entities();
                var result = db.GetCustomerCountByCollector(Id).FirstOrDefault();
                if (result == null)
                    throw new Exception("LiveCustomersCount: Can't find result");
                return (int)result;
            }
        }
        public double TotalAmountOwed
        {
            get
            {
                double rv = 0;
                foreach (var customer in Customers)
                {
                    foreach (var account in customer.Accounts)
                    {
                        if (account.CurrentStatus.IsCreated)
                            rv += account.Outstanding;
                    }
                }

                return rv;
                //var db = new LA_Entities();
                //var result = db.GetAmountOwingForCollector(Id).FirstOrDefault();
                //if (result == null)
                //    throw new Exception("TotalAmountOwed: Can't find result");

                //if (result.Owing == null) return 0;
                //return (double)result.Owing;
            }
        }



        public List<Account> GetAccountsForCollection(DateTime collectionDay)
        {
            var db = new LA_Entities();
            var accounts = (from a in db.Accounts
                            where a.Customer.Collector_Id == Id
                            && (
                                (int)collectionDay.DayOfWeek == a.Customer.PreferredDay
                                || collectionDay == a.NextPaymentDate
                            )
                            select a).ToList();

            return accounts;
        }
    }
}
