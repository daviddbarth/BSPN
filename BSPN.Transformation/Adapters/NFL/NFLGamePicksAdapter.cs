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

    public class NFLGamePicksAdapter : NFLGameAdapter, INFLGamePicksAdapter
    {
        public NFLGamePicksAdapter(INFLSeasonService nflSeasonService, IBSNMapper mapper)
            : base(nflSeasonService, mapper)
        {

        }

        public NFLWeekDTO GetCurrentWeekPicks(string userId)
        {
            var currentCentralTime = TimeHelpers.GetCurrentCentralTime();
            var currentWeek = GetCurrentWeek();
            var currentPicks = NFLSeasonService.GetNFLPicks(currentWeek.NFLWeekId, userId);

            var mappedWeek = Mapper.Map<NFLWeekDTO>(currentWeek);

            mappedWeek.NFLGames.ToList().ForEach(g => g.PicksAllowed = g.GameTime > currentCentralTime);
            
            foreach(var pick in currentPicks)
            {
                var game = mappedWeek.NFLGames.First(g => g.NFLGameId == pick.NFLGameId);

                game.HomeTeamPicked = game.HomeTeam.NFLTeamId == pick.NFLTeamId;
                game.VisitingTeamPicked = game.VisitingTeam.NFLTeamId == pick.NFLTeamId;
            }

            return mappedWeek;
        }

        public void SaveCurrentWeeksPicks(NFLWeekDTO currentWeek, string userId)
        {
            var gamePicksList = new List<NFLGamePick>();
            currentWeek.NFLGames.ToList().ForEach(g => { if(g.HomeTeamPicked || g.VisitingTeamPicked) gamePicksList.Add(CreateGamePick(g, userId)); });
            NFLSeasonService.SaveNFLPicks(gamePicksList);

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
