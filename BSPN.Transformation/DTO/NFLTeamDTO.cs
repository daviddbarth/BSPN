﻿using System;
using System.Collections.Generic;

namespace BSPN.Transformation
{
    public interface INFLTeamDTO
    {
        int NFLTeamId { get; set; }
        string City { get; set; }
        string TeamName { get; set; }
        IEnumerable<INFLGameDTO> NFLGames { get; set; }
    }

    public class NFLTeamDTO : INFLTeamDTO
    {
        public int NFLTeamId { get; set; }
        public string City { get; set; }
        public string TeamName { get; set; }
        public IEnumerable<INFLGameDTO> NFLGames { get; set; }
    }

}
