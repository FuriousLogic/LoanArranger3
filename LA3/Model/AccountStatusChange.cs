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
    
    public partial class AccountStatusChange
    {
        public int Id { get; set; }
        public System.DateTime Timestamp { get; set; }
        public int AccountStatus_Id { get; set; }
        public int Account_Id { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual AccountStatus AccountStatus { get; set; }
    }
}
