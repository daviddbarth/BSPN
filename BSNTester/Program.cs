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
            var repos = new Repository<NFLGame>(context);

            var gamePicks = context.NFLGamePicks;
            var games = context.NFLGames;

            IQueryable<NFLGamePick> query =
                from NflGamePicks in gamePicks
                join NflGames in games on NflGamePicks.NFLGameId equals NflGames.NFLGameId
                where NflGames.NFLWeekId == 1
                select NflGamePicks;

            foreach (var pick in query)
            {
                Console.WriteLine("GameId: {0} TeamId: {1}", pick.NFLGameId, pick.NFLTeamId);
            }

            var gameP = context.NFLGamePicks.Include("NFLGame").Where(g => g.NFLTeamId == 1);

            
            

            Console.ReadLine();

        }
    }
}

//using (AdventureWorksEntities context = new AdventureWorksEntities())
//{
//    ObjectSet<SalesOrderHeader> orders = context.SalesOrderHeaders;
//    ObjectSet<SalesOrderDetail> details = context.SalesOrderDetails;

//    var query =
//        from order in orders
//        join detail in details
//        on order.SalesOrderID
//        equals detail.SalesOrderID into orderGroup
//        select new
//        {
//            CustomerID = order.SalesOrderID,
//            OrderCount = orderGroup.Count()
//        };

//    foreach (var order in query)
//    {
//        Console.WriteLine("CustomerID: {0}  Orders Count: {1}",
//            order.CustomerID,
//            order.OrderCount);
//    }
//}