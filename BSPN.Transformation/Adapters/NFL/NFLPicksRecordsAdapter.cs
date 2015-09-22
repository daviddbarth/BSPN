using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSPN.Transformation.Adapters
{
    public interface INFLPicksRecordsAdapter
    {
        NFLWeeklyPicksRecords GetWeeklyPicksRecord(int weekId);
    }

    public class NFLPicksRecordsAdapter : INFLPicksRecordsAdapter
    {
        public NFLWeeklyPicksRecords GetWeeklyPicksRecord(int weekId)
        {

        }
    }
}
