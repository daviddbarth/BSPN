using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSPN.Services;
using BSPN.Data;

namespace BSPN.Transformation
{
    public interface INFLPicksRecordsAdapter
    {
        NFLWeeklyPicksRecords GetWeeklyPicksRecord();
    }

    public class NFLPicksRecordsAdapter : INFLPicksRecordsAdapter
    {
        private INFLSeasonService _nflSeasonService;

        public NFLPicksRecordsAdapter(INFLSeasonService nflSeasonService)
        {
            _nflSeasonService = nflSeasonService;
        }

        public NFLWeeklyPicksRecords GetWeeklyPicksRecord()
        {
            var currentSeason = _nflSeasonService.GetCurrentNFLSeason();
            var nflWeeks = _nflSeasonService.GetNFLWeeks();
            var records = _nflSeasonService.GetNFLRecords();
            var players = _nflSeasonService.GetNFLPicksPlayers();
            
            var weeklyRecords = new NFLWeeklyPicksRecords();

            foreach(var week in nflWeeks)
            {
                if (records.Count(r => r.NFLWeekId == week.NFLWeekId) == 0)
                    continue;

                var weekRecord = new NFLWeekPicksRecord() { NFLWeekId = week.NFLWeekId, NFLWeekDescription = week.Description };
                var numberOfGames = _nflSeasonService.GetTotalCompleteGamesCount(week.NFLWeekId);

                foreach(var player in players)
                {
                    weekRecord.NFLPlayerRecords.Add(CreatePlayerPicksRecord(player, week, records, numberOfGames));
                }

                weeklyRecords.WeeklyRecords.Add(weekRecord);

                if (week.NFLWeekId == currentSeason.CurrentWeekId) weeklyRecords.CurrentWeekRecords = weekRecord;

            }

            return weeklyRecords;
        }

        private NFLPlayerPicksRecord CreatePlayerPicksRecord(AspNetUser player, NFLWeek week, IEnumerable<NFLPickRecord> records, int numberOfGames)
        {
            var nflPlayerRecord = new NFLPlayerPicksRecord();

            nflPlayerRecord.Player.LastName = player.LastName;
            nflPlayerRecord.Player.FirstName = player.FirstName;
            nflPlayerRecord.Player.NickName = player.NickName;
            nflPlayerRecord.NFLWeekId = week.NFLWeekId;
            nflPlayerRecord.WinsCount = 0;
            nflPlayerRecord.LosesCount = numberOfGames;

            foreach (var record in records.Where(r => r.NFLWeekId == week.NFLWeekId && r.UserId == player.Id))
            {
                nflPlayerRecord.WinsCount = record.Wins;
                nflPlayerRecord.LosesCount = numberOfGames - record.Wins;
            }

            return nflPlayerRecord;
        }
    }
}
