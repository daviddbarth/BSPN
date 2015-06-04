using BSPN.Security;
using BSPN.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

namespace BSPN.Controllers
{
    public class RacePicksController : ApiController
    {
        private readonly IRaceService _raceService;

        public RacePicksController(IRaceService raceService)
        {
            _raceService = raceService;
        }

        [AcceptVerbs("GET")]
        [ClaimsAuthorizeAPI("View", "RacePicks")]
        public JsonResult<RaceInfo> Get(int id)
        {
            return Json(_raceService.GetRacePicks(GetUserId(), id));
        }

        [AcceptVerbs("POST")]
        [ClaimsAuthorizeAPI("Edit", "RacePicks")]
        public void Post(RaceInfo value)
        {
            try
            {
                _raceService.SaveRacePicks(GetUserId(), value);
            }
            catch(Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "Invalid Request"
                };

                throw new HttpResponseException(resp);
            }
        }

        private string GetUserId()
        {
            var claims = ((ClaimsPrincipal)HttpContext.Current.User).Claims;
            var userId = claims.First(c => c.Type.Contains("nameidentifier")).Value;

            return userId;
        }
    }
}     