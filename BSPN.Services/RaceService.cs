using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using BSPN.Data;
using AutoMapper;

namespace BSPN.Services
{
    public interface IRaceService
    {
        IList<Race> GetRaces(int season);
        RacePicks GetRacePicks(string userId, int raceId);
        void SaveRacePicks(string userId, RacePicks picks);
    }

    public class RaceService : IRaceService
    {
        private IRepository<Race> _raceRepos;
        private IRepository<Driver> _driverRepos;
        private IRepository<RacePick> _picksRepos;
        
        private IUnitOfWork _unitOfWork;

        public RaceService(IRepository<Race> raceRepos, IRepository<Driver> driverRepos, IRepository<RacePick> picksRepos, IUnitOfWork unitOfWork)
        {
            _raceRepos = raceRepos;
            _driverRepos = driverRepos;
            _picksRepos = picksRepos;
            _unitOfWork = unitOfWork;
        }

        public IList<Race> GetRaces(int season)
        {
            return _raceRepos.FindAll(r => r.Season == season).ToList();
        }

        public RacePicks GetRacePicks(string userId, int raceId)
        {
            var currentPicks = _picksRepos.FindAll(p => p.RaceId == raceId && p.UserId == userId);
            var drivers = _driverRepos.FindAll().ToList();
            var race = _raceRepos.Find(raceId);

            Mapper.CreateMap<Race, RacePicks>();
            Mapper.CreateMap<Driver, RacePickDriver>();

            var racePicks = Mapper.Map<RacePicks>(race);
            var racePickDrivers = Mapper.Map<List<Driver>, List<RacePickDriver>>(drivers);

            racePicks.Drivers = racePickDrivers;

            if (currentPicks != null)
            {
                foreach (var driver in currentPicks)
                    racePickDrivers.First(d => d.DriverId == driver.DriverId).Selected = true;
            }

            return racePicks;
        }

        public void SaveRacePicks(string userId, RacePicks picks)
        {
            var selectedDrivers = picks.SelectedDrivers();

            ValidateDriverPicks(selectedDrivers);

            var currentPicks = _picksRepos.FindAll(p => p.RaceId == picks.RaceId && p.UserId == userId);

            foreach (var pick in currentPicks)
                _picksRepos.Remove(pick);

            foreach (var driver in selectedDrivers)
                _picksRepos.Add(new RacePick() { RaceId = picks.RaceId, UserId = userId, DriverId = driver.DriverId });

            _unitOfWork.Commit();

        }

        private void ValidateDriverPicks(List<Driver> selectedDrivers)
        {
            if (selectedDrivers.Count != 5)
                throw new ApplicationException("Invalid Driver Picks: You must pick 5 drivers.");

        }

    }
}
;