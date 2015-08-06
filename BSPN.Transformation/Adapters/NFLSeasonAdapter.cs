using System.Collections.Generic;
using System.Linq;
using BSPN.Services;
using BSPN.Data;

namespace BSPN.Transformation
{
    public interface INFLSeasonAdapter
    {
        INFLSeasonDTO GetCurrentNFLSeason();
        INFLSeasonDTO GetNFLSeason(int seasonId);
        IEnumerable<INFLSeasonDTO> GetNFLSeasonsWithoutSchedule();
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
            _mapper.CreateMap<NFLSeason, INFLSeasonDTO>();
            _mapper.CreateMap<NFLWeek, INFLWeekDTO>();
            _mapper.CreateMap<NFLGame, INFLGameDTO>();
            _mapper.CreateMap<NFLTeam, INFLTeamDTO>();
        }

        public INFLSeasonDTO GetCurrentNFLSeason()
        {
            _mapper.ExcludeProperty<NFLTeam, INFLTeamDTO>("HomeGames");
            _mapper.ExcludeProperty<NFLTeam, INFLTeamDTO>("AwayGames");

            var season = _nflSeasonService.GetCurrentNFLSeason();
            var currentSeason = _mapper.Map<INFLSeasonDTO>(season);
            currentSeason.CurrentWeek = _mapper.Map<INFLWeekDTO>(_nflSeasonService.GetNFLWeek(season.CurrentWeekId));

            return currentSeason;
        }

        public INFLSeasonDTO GetNFLSeason(int seasonId)
        {
            _mapper.ExcludeProperty<NFLTeam, INFLTeamDTO>("HomeGames");
            _mapper.ExcludeProperty<NFLTeam, INFLTeamDTO>("AwayGames");

            var season = _nflSeasonService.GetNFLSeason(seasonId);
            return _mapper.Map<INFLSeasonDTO>(season);
        }

        public IEnumerable<INFLSeasonDTO> GetNFLSeasonsWithoutSchedule()
        {
            _mapper.ExcludeProperty<NFLSeason, INFLSeasonDTO>("NFLWeeks");

            var seasons = _nflSeasonService.GetNFLSeasons();
            return seasons.Select(s => _mapper.Map<INFLSeasonDTO>(s));
        }
    }
}
