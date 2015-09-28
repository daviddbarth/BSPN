using System;
using System.Collections.Generic;
using System.Linq;

namespace BSPN.Transformation
{
    public class NFLGameDTO 
    {
        public int NFLGameId { get; set; }
        public int NFLWeekId { get; set; }
        public DateTime GameTime { get; set; }
        public NFLTeamDTO HomeTeam { get; set; }
        public NFLTeamDTO VisitingTeam { get; set; }
        public int HomeTeamScore { get; set; }
        public int VisitingTeamScore { get; set; }
        public bool HomeTeamPicked { get; set; }
        public bool VisitingTeamPicked { get; set; }
        public bool PicksAllowed { get; set; }
    }

    public class NFLWeekDTO 
    {
        public int NFLWeekId { get; set; }
        public int NFLSeasonId { get; set; }
        public string Description { get; set; }
        public IEnumerable<NFLGameDTO> NFLGames { get; set; }
    }

    public class NFLSeasonDTO 
    {
        public int NFLSeasonId { get; set; }
        public string SeasonDescription { get; set; }
        public bool IsCurrentSeason { get; set; }
        public NFLWeekDTO CurrentWeek { get; set; }
        public IEnumerable<NFLWeekDTO> NFLWeeks { get; set; }
    }

    public class NFLTeamDTO
    {
        public int NFLTeamId { get; set; }
        public string City { get; set; }
        public string TeamName { get; set; }
        public string LogoImage { get; set; }
        public IEnumerable<NFLGameDTO> HomeGames { get; set; }
        public IEnumerable<NFLGameDTO> AwayGames { get; set; }
    }

    public class NFLWeeklyPicksRecords
    {
        public IList<NFLWeekPicksRecord> WeeklyRecords { get; set; }
        public NFLWeekPicksRecord CurrentWeekRecords { get; set; }

        public NFLWeeklyPicksRecords()
        {
            WeeklyRecords = new List<NFLWeekPicksRecord>();
        }
    }

    public class NFLWeekPicksRecord
    {
        public int NFLWeekId { get; set; }
        public string NFLWeekDescription { get; set; }
        public IList<NFLPlayerPicksRecord> NFLPlayerRecords;

        public NFLWeekPicksRecord()
        {
            NFLPlayerRecords = new List<NFLPlayerPicksRecord>();
        }

    }

    public class NFLPlayerPicksRecord
    {
        public UserDTO Player { get; set; }
        public int WinsCount { get; set; }
        public int LosesCount { get; set; }
        public int NFLWeekId { get; set; }

        public NFLPlayerPicksRecord()
        {
            Player = new UserDTO();
        }
    }

}
