USE [LoanArranger3_ef]
GO
/****** Object:  StoredProcedure [dbo].[CustomersWithAccountsCount]    Script Date: 19/08/2015 19:18:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CustomersWithAccountsCount] 
	@CollectorId	as int
AS
BEGIN
	select	count(*)
	from	(
		select	cu.Id
		from		Collectors	co
		inner join	Customers	cu	on cu.Collector_Id	= co.Id
		inner join	Accounts	ac	on ac.Customer_Id	= cu.Id
		where	co.Id	= @CollectorId
		group by	cu.Id) x
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteCollectors]    Script Date: 19/08/2015 19:18:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteCollectors]
AS
BEGIN
	truncate table [dbo].[Payments]
	truncate table [dbo].[AccountStatusChanges]
	delete from [dbo].[Accounts]
	delete from [dbo].[Customers]
	delete from [dbo].[Collectors]
END

GO
/****** Object:  StoredProcedure [dbo].[GetAmountOwingForCollector]    Script Date: 19/08/2015 19:18:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAmountOwingForCollector] 
	@CollectorID	as int
AS
BEGIN
	select	sum(a.GrossValue - x.Amount) as Owing
	from	dbo.Customers	c
	inner join	dbo.Accounts	a
		on	a.Customer_Id	= c.Id
	inner join ( 
		select	sc.Account_Id,
				sum(p.Amount)	as Amount
		from	dbo.AccountStatusChanges	sc
		inner join
		(
			select	Account_Id,
					max([Timestamp])	as [Timestamp]
			from	dbo.AccountStatusChanges
			group by Account_Id
		) t
			on	t.Account_Id	= sc.Account_Id
			and	t.Timestamp	= sc.Timestamp
		inner join dbo.Payments	p
			on p.Account_Id	= sc.Account_Id
		where	sc.AccountStatus_Id	= 1 --Created
		group by sc.Account_Id
	) x	on x.Account_Id	= a.Id
	where	c.Collector_Id	= @CollectorID
END

GO
/****** Object:  StoredProcedure [dbo].[GetCustomerCountByCollector]    Script Date: 19/08/2015 19:18:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCustomerCountByCollector]
	@CollectorId	as int
AS
BEGIN
	select	count(*) as CustomerCount
	from	(
		select	cu.id
		from	Accounts	a
		inner join	Customers	cu	on	cu.Id	= a.Customer_Id
		where	a.Id	in (
			select	asch.Account_Id
			from	AccountStatusChanges	asch
			inner join	(
							select	Account_Id,
									max(Id)	as Id
							from	AccountStatusChanges
							group by	Account_Id) x	on	x.Id	= asch.Id
			inner join	AccountStatus	ast	on	ast.Id	= asch.AccountStatus_Id
			where	ast.Status	= 'Created')
		and	cu.Collector_Id	= @CollectorId
		group by cu.Id) x
END

GO
/****** Object:  StoredProcedure [dbo].[Report_ByDebt]    Script Date: 19/08/2015 19:18:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Report_ByDebt] 
	@debt	as int
AS
BEGIN
	select	a.Customer_Id
	from	Accounts	a
	inner join	(
		select	a.Id,
				sum(p.Amount)	as Paid
		from	AccountStatusChanges astc
		inner join	(
			select	Account_Id,
					max(Timestamp)	as ts
			from	AccountStatusChanges
			group by	Account_Id) x on x.Account_Id	= astc.Account_Id and x.ts = astc.Timestamp
		inner join	AccountStatus	ast	on ast.Id		= astc.AccountStatus_Id
		inner join	Accounts		a	on a.Id			= astc.Account_Id
		inner join	Payments		p	on p.Account_Id	= a.Id
		where	ast.Status	= 'Created'
		group by a.Id) amtPaid	on amtPaid.Id	= a.Id
	group by	a.Customer_Id
	having	sum(a.GrossValue - amtPaid.Paid) >= @debt
	order by sum(a.GrossValue - amtPaid.Paid) desc
END

GO
/****** Object:  StoredProcedure [dbo].[Report_NotPaid]    Script Date: 19/08/2015 19:18:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Report_NotPaid] 
	@weeks	as int
AS
BEGIN
	declare	@cutoffDate	as datetime
	set @cutoffDate	= DATEADD(week, @weeks*-1, GETDATE());
	print @cutoffDate
	select	*
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
END

GO
