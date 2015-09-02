using System.Collections.Generic;
using System.Linq;
using BSPN.Services;
using BSPN.Data;

namespace BSPN.Transformation
{
    public interface INFLSeasonAdapter
    {
        NFLSeasonDTO GetCurrentNFLSeason();
        NFLSeasonDTO GetNFLSeason(int seasonId);
        IEnumerable<NFLSeasonDTO> GetNFLSeasonsWithoutSchedule();
    }

    public class NFLSeasonAdapter : INFLSeasonAdapter
    {
        private static INFLSeasonService _nflSeasonService;
        private readonly IBSNMapper _mapper;

        public NFLSeasonAdapter(INFLSeasonService nflSeasonService, IBSNMapper mapper)
        {
            _nflSeasonService = nflSeasonService;
            _mapper = mapper;

            CreateMaps();
        }

        private void CreateMaps()
        {
            _mapper.CreateMap<NFLSeason, NFLSeasonDTO>();
            _mapper.CreateMap<NFLWeek, NFLWeekDTO>();
            _mapper.CreateMap<NFLGame, NFLGameDTO>();
            _mapper.CreateMap<NFLTeam, NFLTeamDTO>();
        }

        public NFLSeasonDTO GetCurrentNFLSeason()
        {
            _mapper.ExcludeProperty<NFLTeam, NFLTeamDTO>("HomeGames");
            _mapper.ExcludeProperty<NFLTeam, NFLTeamDTO>("AwayGames");

            var season = _nflSeasonService.GetCurrentNFLSeason();
            var currentSeason = _mapper.Map<NFLSeasonDTO>(season);
            currentSeason.CurrentWeek = _mapper.Map<NFLWeekDTO>(_nflSeasonService.GetNFLWeek(season.CurrentWeekId));

            return currentSeason;
        }

        public NFLSeasonDTO GetNFLSeason(int seasonId)
        {
            _mapper.ExcludeProperty<NFLTeam, NFLTeamDTO>("HomeGames");
            _mapper.ExcludeProperty<NFLTeam, NFLTeamDTO>("AwayGames");

            var season = _nflSeasonService.GetNFLSeason(seasonId);
            return _mapper.Map<NFLSeasonDTO>(season);
        }

        public IEnumerable<NFLSeasonDTO> GetNFLSeasonsWithoutSchedule()
        {
            _mapper.ExcludeProperty<NFLSeason, NFLSeasonDTO>("NFLWeeks");

            var seasons = _nflSeasonService.GetNFLSeasons();
            return seasons.Select(s => _mapper.Map<NFLSeasonDTO>(s));
        }
    }
}
