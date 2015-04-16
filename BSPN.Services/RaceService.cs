using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using BSPN.Data;

namespace BSPN.Services
{
    public class RaceService
    {
        private IRepository<Race> _raceRepos;
        private IUnitOfWork _unitOfWork;

        public RaceService()
        {
            var context = new SportsEntities();
            _unitOfWork = new UnitOfWork(context);
            _raceRepos = new Repository<Race>(context);
        }

        public IList<Race> GetRaces(int season)
        {
            return _raceRepos.FindAll(r => r.Season == season).ToList();
        }
    }
}
