using Bug_Tracker_Server.Data;
using Bug_Tracker_Server.Data_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using BugTrackerDTOs;
using Bug_Tracker_Server.Mapping;

namespace Bug_Tracker_Server.Controllers
{
    public class TesterController : ApiController
    {
        // GET: Tester
        IGetProjectsService IGetProjectsService;
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Tester/GetProjects")]
        public List<SelectListItem> GetProjects(user userObj)
        {
            IGetProjectsService = new GetProjectsService();
            return IGetProjectsService.GetProjects(userObj);
        }
        IReportBugService IReportBugService;
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Tester/ReportBug")]
        public bool ReportBug(BugDto Bug)
        {
            IReportBugService = new ReportBugService();
            return IReportBugService.ReportBug(Bug);
        }
        IGetBugsListService IGetBugsListService;
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Tester/GetBugsList")]
        public List<BugReportDto> GetBugsList([FromUri] string Type, [FromBody] UserDto User)
        {
            IGetBugsListService = new GetBugsListService();
            return IGetBugsListService.GetBugsTester(Type, User);
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Tester/TrackBugs")]
        public List<BugReportDto> TrackBugs([FromUri] string Type, [FromBody] UserDto User)
        {
            IGetBugsListService = new GetBugsListService();
            return IGetBugsListService.GetBugsTesterTrack(Type, User);
        }
        IUpdateBugsService IUpdateBugsService;
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Tester/RejectBugs")]
        public bool RejectBugs([FromUri] string RejectReason, [FromUri] string BugStatus, [FromUri] int BugId, [FromBody] UserDto User)
        {
            IUpdateBugsService = new UpdateBugsService();
            return IUpdateBugsService.RejectBugs(RejectReason, BugStatus, BugId, User);
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Tester/ApproveBugs")]
        public bool ApproveBugs([FromUri] string BugStatus, [FromUri] int BugId, [FromBody] UserDto User)
        {
            IUpdateBugsService = new UpdateBugsService();
            return IUpdateBugsService.ApproveBugs(BugStatus, BugId, User);
        }
        public bool EditBug(BugDto Bug)
        {
            IUpdateBugsService = new UpdateBugsService();
            return IUpdateBugsService.EditBug(Bug);
        }
    }
}