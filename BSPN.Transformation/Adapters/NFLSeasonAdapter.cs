using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSPN.Services;
using BSPN.Data;

namespace BSPN.Transformation
{
    public interface INFLSeasonAdapter
    {
        INFLSeasonDTO GetNFLSeason(int seasonId);
    }

    public class NFLSeasonAdapter : INFLSeasonAdapter
    {
        private static INFLSeasonService _nflSeasonService;
        private readonly IBSNMapper _mapper;

        public NFLSeasonAdapter(INFLSeasonService nflSeasonService, IBSNMapper mapper)
        {
            _nflSeasonService = nflSeasonService;
            _mapper = mapper;

            CreateMaps();
        }

        private void CreateMaps()
        {
            _mapper.CreateMap<NFLSeason, INFLSeasonDTO>();
        }

        public INFLSeasonDTO GetNFLSeason(int seasonId)
        {
            var season = _nflSeasonService.GetNFLSeason(seasonId);
            return _mapper.Map<INFLSeasonDTO>(season);
        }
    }
}
