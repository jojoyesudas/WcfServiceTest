//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public Employee()
        {
            this.Addresses = new HashSet<Address>();
        }
    
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Gender { get; set; }
    
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
