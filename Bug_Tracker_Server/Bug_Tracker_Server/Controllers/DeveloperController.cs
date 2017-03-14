using Bug_Tracker_Server.Data_Services;
using BugTrackerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Bug_Tracker_Server.Controllers
{
    public class DeveloperController : ApiController
    {
        // GET: Developer
        IGetBugsListService IGetBugsListService;
        [System.Web.Http.HttpPost]
        public List<BugReportDto> GetBugsList([FromUri] string Type, [FromBody] UserDto User)
        {
            IGetBugsListService = new GetBugsListService();
            return IGetBugsListService.GetBugsTester(Type, User);
        }
    }
}