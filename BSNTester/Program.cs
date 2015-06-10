using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSPN.Services;
using DataAccess;
using BSPN.Data;

namespace BSNTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new BSPN.Data.SportsEntities();
            var teamRepos = new Repository<NFLTeam>(context);
            var unitOfWork = new UnitOfWork(context);

            var nflService = new NFLTeamService(teamRepos, unitOfWork);
            var team = new NFLTeam() {City = "Arizona", TeamName = "Cardinals"};


            
            nflService.SaveNFLTeam(team);
        }
    }
}
