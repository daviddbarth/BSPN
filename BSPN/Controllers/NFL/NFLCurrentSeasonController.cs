using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BSPN.Transformation;

namespace BSPN.Controllers.NFL
{
    public class NFLCurrentSeasonController : ApiController
    {
        private readonly INFLSeasonAdapter _seasonAdapter;

        public NFLCurrentSeasonController(INFLSeasonAdapter seasonAdapter)
        {
            _seasonAdapter = seasonAdapter;
        }

        public NFLSeasonDTO Get()
        {
            try
            {
                return _seasonAdapter.GetCurrentNFLSeason();
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        public void Post(NFLSeasonDTO value)
        {
            var x = value;
        }
    }
}
