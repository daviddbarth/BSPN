using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSPN.Transformation
{
    public interface INFLGameDTO
    {
        int NFLGameId { get; set; }
        int NFLWeekId { get; set; }
        DateTime GameTime { get; set; }
        int HomeTeamId { get; set; }
        string HomeTeamName { get; set; }
        int VisitingTeamId { get; set; }
        string VisitingTeamName { get; set; }
        int HomeTeamScore { get; set; }
        int VisitingTeamScore { get; set; }
    }

    public class NFLGameDTO : INFLGameDTO
    {
        public int NFLGameId { get; set; }
        public int NFLWeekId { get; set; }
        public DateTime GameTime { get; set; }
        public int HomeTeamId { get; set; }
        public string HomeTeamName { get; set; }
        public int VisitingTeamId { get; set; }
        public string VisitingTeamName { get; set; }
        public int HomeTeamScore { get; set; }
        public int VisitingTeamScore { get; set; }
    }

    public interface INFLWeekDTO
    {
        int NFLWeekId { get; set; }
        int NFLSeasonId { get; set; }
        string Description { get; set; }
        IEnumerable<INFLGameDTO> NFLGames { get; set; }
    }

    public class NFLWeekDTO : INFLWeekDTO
    {
        public int NFLWeekId { get; set; }
        public int NFLSeasonId { get; set; }
        public string Description { get; set; }
        public IEnumerable<INFLGameDTO> NFLGames { get; set; }
    }

    public interface INFLSeasonDTO
    {
        int NFLSeasonId { get; set; }
        string SeasonDescription { get; set; }
    }

    public class NFLSeasonDTO : INFLSeasonDTO
    {
        public int NFLSeasonId { get; set; }
        public string SeasonDescription { get; set; }
    }

    public interface INFLScheduleDTO
    {
        INFLSeasonDTO Season { get; set; }
        IEnumerable<INFLWeekDTO> NFLWeeks { get; set; }
    }

    public class NFLScheduleDTO : INFLScheduleDTO
    {
        public INFLSeasonDTO Season { get; set; }
        public IEnumerable<INFLWeekDTO> NFLWeeks { get; set; }
    }


}
