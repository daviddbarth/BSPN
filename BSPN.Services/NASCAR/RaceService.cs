using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess;
using BSPN.Data;
using AutoMapper;

namespace BSPN.Services
{
    public interface IRaceService
    {
        IList<Race> GetRaces(int season);
        RaceInfo GetRacePicks(string userId, int raceId);
        void SaveRacePicks(string userId, RaceInfo picks);
        RaceInfo GetRaceFinishes(int raceId);
    }

    public class RaceService : IRaceService
    {
        private readonly IRepository<Race> _raceRepos;
        private readonly IRepository<Driver> _driverRepos;
        private readonly IRepository<RacePick> _picksRepos;
        private readonly IRepository<RaceFinish> _raceScoreRepos;

        private readonly IUnitOfWork _unitOfWork;

        public RaceService(IRepository<Race> raceRepos, IRepository<Driver> driverRepos, IRepository<RacePick> picksRepos,
            IRepository<RaceFinish> raceScoreRepos, IUnitOfWork unitOfWork)
        {
            _raceRepos = raceRepos;
            _driverRepos = driverRepos;
            _picksRepos = picksRepos;
            _raceScoreRepos = raceScoreRepos;

            _unitOfWork = unitOfWork;
        }

        public IList<Race> GetRaces(int season)
        {
            return _raceRepos.FindAll(r => r.Season == season).ToList();
        }

        public RaceInfo GetRacePicks(string userId, int raceId)
        {
            var currentPicks = _picksRepos.FindAll(p => p.RaceId == raceId && p.UserId == userId);
            var drivers = _driverRepos.FindAll().ToList();
            var race = _raceRepos.Find(raceId);

            Mapper.CreateMap<Race, RaceInfo>();
            Mapper.CreateMap<Driver, RaceDriver>();

            var racePicks = Mapper.Map<RaceInfo>(race);
            var racePickDrivers = Mapper.Map<List<Driver>, List<RaceDriver>>(drivers);

            racePicks.Drivers = racePickDrivers;

            if (currentPicks != null)
            {
                foreach (var driver in currentPicks)
                    racePickDrivers.First(d => d.DriverId == driver.DriverId).Selected = true;
            }

            return racePicks;
        }

        public void SaveRacePicks(string userId, RaceInfo picks)
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

        private static void ValidateDriverPicks(List<Driver> selectedDrivers)
        {
            if (selectedDrivers.Count != 5)
                throw new ApplicationException("Invalid Driver Picks: You must pick 5 drivers.");

        }

        public RaceInfo GetRaceFinishes(int raceId)
        {
            var race = _raceRepos.Find(raceId);
            var selectedDrivers = race.RacePicks
                .Select(d => new { driverId = d.DriverId })
                .Distinct();


            Mapper.CreateMap<Race, RaceInfo>();
            Mapper.CreateMap<Driver, RaceDriver>();

            var raceInfo = Mapper.Map<RaceInfo>(race);
            raceInfo.TrackName = race.Track.TrackName;

            selectedDrivers.ToList().ForEach(d => raceInfo.Drivers.Add(GetRaceDriver((int)d.driverId)));

            return raceInfo;
        }

        private RaceDriver GetRaceDriver(int driverId)
        {
            var driver = _driverRepos.Find(driverId);
            var raceDriver = Mapper.Map<RaceDriver>(driver);

            return raceDriver;

        }
    }
}
