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
    }

    public class NFLSeasonService : INFLSeasonService
    {
        private static IRepository<NFLSeason> _nflSeasonRepository;
        private static IRepository<NFLWeek> _nflWeekRepository;
        private readonly IUnitOfWork _unitOfWork;

        public NFLSeasonService(IRepository<NFLSeason> nflSeasonRepository, IRepository<NFLWeek> nflWeekRepository, IUnitOfWork unitOfWork)
        {
            _nflSeasonRepository = nflSeasonRepository;
            _nflWeekRepository = nflWeekRepository;
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
    }
}
