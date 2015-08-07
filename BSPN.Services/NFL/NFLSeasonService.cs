using BSPN.Data;
using DataAccess;
using System.Collections.Generic;

namespace BSPN.Services
{
    public interface INFLSeasonService
    {
        NFLSeason GetCurrentNFLSeason();
        NFLSeason GetNFLSeason(int seasonId);
        IEnumerable<NFLSeason> GetNFLSeasons();
        NFLWeek GetNFLWeek(int? weekId);
        void SaveNFLWeekPicks(List<NFLGamePick> picks);
    }

    public class NFLSeasonService : INFLSeasonService
    {
        private static IRepository<NFLSeason> _nflSeasonRepository;
        private static IRepository<NFLWeek> _nflWeekRepository;
        private static IRepository<NFLGamePick> _nflPicksRepository;
        private static IRepository<NFLGame> _nflGameRepository;
        private readonly IUnitOfWork _unitOfWork;

        public NFLSeasonService(IRepository<NFLSeason> nflSeasonRepository, IRepository<NFLWeek> nflWeekRepository, IRepository<NFLGamePick> nflPicksRepository,
            IRepository<NFLGame> nflGameRepository, IUnitOfWork unitOfWork)
        {
            _nflSeasonRepository = nflSeasonRepository;
            _nflWeekRepository = nflWeekRepository;
            _nflPicksRepository = nflPicksRepository;
            _nflGameRepository = nflGameRepository;
            _unitOfWork = unitOfWork;
        }

        public NFLSeason GetCurrentNFLSeason()
        {
            return _nflSeasonRepository.FindOneOrCreate(n => n.IsCurrentSeason);
        }

        public NFLSeason GetNFLSeason(int seasonId)
        {
            return _nflSeasonRepository.Find(seasonId);
        }

        public IEnumerable<NFLSeason> GetNFLSeasons()
        {
            return _nflSeasonRepository.FindAll();
        }

        public NFLWeek GetNFLWeek(int? weekId)
        {
            int wkId;

            return int.TryParse(weekId.ToString(), out wkId) ? _nflWeekRepository.Find(wkId) : null;
        }

        public void SaveNFLWeekPicks(List<NFLGamePick> picks)
        {
            foreach (var pick in picks)
            {
                var gamePick = _nflPicksRepository.FindOne(p => p.UserId == pick.UserId && p.NFLGameId == pick.NFLGameId);

                if (!CanSavePick(pick)) continue;

                if (gamePick != null)
                    gamePick.NFLTeamId = pick.NFLTeamId;
                else
                    _nflPicksRepository.Add(pick);
            }

            _unitOfWork.Commit();
        }

        private static bool CanSavePick(NFLGamePick pick)
        {
            var currentTime = TimeHelpers.GetCurrentCentralTime();
            var nflGame = _nflGameRepository.FindOne(g => g.NFLGameId == pick.NFLGameId);

            return nflGame.GameTime > currentTime;
        }
    }
}
