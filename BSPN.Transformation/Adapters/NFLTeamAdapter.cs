using System.Collections.Generic;
using System.Linq;
using BSPN.Data;
using BSPN.Services;

namespace BSPN.Transformation
{
    public interface INFLTeamAdapter 
    {
        IEnumerable<NFLTeamDTO> GetNFLTeams();
        NFLTeamDTO GetNFLTeam(int nflTeamId);
        NFLTeamDTO GetNFLTeamWithSchedule(int nflTeamId);
        void SaveNFLTeam(NFLTeamDTO team);
    }

    public class NFLTeamAdapter : INFLTeamAdapter
    {
        private readonly IBSNMapper _mapper;
        private readonly INFLTeamService _nflTeamService;

        public NFLTeamAdapter(INFLTeamService nflTEamService, IBSNMapper mapper)
        {
            _nflTeamService = nflTEamService;
            _mapper = mapper;
            CreateMaps();
        }

        private void CreateMaps()
        {
            _mapper.CreateMap<NFLTeam, NFLTeamDTO>();
            _mapper.CreateMap<NFLGame, NFLGameDTO>();
            _mapper.ExcludeProperty<NFLTeam, NFLTeamDTO>("NFLGames");
            _mapper.CreateMap<NFLTeamDTO, NFLTeam>();
        }
        
        public IEnumerable<NFLTeamDTO> GetNFLTeams()
        {
            return _nflTeamService.GetAllTeams().Select(t => _mapper.Map<NFLTeamDTO>(t));
        }

        public NFLTeamDTO GetNFLTeam(int nflTeamId)
        {
            var nflTeam = _nflTeamService.GetNFLTeam(nflTeamId);
                                    
            return _mapper.Map<NFLTeamDTO>(nflTeam);
        }

        public NFLTeamDTO GetNFLTeamWithSchedule(int nflTeamId)
        {
            var nflTeam = _nflTeamService.GetNFLTeam(nflTeamId);
            var nflTeamDTO = _mapper.Map<NFLTeamDTO>(nflTeam);
            
            return nflTeamDTO;
        }

        public void SaveNFLTeam(NFLTeamDTO team)
        {
            if (team != null)
            {
                var nflTeam = _mapper.Map<NFLTeam>(team);
                _nflTeamService.SaveNFLTeam(nflTeam);
            }
        }
    }
}
