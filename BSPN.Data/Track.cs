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
    
    public partial class Track
    {
        public Track()
        {
            this.Races = new HashSet<Race>();
        }
    
        public int TrackId { get; set; }
        public string TrackName { get; set; }
    
        public virtual ICollection<Race> Races { get; set; }
    }
}
