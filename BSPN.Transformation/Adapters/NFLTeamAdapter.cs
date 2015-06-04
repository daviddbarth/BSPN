using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using BSPN.Data;
using AutoMapper;

namespace BSPN.Transformation.Adapters
{
    public interface INFLTeamAdapter 
    {
        IEnumerable<INFLTeamDTO> GetNFLTeams();
        INFLTeamDTO GetNFLTeam(int nflTeamId);
    }

    public class NFLTeamAdapter : INFLTeamAdapter
    {
        private IMappingEngine _mapper;
        private IRepository<NFLTeam> _teamRepos;

        public NFLTeamAdapter(IRepository<NFLTeam> teamRepos, IMappingEngine mapper)
        {
            _teamRepos = teamRepos;
             _mapper = mapper;
            _mapper.ConfigurationProvider.CreateTypeMap(typeof(NFLTeam), typeof(INFLTeamDTO));
        }

        public IEnumerable<INFLTeamDTO> GetNFLTeams()
        {
            return _teamRepos.FindAll().Select(t => _mapper.Map<INFLTeamDTO>(t));
        }

        public INFLTeamDTO GetNFLTeam(int nflTeamId)
        {
            var team = _teamRepos.Find(nflTeamId);
            return _mapper.Map<INFLTeamDTO>(team);
        }
    }
}
