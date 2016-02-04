using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LA3.Model;

namespace LA3
{
    public static class Functions
    {
        internal static bool IsPosDbl(string txt)
        {
            double d;
            if (!Double.TryParse(txt, out d)) return false;

            return (d >= 0);
        }
        internal static bool IsDbl(string txt)
        {
            double d;
            return Double.TryParse(txt, out d);
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
            sql = String.Format(sql, debt);
            var customerIds = db.Database.SqlQuery<int>(sql).ToList();
            return customerIds;
        }

        public static IEnumerable AccountsNotPaidForWeeks(int weeks)
        {
            var db = new LA_Entities();
            var sql = @"
	declare	@cutoffDate	as datetime
	set @cutoffDate	= DATEADD(week, {0}*-1, GETDATE());
	print @cutoffDate
	select	np.Account_Id
	from	(
		select	lp.*,
				case a.PayMonthly 
					when 0 then DATEADD(day, (a.PaymentPeriod*7), lp.LastPayment)
					else DATEADD(month, a.PaymentPeriod, lp.LastPayment)
				end as NextPaymentWasDue
		from	(
			select	p.Account_Id,
					max(p.[Timestamp]) as LastPayment
			from	Payments	p
			where p.Amount > 0
			group by	p.Account_Id) lp
		inner join Accounts	a	on a.Id	= lp.Account_Id) np
	where	np.NextPaymentWasDue	< @cutoffDate
	order by np.NextPaymentWasDue	asc
";
            sql = String.Format(sql, weeks);
            var customerIds = db.Database.SqlQuery<int>(sql).ToList();
            return customerIds;
        }

        internal static void ShowError(Exception exception)
        {
            MessageBox.Show(exception.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
