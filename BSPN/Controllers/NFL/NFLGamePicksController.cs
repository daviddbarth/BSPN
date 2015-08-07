using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BSPN.Transformation;
using BSPN.Transformation.Adapters;

namespace BSPN.Controllers.NFL
{
    public class NFLGamePicksController : ApiController
    {
        private readonly INFLGamePicksAdapter _gamePicksAdapter;

        public NFLGamePicksController(INFLGamePicksAdapter gamePicksAdapter)
        {
            _gamePicksAdapter = gamePicksAdapter;
        }

        public NFLWeekDTO Get()
        {
            return _gamePicksAdapter.GetCurrentWeekPicks();
        }
    }
}
