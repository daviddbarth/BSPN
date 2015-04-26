using AutoMapper;
using BSPN.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSPN.Services
{
    public class RacePicks
    {
        public int RaceId { get; set; }
        public string RaceName { get; set; }
        public List<RacePickDriver> Drivers { get; set; }

        public List<Driver> SelectedDrivers()
        {
            var selectedPicks = Drivers.FindAll(d => d.Selected).ToList();
            Mapper.CreateMap<RacePickDriver, Driver>();

            return Mapper.Map<List<RacePickDriver>, List<Driver>>(selectedPicks);
        }
    }

    public class RacePickDriver
    {
        public int DriverId { get; set; }
        public int CarNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public bool Selected { get; set; }
    }
}
