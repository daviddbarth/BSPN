using System.Collections.Generic;
using BSPN.Data;
using DataAccess;
using System.Data.Entity;

namespace BSPN.Services
{
    public interface INFLTeamService
    {
        IEnumerable<NFLTeam> GetAllTeams();
        NFLTeam GetNFLTeam(int teamId);
        void SaveNFLTeam(NFLTeam team);
    }

    public class NFLTeamService : INFLTeamService
    {
        private readonly IRepository<NFLTeam> _teamRepository;
        private readonly IUnitOfWork _unitOfWork;

        public NFLTeamService(IRepository<NFLTeam> teamRepository, IUnitOfWork unitOfWork)
        {
            _teamRepository = teamRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<NFLTeam> GetAllTeams()
        {
            return _teamRepository.FindAll();
        }

        public NFLTeam GetNFLTeam(int nflTeamId)
        {
            var nflTeam = _teamRepository.Find(nflTeamId);
            return nflTeam;
        }

        public void SaveNFLTeam(NFLTeam team)
        {
            _teamRepository.Entry(team, team.NFLTeamId == 0 ? EntityState.Added : EntityState.Modified);
            _unitOfWork.Commit();

        }

    }
}
