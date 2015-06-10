using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using BSPN.Data;
using AutoMapper;
using BSPN.Services;

namespace BSPN.Transformation
{
    public interface INFLTeamAdapter 
    {
        IEnumerable<INFLTeamDTO> GetNFLTeams();
        INFLTeamDTO GetNFLTeam(int nflTeamId);
        INFLTeamDTO GetNFLTeamSchedule(int nflTeamId);
        void SaveNFLTeam(INFLTeamDTO team);
    }

    public class NFLTeamAdapter : INFLTeamAdapter
    {
        private IMappingEngine _mapper;
        private INFLTeamService _nflTeamService;

        public NFLTeamAdapter(INFLTeamService nflTEamService, IMappingEngine mapper)
        {
            _nflTeamService = nflTEamService;

             _mapper = mapper;
             _mapper.ConfigurationProvider.CreateTypeMap(typeof(NFLTeam), typeof(INFLTeamDTO));
             _mapper.ConfigurationProvider.CreateTypeMap(typeof(NFLGame), typeof(INFLGameDTO));

             _mapper.ConfigurationProvider.CreateTypeMap(typeof(INFLTeamDTO), typeof(NFLTeam));
            
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

        public INFLTeamDTO GetNFLTeamSchedule(int nflTeamId)
        {
            var nflTeam = _nflTeamService.GetNFLTeam(nflTeamId);
            var nflTeamDTO = _mapper.Map<INFLTeamDTO>(nflTeam);

            nflTeamDTO.Schedule = nflTeam.NFLGames.Select(game => _mapper.Map<INFLGameDTO>(game));
            return nflTeamDTO;
            
        }

        public void SaveNFLTeam(INFLTeamDTO team)
        {
            var nflTeam = _mapper.Map<NFLTeam>(team);
            _nflTeamService.SaveNFLTeam(nflTeam);
        }
    }
}
