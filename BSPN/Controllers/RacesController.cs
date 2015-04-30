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
        public JsonResult<List<Race>> GetRaces(int id)
        {
            var races = _raceService.GetRaces(id);

            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            return Json(races.ToList(), serializerSettings);
        }

        [AcceptVerbs("GET")]
        public JsonResult<List<Race>> GetRaces()
        {
            var season = DateTime.Now.Year;
            var races = _raceService.GetRaces(season);

            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            return Json(races.ToList(), serializerSettings);
        }

    }
}
