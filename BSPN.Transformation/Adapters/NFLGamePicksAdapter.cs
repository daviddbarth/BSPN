using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSPN.Data;
using BSPN.Services;

namespace BSPN.Transformation.Adapters
{
    public interface INFLGamePicksAdapter
    {
        NFLWeekDTO GetCurrentWeekPicks();
    }

    public class NFLGamePicksAdapter : INFLGamePicksAdapter
    {
        private static INFLSeasonService _nflSeasonService;
        private readonly IBSNMapper _mapper;

        public NFLGamePicksAdapter(INFLSeasonService nflSeasonService, IBSNMapper mapper)
        {
            _nflSeasonService = nflSeasonService;
            _mapper = mapper;

            CreateMaps();
        }

        private void CreateMaps()
        {
            _mapper.CreateMap<NFLWeek, NFLWeekDTO>();
            _mapper.CreateMap<NFLGame, NFLGameDTO>();
            _mapper.CreateMap<NFLTeam, NFLTeamDTO>();

        }

        public NFLWeekDTO GetCurrentWeekPicks()
        {
            var currentSeason = _nflSeasonService.GetCurrentNFLSeason();
            var currentWeek = _nflSeasonService.GetNFLWeek(currentSeason.CurrentWeekId);
            var nflWeek = _mapper.Map<NFLWeekDTO>(currentWeek);

            return nflWeek;
        }
    }
}
