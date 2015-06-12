using System;
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

    public interface INFLGameDTO
    {
        int NFLGamesId { get; set; }
        int NFLWeekId { get; set; }
        DateTime GameTime { get; set; }
        int HomeTeamId { get; set; }
        int VisitingTeamId { get; set; }
        int HomeTeamScore { get; set; }
        int VisitingTeamScore { get; set; }
    }

    public class NFLGameDTO : INFLGameDTO
    {
        public int NFLGamesId { get; set; }
        public int NFLWeekId { get; set; }
        public DateTime GameTime { get; set; }
        public int HomeTeamId { get; set; }
        public int VisitingTeamId { get; set; }
        public int HomeTeamScore { get; set; }
        public int VisitingTeamScore { get; set; }
    }
}
