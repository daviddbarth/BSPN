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
            var seasonRepos = new Repository<NFLSeason>(context);
            var unitOfWork = new UnitOfWork(context);

            var nflService = new NFLSeasonService(seasonRepos, unitOfWork);
            var season = nflService.GetNFLSeason(1);


        }
    }
}
