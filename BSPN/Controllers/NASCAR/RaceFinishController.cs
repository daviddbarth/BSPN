using BSPN.Security;
using BSPN.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BSPN.Controllers.Races
{
    public class RaceFinishController : ApiController
    {
        private readonly IRaceService _raceService;

        public RaceFinishController(IRaceService raceService)
        {
            _raceService = raceService;
        }

        [AcceptVerbs("GET")]
        [ClaimsAuthorizeAPI("View", "RacePicks")]
        public RaceInfo Get(int id)
        {
            var raceFinishes = _raceService.GetRaceFinishes(id);
            return raceFinishes;
        }

        // POST: api/RaceScores
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/RaceScores/5
        public void Put(int id, [FromBody]string value)
        {
        }

    }
}
