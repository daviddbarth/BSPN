using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSPN.Services;

namespace BSPN.Transformation
{
    public interface INFLPicksRecordsAdapter
    {
        NFLWeeklyRecords GetWeeklyPicksRecord();
    }

    public class NFLPicksRecordsAdapter : INFLPicksRecordsAdapter
    {
        private INFLSeasonService _nflSeasonService;

        public NFLPicksRecordsAdapter(INFLSeasonService nflSeasonService)
        {
            _nflSeasonService = nflSeasonService;
        }

        public NFLWeeklyRecords GetWeeklyPicksRecord()
        {
            var nflWeeks = _nflSeasonService.GetNFLWeeks();
            var records = _nflSeasonService.GetNFLRecords();
            var players = _nflSeasonService.GetNFLPicksPlayers();

            var weeklyRecords = new NFLWeeklyRecords();

            foreach(var week in nflWeeks)
            {
                if (records.Count(r => r.NFLWeekId == week.NFLWeekId) == 0)
                    continue;

                var weekRecord = new NFLWeekRecord() { NFLWeekId = week.NFLWeekId, NFLWeekDescription = week.Description };
                var numberOfGames = _nflSeasonService.GetTotalCompleteGamesCount(week.NFLWeekId);

                foreach(var player in players)
                {
                    var nflPlayerRecord = new NFLPlayerRecord();

                    nflPlayerRecord.Player.LastName = player.LastName;
                    nflPlayerRecord.Player.FirstName = player.FirstName;
                    nflPlayerRecord.Player.NickName = player.NickName;
                    nflPlayerRecord.NFLWeekId = week.NFLWeekId;
                    nflPlayerRecord.WinsCount = 0;
                    nflPlayerRecord.LosesCount = numberOfGames;

                    foreach(var record in records.Where(r => r.NFLWeekId == week.NFLWeekId && r.UserId == player.Id))
                    {                        
                        nflPlayerRecord.WinsCount = record.Wins;
                        nflPlayerRecord.LosesCount = numberOfGames - record.Wins;
                    }

                    weekRecord.NFLPlayerRecords.Add(nflPlayerRecord);
                }

                weeklyRecords.WeeklyRecords.Add(weekRecord);
            }

            return weeklyRecords;
        }
    }
}
