using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSPN.Data;
using DataAccess;

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
        private IRepository<NFLTeam> _teamRepository;
        private IUnitOfWork _unitOfWork;

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
            if (team.NFLTeamId != 0)
                SaveExistingTeam(team);
            else
                SaveNewTeam(team);
        }

        private void SaveNewTeam(NFLTeam team)
        {
            _teamRepository.Add(team);
            _unitOfWork.Commit();
        }

        private void SaveExistingTeam(NFLTeam team)
        {
            _teamRepository.Attach(team);
            _teamRepository.SetState(team, System.Data.Entity.EntityState.Modified);
            _unitOfWork.Commit();
            
        }

    }
}
