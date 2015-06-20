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
            _mapper.CreateMap<NFLTeam, INFLTeamDTO>();
            _mapper.CreateMap<NFLGame, NFLGameDTO>();
            _mapper.ExcludeProperty<NFLTeam, INFLTeamDTO>("NFLGames");
            _mapper.CreateMap<INFLTeamDTO, NFLTeam>();
        }
        
        public IEnumerable<INFLTeamDTO> GetNFLTeams()
        {
            return _nflTeamService.GetAllTeams().Select(t => _mapper.Map<INFLTeamDTO>(t));
        }

        public INFLTeamDTO GetNFLTeam(int nflTeamId)
        {
            var nflTeam = _nflTeamService.GetNFLTeam(nflTeamId);
                                    
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
            if (team != null)
            {
                var nflTeam = _mapper.Map<NFLTeam>(team);
                _nflTeamService.SaveNFLTeam(nflTeam);
            }
        }
    }
}
