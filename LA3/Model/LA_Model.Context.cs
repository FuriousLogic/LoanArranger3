﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LA3.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class LA_Entities : DbContext
    {
        public LA_Entities()
            : base("name=LA_Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountStatus> AccountStatus { get; set; }
        public DbSet<AccountStatusChange> AccountStatusChanges { get; set; }
        public DbSet<Collector> Collectors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Payment> Payments { get; set; }
    
        public virtual ObjectResult<Nullable<int>> CustomersWithAccountsCount(Nullable<int> collectorId)
        {
            var collectorIdParameter = collectorId.HasValue ?
                new ObjectParameter("CollectorId", collectorId) :
                new ObjectParameter("CollectorId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("CustomersWithAccountsCount", collectorIdParameter);
        }
    
        public virtual ObjectResult<Nullable<double>> GetAmountOwingForCollector(Nullable<int> collectorID)
        {
            var collectorIDParameter = collectorID.HasValue ?
                new ObjectParameter("CollectorID", collectorID) :
                new ObjectParameter("CollectorID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<double>>("GetAmountOwingForCollector", collectorIDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> GetCustomerCountByCollector(Nullable<int> collectorId)
        {
            var collectorIdParameter = collectorId.HasValue ?
                new ObjectParameter("CollectorId", collectorId) :
                new ObjectParameter("CollectorId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("GetCustomerCountByCollector", collectorIdParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> Report_ByDebt(Nullable<int> debt)
        {
            var debtParameter = debt.HasValue ?
                new ObjectParameter("debt", debt) :
                new ObjectParameter("debt", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("Report_ByDebt", debtParameter);
        }
    
        public virtual ObjectResult<Report_NotPaid_Result1> Report_NotPaid(Nullable<int> weeks)
        {
            var weeksParameter = weeks.HasValue ?
                new ObjectParameter("weeks", weeks) :
                new ObjectParameter("weeks", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Report_NotPaid_Result1>("Report_NotPaid", weeksParameter);
        }
    }
}
