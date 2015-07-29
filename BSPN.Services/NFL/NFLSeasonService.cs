using BSPN.Data;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSPN.Services
{
    public interface INFLSeasonService
    {
        NFLSeason GetNFLSeason(int seasonId);
        IEnumerable<NFLSeason> GetNFLSeasons();
    }

    public class NFLSeasonService : INFLSeasonService
    {
        private static IRepository<NFLSeason> _nflSeasonRepository;
        private readonly IUnitOfWork _unitOfWork;

        public NFLSeasonService(IRepository<NFLSeason> nflSeasonRepository, IUnitOfWork unitOfWork)
        {
            _nflSeasonRepository = nflSeasonRepository;
            _unitOfWork = unitOfWork;
        }

        public NFLSeason GetNFLSeason(int seasonId)
        {
            return _nflSeasonRepository.Find(seasonId);
        }

        public IEnumerable<NFLSeason> GetNFLSeasons()
        {
            return _nflSeasonRepository.FindAll();
        }
    }
}
