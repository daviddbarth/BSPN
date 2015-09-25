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
            var records = _nflSeasonService.GetNFLRecords();
            var weeklyRecords = new NFLWeeklyRecords();

            foreach(var record in records)
            {
                var weekRecord = new NFLWeekRecord();
  
                weekRecord.WeekId = record.NFLWeekId;
                weekRecord.Player.LastName = record.LastName;
                weekRecord.Player.FirstName = record.FirstName;
                weekRecord.Player.NickName = record.NickName;
                weekRecord.WinsCount = record.Wins;

                weeklyRecords.WeeklyRecords.Add(weekRecord);
            }

            return weeklyRecords;
        }
    }
}
