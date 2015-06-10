using BSPN.Data;
using BSPN.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BSPN.Transformation;

//https://msdn.microsoft.com/en-us/magazine/ee236638.aspx

namespace BSPN.Controllers
{
    public class NFLTeamsController : ApiController
    {
        private INFLTeamAdapter _nflAdapter;

        public NFLTeamsController(INFLTeamAdapter nflAdapter)
        {
            _nflAdapter = nflAdapter;
        }

        [AcceptVerbs("GET")]
        public IEnumerable<INFLTeamDTO> Get()
        {
            return _nflAdapter.GetNFLTeams();
        }

        [AcceptVerbs("GET")] 
        public INFLTeamDTO Get(int id)
        {
            return _nflAdapter.GetNFLTeamSchedule(id);
        }

        [AcceptVerbs("PUT")]
        public void Put(INFLTeamDTO value)
        {
            _nflAdapter.SaveNFLTeam(value);
        }
    }
}
