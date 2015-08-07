using System.Collections.Generic;
using System.Linq;
using BSPN.Data;
using BSPN.Services;

namespace BSPN.Transformation.Adapters
{
    public interface INFLGamePicksAdapter
    {
        NFLWeekDTO GetCurrentWeekPicks();
        void SaveCurrentWeeksPicks(NFLWeekDTO currentWeek, string userId);
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
            var currentCentralTime = TimeHelpers.GetCurrentCentralTime();

            var currentSeason = _nflSeasonService.GetCurrentNFLSeason();
            var currentWeek = _nflSeasonService.GetNFLWeek(currentSeason.CurrentWeekId);
            var nflWeek = _mapper.Map<NFLWeekDTO>(currentWeek);

            nflWeek.NFLGames.ToList().ForEach(g => g.PicksAllowed = g.GameTime > currentCentralTime);
            
            return nflWeek;
        }

        public void SaveCurrentWeeksPicks(NFLWeekDTO currentWeek, string userId)
        {
            var gamePicksList = new List<NFLGamePick>();
            currentWeek.NFLGames.ToList().ForEach(g => { if(g.HomeTeamPicked || g.VisitingTeamPicked) gamePicksList.Add(CreateGamePick(g, userId)); });
            _nflSeasonService.SaveNFLWeekPicks(gamePicksList);

        }

        private NFLGamePick CreateGamePick(NFLGameDTO userGamePick, string userId)
        {
            var nflGamePick = new NFLGamePick() {NFLGameId = userGamePick.NFLGameId, UserId = userId};

            if (userGamePick.HomeTeamPicked)
                nflGamePick.NFLTeamId = userGamePick.HomeTeamId;

            if (userGamePick.VisitingTeamPicked)
                nflGamePick.NFLTeamId = userGamePick.VisitingTeamId;

            return nflGamePick;
        }
    }
}
