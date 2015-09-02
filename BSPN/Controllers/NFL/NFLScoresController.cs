using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BSPN.Security;
using BSPN.Transformation;
using BSPN.Transformation.Adapters;

namespace BSPN.Controllers.NFL
{
    public class NFLScoresController : ApiController
    {
        private INFLScoresAdapter _scoresAdapter;

        public NFLScoresController(INFLScoresAdapter scoresAdapter)
        {
            _scoresAdapter = scoresAdapter;
        }

        public NFLWeekDTO Get()
        {
            return _scoresAdapter.GetCurrentWeekScores();
        }
    }
}
