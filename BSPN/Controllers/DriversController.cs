﻿using BSPN.Data;
using BSPN.Security;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Results;

namespace BSPN.Controllers
{
    public class DriversController : ApiController
    {
        private IRepository<Driver> _driverRepos;

        public DriversController() { }

        public DriversController(IRepository<Driver> driverRepos)
        {
            _driverRepos = driverRepos;
        }

        [AcceptVerbs("GET")]
        [ClaimsAuthorizeAPI("View", "Drivers")]
        public JsonResult<List<Driver>> Drivers()
        {
            var context = new SportsEntities();
            var driverRepos = new Repository<Driver>(context);
            var driverList = driverRepos.FindAll();

            var x = User.Identity;

            
            return Json(driverList.ToList());
        }
    }

}
