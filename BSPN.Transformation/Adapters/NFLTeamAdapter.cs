using System.Collections.Generic;
using System.Linq;
using BSPN.Data;
using BSPN.Services;

namespace BSPN.Transformation
{
    public interface INFLTeamAdapter 
    {
        IEnumerable<INFLTeamDTO> GetNFLTeams();
        INFLTeamDTO GetNFLTeam(int nflTeamId);
        INFLTeamDTO GetNFLTeamWithSchedule(int nflTeamId);
        void SaveNFLTeam(INFLTeamDTO team);
    }

    public class NFLTeamAdapter : INFLTeamAdapter
    {
        private readonly IBSNMappingEngine _mapper;
        private readonly INFLTeamService _nflTeamService;

        public NFLTeamAdapter(INFLTeamService nflTEamService, IBSNMappingEngine mapper)
        {
            _nflTeamService = nflTEamService;
            _mapper = mapper;
            CreateMaps();
        }

        private void CreateMaps()
        {
            _mapper.ConfigurationProvider.CreateTypeMap(typeof(NFLGame), typeof(INFLGameDTO));
            _mapper.ConfigurationProvider.CreateTypeMap(typeof(NFLTeam), typeof(INFLTeamDTO));
        }
        
        public IEnumerable<INFLTeamDTO> GetNFLTeams()
        {
            return _nflTeamService.GetAllTeams().Select(t => _mapper.Map<INFLTeamDTO>(t));
        }

        public INFLTeamDTO GetNFLTeam(int nflTeamId)
        {
            var nflTeam = _nflTeamService.GetNFLTeam(nflTeamId);
            _mapper.ExcludeProperty<NFLTeam, INFLTeamDTO>("NFLGames");

            return _mapper.Map<INFLTeamDTO>(nflTeam);
        }

        public INFLTeamDTO GetNFLTeamWithSchedule(int nflTeamId)
        {
            var nflTeam = _nflTeamService.GetNFLTeam(nflTeamId);
            var nflTeamDTO = _mapper.Map<INFLTeamDTO>(nflTeam);
            
            return nflTeamDTO;
        }

        public void SaveNFLTeam(INFLTeamDTO team)
        {
            var nflTeam = _mapper.Map<NFLTeam>(team);
            _nflTeamService.SaveNFLTeam(nflTeam);
        }
    }
}
