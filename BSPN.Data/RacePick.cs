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
    
    public partial class RacePick
    {
        public int RacePickId { get; set; }
        public string UserId { get; set; }
        public Nullable<int> RaceId { get; set; }
        public Nullable<int> DriverId { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual Race Race { get; set; }
    }
}
