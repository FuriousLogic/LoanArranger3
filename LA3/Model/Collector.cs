//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Collector
    {
        public Collector()
        {
            this.Customers = new HashSet<Customer>();
        }
    
        public int Id { get; set; }
        public string CollectorName { get; set; }
        public string Notes { get; set; }
        public int OldId { get; set; }
    
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
