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
    
    public partial class NFLSeason
    {
        public NFLSeason()
        {
            this.NFLWeeks = new HashSet<NFLWeek>();
        }
    
        public int NFLSeasonId { get; set; }
        public string SeasonDescription { get; set; }
        public bool IsCurrentSeason { get; set; }
        public int CurrentWeekId { get; set; }
    
        public virtual ICollection<NFLWeek> NFLWeeks { get; set; }
    }
}
