using BSPN.Transformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BSPN.Controllers
{
    public class NFLSeasonController : ApiController
    {
        private readonly INFLSeasonAdapter _seasonAdapter;

        public NFLSeasonController(INFLSeasonAdapter seasonAdapter)
        {
            _seasonAdapter = seasonAdapter;
        }

        public INFLSeasonDTO Get(int id)
        {
            return _seasonAdapter.GetNFLSeason(id);
        }
    }
}
