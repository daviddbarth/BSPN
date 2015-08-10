using System.Collections.Generic;
using System.Linq;
using BSPN.Data;
using BSPN.Services;

namespace BSPN.Transformation.Adapters
{
    public interface INFLGamePicksAdapter
    {
        NFLWeekDTO GetCurrentWeekPicks(string userId);
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
            _mapper.ExcludeProperty<NFLTeam, NFLTeamDTO>("HomeGames");
            _mapper.ExcludeProperty<NFLTeam, NFLTeamDTO>("AwayGames");

        }

        public NFLWeekDTO GetCurrentWeekPicks(string userId)
        {
            var currentCentralTime = TimeHelpers.GetCurrentCentralTime();

            var currentSeason = _nflSeasonService.GetCurrentNFLSeason();
            var currentWeek = _nflSeasonService.GetNFLWeek(currentSeason.CurrentWeekId);
            var currentPicks = _nflSeasonService.GetNFLPicks(currentSeason.CurrentWeekId, userId);
            var nflWeek = _mapper.Map<NFLWeekDTO>(currentWeek);

            nflWeek.NFLGames.ToList().ForEach(g => g.PicksAllowed = g.GameTime > currentCentralTime);
            
            foreach(var pick in currentPicks)
            {
                var game = nflWeek.NFLGames.First(g => g.NFLGameId == pick.NFLGameId);

                game.HomeTeamPicked = game.HomeTeam.NFLTeamId == pick.NFLTeamId;
                game.VisitingTeamPicked = game.VisitingTeam.NFLTeamId == pick.NFLTeamId;
            }

            return nflWeek;
        }

        public void SaveCurrentWeeksPicks(NFLWeekDTO currentWeek, string userId)
        {
            var gamePicksList = new List<NFLGamePick>();
            currentWeek.NFLGames.ToList().ForEach(g => { if(g.HomeTeamPicked || g.VisitingTeamPicked) gamePicksList.Add(CreateGamePick(g, userId)); });
            _nflSeasonService.SaveNFLPicks(gamePicksList);

        }

        private NFLGamePick CreateGamePick(NFLGameDTO userGamePick, string userId)
        {
            var nflGamePick = new NFLGamePick() {NFLGameId = userGamePick.NFLGameId, UserId = userId};

            if (userGamePick.HomeTeamPicked)
                nflGamePick.NFLTeamId = userGamePick.HomeTeam.NFLTeamId;

            if (userGamePick.VisitingTeamPicked)
                nflGamePick.NFLTeamId = userGamePick.VisitingTeam.NFLTeamId;

            return nflGamePick;
        }
    }
}
