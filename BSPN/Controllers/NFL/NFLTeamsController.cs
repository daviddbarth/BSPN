using System.Collections.Generic;
using System.Web.Http;
using BSPN.Transformation;
using BSPN.Security;

//https://msdn.microsoft.com/en-us/magazine/ee236638.aspx

namespace BSPN.Controllers
{
    public class NFLTeamsController : ApiController
    {
        private readonly INFLTeamAdapter _nflAdapter;

        public NFLTeamsController(INFLTeamAdapter nflAdapter)
        {
            _nflAdapter = nflAdapter;
        }

        [AcceptVerbs("GET")]
        [ClaimsAuthorizeAPI("Edit", "NFL")]
        public IEnumerable<NFLTeamDTO> Get()
        {
            return _nflAdapter.GetNFLTeams();
        }

        //[AcceptVerbs("GET")]
        //[ClaimsAuthorizeAPI("Edit", "NFL")]
        //public NFLTeamDTO Get(int id)
        //{
        //    return _nflAdapter.GetNFLTeam(id);
        //}

        [AcceptVerbs("POST")]
        [ClaimsAuthorizeAPI("Admin", "NFL")]
        public void Post(NFLTeamDTO value)
        {
            _nflAdapter.SaveNFLTeam(value);
        }
    }
}
