//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BSPN.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Driver
    {
        public Driver()
        {
            this.RacePicks = new HashSet<RacePick>();
        }
    
        public int DriverId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CarNumber { get; set; }
    
        public virtual ICollection<RacePick> RacePicks { get; set; }
    }
}