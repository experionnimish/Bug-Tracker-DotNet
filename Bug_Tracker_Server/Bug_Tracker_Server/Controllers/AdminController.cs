﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using BugTrackerDTOs;
using Bug_Tracker_Server.Data_Services;

namespace Bug_Tracker_Server.Controllers
{
    public class AdminController : ApiController
    {
        // GET: Admin
        IGetBugsListService IGetBugsListService;
        [System.Web.Http.HttpPost]
        public List<BugReportDto> GetBugsList([FromUri] string Type, [FromBody] UserDto User)
        {
            IGetBugsListService = new GetBugsListService();
            return IGetBugsListService.GetBugsAdmin(Type, User);
        }
    }
}