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
            var repos = new DataAccess.Repository<BSPN.Data.SecurityClaim>(context);

            var claimList = repos.FindAll(r => r.ClaimId > 0);
        }
    }
}
