using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSPN.Data;
using BSPN.Services;

namespace BSPN.Transformation.Adapters
{
    public class NFLGameAdapter
    {
        protected static INFLSeasonService NFLSeasonService;
        protected readonly IBSNMapper Mapper;

        public NFLGameAdapter(INFLSeasonService nflSeasonService, IBSNMapper mapper)
        {
            NFLSeasonService = nflSeasonService;
            Mapper = mapper;

            CreateMaps();
        }

        private void CreateMaps()
        {
            Mapper.CreateMap<NFLWeek, NFLWeekDTO>();
            Mapper.CreateMap<NFLGame, NFLGameDTO>();
            Mapper.CreateMap<NFLTeam, NFLTeamDTO>();
            Mapper.ExcludeProperty<NFLTeam, NFLTeamDTO>("HomeGames");
            Mapper.ExcludeProperty<NFLTeam, NFLTeamDTO>("AwayGames");

        }

        public NFLWeek GetCurrentWeek()
        {
            var currentSeason = NFLSeasonService.GetCurrentNFLSeason();
            return NFLSeasonService.GetNFLWeek(currentSeason.CurrentWeekId);
        }

        public NFLWeekDTO GetMappedCurrentWeek()
        {
            return Mapper.Map<NFLWeekDTO>(GetCurrentWeek());
        }
    }
}
