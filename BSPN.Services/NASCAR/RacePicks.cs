using AutoMapper;
using BSPN.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSPN.Services
{
    public class RaceInfo
    {
        public int RaceId { get; set; }
        public string RaceName { get; set; }
        public string TrackName { get; set; }
        public List<RaceDriver> Drivers { get; set; }

        public List<Driver> SelectedDrivers()
        {
            var selectedPicks = Drivers.FindAll(d => d.Selected).ToList();
            Mapper.CreateMap<RaceDriver, Driver>();

            return Mapper.Map<List<RaceDriver>, List<Driver>>(selectedPicks);
        }
    }

    public class RaceDriver
    {
        public int DriverId { get; set; }
        public int CarNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public bool Selected { get; set; }
        public int Finish { get; set; }
    }
}
