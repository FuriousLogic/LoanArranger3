using System.Collections.Generic;
using System.Linq;
using LA3.Model;

namespace LA3
{
    public static class Functions
    {
        internal static bool IsPosDbl(string txt)
        {
            double d;
            if (!double.TryParse(txt, out d)) return false;

            return (d >= 0);
        }
        internal static bool IsDbl(string txt)
        {
            double d;
            return double.TryParse(txt, out d);
        }

        public static List<int> GetCustomerIdsByDebt(int debt)
        {
            var db = new LA_Entities();
            var sql = @"
    select	a.Customer_Id
    from Accounts a
    inner
    join  (
        select a.Id,
				sum(p.Amount) as Paid
        from AccountStatusChanges astc
        inner
        join  (
            select Account_Id,
					max(Timestamp) as ts
            from AccountStatusChanges
            group by Account_Id) x on x.Account_Id = astc.Account_Id and x.ts = astc.Timestamp
        inner join  AccountStatus ast on ast.Id = astc.AccountStatus_Id
        inner join  Accounts a   on a.Id = astc.Account_Id
        inner join  Payments p   on p.Account_Id = a.Id
        where ast.Status = 'Created'
        group by a.Id) amtPaid on amtPaid.Id = a.Id
    group by    a.Customer_Id
    having  sum(a.GrossValue - amtPaid.Paid) >= {0}
    order by sum(a.GrossValue - amtPaid.Paid) desc
";
            sql = string.Format(sql, debt);
            var customerIds = db.Database.SqlQuery<int>(sql).ToList();
            return customerIds;
        }
    }
}
