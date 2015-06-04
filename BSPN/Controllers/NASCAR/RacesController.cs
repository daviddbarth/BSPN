using BSPN.Data;
using BSPN.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace BSPN.Controllers
{
    public class RacesController : ApiController
    {
        private readonly IRaceService _raceService;

        public RacesController(IRaceService raceService)
        {
            _raceService = raceService;
        }

        [AcceptVerbs("GET")]
        public HttpResponseMessage GetRaces(int id)
        {
            return RaceData(id);
        }

        [AcceptVerbs("GET")]
        public HttpResponseMessage GetRaces()
        {
            return RaceData(DateTime.Now.Year);
        }

        private HttpResponseMessage RaceData(int season)
        {
            var races = _raceService.GetRaces(season);
            var raceData = races.Select(r => new { r.RaceName, r.Track.TrackName, r.RaceId });

            return Request.CreateResponse(HttpStatusCode.OK, raceData);
        }
    }
}
