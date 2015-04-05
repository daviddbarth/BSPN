using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSNTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new BSPN.Data.SportsEntities();
            var repos = new DataAccess.Repository<BSPN.Data.Driver>(context);

            var DriverList = repos.FindAll();

            foreach (var driver in DriverList)
                Console.WriteLine(driver.LastName);
        }
    }
}
