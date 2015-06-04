using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSPN.Data;
using BSPN.Transformation;
using BSPN.Transformation.Adapters;
using DataAccess;

namespace BSPN.Services
{
    public interface INFLTeamService
    {
        IEnumerable<INFLTeamDTO> GetAllTeams();
        INFLTeamDTO GetNFLTeam(int teamId);
    }

    public class NFLTeamService : INFLTeamService
    {
        private IRepository<NFLTeam> _teamRepository;
        private INFLTeamAdapter _nflTeamAdapter;

        public NFLTeamService(IRepository<NFLTeam> teamRepository, INFLTeamAdapter nflTeamAdapter)
        {
            _teamRepository = teamRepository;
            _nflTeamAdapter = nflTeamAdapter;
        }

        public IEnumerable<INFLTeamDTO> GetAllTeams()
        {
            return _nflTeamAdapter.GetNFLTeams();
        }

        public INFLTeamDTO GetNFLTeam(int teamId)
        {
            var nflTeam = _nflTeamAdapter.GetNFLTeam(teamId);

            return nflTeam;
        }
    }
}
