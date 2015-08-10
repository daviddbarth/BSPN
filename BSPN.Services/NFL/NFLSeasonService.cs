﻿using BSPN.Data;
using DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace BSPN.Services
{
    public interface INFLSeasonService
    {
        NFLSeason GetCurrentNFLSeason();
        NFLSeason GetNFLSeason(int seasonId);
        IEnumerable<NFLSeason> GetNFLSeasons();
        NFLWeek GetNFLWeek(int weekId);
        IEnumerable<NFLGamePick> GetNFLPicks(int weekId, string userId);
        void SaveNFLPicks(List<NFLGamePick> picks);
    };

    public class NFLSeasonService : INFLSeasonService
    {
        private static IRepository<NFLSeason> _nflSeasonRepository;
        private static IRepository<NFLWeek> _nflWeekRepository;
        private static IRepository<NFLGamePick> _nflPicksRepository;
        private static IRepository<NFLGame> _nflGameRepository;
        private static IDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public NFLSeasonService(IRepository<NFLSeason> nflSeasonRepository, IRepository<NFLWeek> nflWeekRepository, IRepository<NFLGamePick> nflPicksRepository,
            IRepository<NFLGame> nflGameRepository, IDbContext context, IUnitOfWork unitOfWork)
        {
            _nflSeasonRepository = nflSeasonRepository;
            _nflWeekRepository = nflWeekRepository;
            _nflPicksRepository = nflPicksRepository;
            _nflGameRepository = nflGameRepository;
            _context = context;
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

        public NFLWeek GetNFLWeek(int weekId)
        {
            int wkId;

            return int.TryParse(weekId.ToString(), out wkId) ? _nflWeekRepository.Find(wkId) : null;
        }

        public IEnumerable<NFLGamePick> GetNFLPicks(int weekId, string userId)
        {
            var picksQuery = GamePicksQuery(weekId, userId);

            return picksQuery.AsEnumerable();
        }

        private static IQueryable<NFLGamePick> GamePicksQuery(int weekId, string userId)
        {
            var gamePicks = _context.Set<NFLGamePick>();
            var games = _context.Set<NFLGame>();

            var gamePicksQuery =
                from NFLGamePicks in gamePicks
                join NFLGames in games on NFLGamePicks.NFLGameId equals NFLGames.NFLGameId
                where NFLGames.NFLWeekId == weekId && NFLGamePicks.UserId == userId
                select NFLGamePicks;

            return gamePicksQuery;
        }

        public void SaveNFLPicks(List<NFLGamePick> picks)
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
