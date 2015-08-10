using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BSPN.Security;
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
            return _gamePicksAdapter.GetCurrentWeekPicks(SecurityHelpers.GetUserId());
        }

        public void Post(NFLWeekDTO value)
        {
            try
            {
                var userId = SecurityHelpers.GetUserId();
                _gamePicksAdapter.SaveCurrentWeeksPicks(value, userId);
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "Invalid Request"
                };

                throw new HttpResponseException(resp);
            }
        }
    }
}
