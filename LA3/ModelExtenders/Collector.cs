using System;
using System.Collections.Generic;
using System.Linq;

namespace LA3.Model
{
    public partial class Collector
    {
        public int CustomersWithLiveAccountsCount
        {
            get
            {
                var rv = 0;
                foreach (var customer in Customers)
                    rv += customer.Accounts.Count(account => account.CurrentStatus.IsCreated);

                return rv;
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
