using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSPN.Data;
using BSPN.Services;

namespace BSPN.Transformation.Adapters
{
    public interface INFLScoresAdapter
    {
        NFLWeekDTO GetCurrentWeekScores();
        void SaveWeekScores(NFLWeekDTO week);
    }

    public class NFLScoresAdapter : NFLGameAdapter, INFLScoresAdapter
    {
        public NFLScoresAdapter(INFLSeasonService nflSeasonService, IBSNMapper mapper)
            : base(nflSeasonService, mapper)
        {

        }

        public NFLWeekDTO GetCurrentWeekScores()
        {
            var currentWeek = GetMappedCurrentWeek();

            return currentWeek;
        }

        public void SaveWeekScores(NFLWeekDTO week)
        {
            
        }
    }
}
