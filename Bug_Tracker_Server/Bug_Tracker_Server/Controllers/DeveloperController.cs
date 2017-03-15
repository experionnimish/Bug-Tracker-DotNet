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
        [System.Web.Http.Route("api/Developer/GetBugsList")]
        public List<BugReportDto> GetBugsList([FromUri] string Type, [FromBody] UserDto User)
        {
            IGetBugsListService = new GetBugsListService();
            return IGetBugsListService.GetBugsDeveloper(Type, User);
        }
        IUpdateBugsService IUpdateBugsService;
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Developer/UpdateBugStatus")]
        public bool UpdateBugStatus([FromUri] string BugStatus, [FromUri] int BugId, [FromBody] UserDto User)
        {
            IUpdateBugsService = new UpdateBugsService();
            return IUpdateBugsService.ChangeBugStatus(BugStatus, BugId, User);
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Developer/BugHistory")]
        public List<BugReportDto> BugHistory([FromUri] string Type, [FromBody] UserDto User)
        {
            IGetBugsListService = new GetBugsListService();
            return IGetBugsListService.GetBugsDeveloperHistory(Type, User);
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Developer/RejectedBugs")]
        public List<BugReportDto> RejectedBugs([FromUri] string Type, [FromBody] UserDto User)
        {
            IGetBugsListService = new GetBugsListService();
            return IGetBugsListService.GetBugsDeveloperRejected(Type, User);
        }
    }
}