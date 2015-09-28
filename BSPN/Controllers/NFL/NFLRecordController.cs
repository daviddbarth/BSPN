using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BSPN.Transformation;

namespace BSPN.Controllers
{
    public class NFLRecordController : ApiController
    {
        INFLPicksRecordsAdapter _picksAdapter;

        public NFLRecordController(INFLPicksRecordsAdapter picksAdapter)
        {
            _picksAdapter = picksAdapter;
        }

        public NFLWeeklyPicksRecords Get()
        {
            return _picksAdapter.GetWeeklyPicksRecord();
        }

    }
}
