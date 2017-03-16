using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using BugTrackerDTOs;
using Bug_Tracker_Server.Data_Services;
using Bug_Tracker_Server.Data;

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
        IGetTeamMembersService IGetTeamMembersService;
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Admin/GetTeamMembers")]
        public List<MemberDto> GetTeamMembers([FromUri] int ProjectId, [FromUri] int UserClass, [FromBody] UserDto User)
        {
            IGetTeamMembersService = new GetTeamMembersService();
            return IGetTeamMembersService.GetTeamMembers(ProjectId, UserClass, User);
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Admin/GetTeamMembersAdd")]
        public List<MemberDto> GetTeamMembersAdd([FromUri] int ProjectId, [FromUri] int UserClass, [FromBody] UserDto User)
        {
            IGetTeamMembersService = new GetTeamMembersService();
            return IGetTeamMembersService.GetTeamMembersAdd(ProjectId, UserClass, User);
        }
        IUpdateBugsService IUpdateBugsService;
        [System.Web.Http.HttpPost]
        public bool AssignDeveloper([FromUri] int DeveloperId, [FromUri] int BugId, [FromBody] UserDto User)
        {
            IUpdateBugsService = new UpdateBugsService();
            return IUpdateBugsService.AssignDeveloper(DeveloperId, BugId, User);
        }
        [System.Web.Http.HttpPost]
        public bool RejectBugs([FromUri] string RejectReason, [FromUri] string BugStatus, [FromUri] int BugId, [FromBody] UserDto User)
        {
            IUpdateBugsService = new UpdateBugsService();
            return IUpdateBugsService.RejectBugs(RejectReason, BugStatus, BugId, User);
        }
        [System.Web.Http.HttpPost]
        public bool ApproveBugs([FromUri] string BugStatus, [FromUri] int BugId, [FromBody] UserDto User)
        {
            IUpdateBugsService = new UpdateBugsService();
            return IUpdateBugsService.ChangeBugStatus(BugStatus, BugId, User);
        }
        IGetProjectsService IGetProjectsService;
        [System.Web.Http.HttpPost]
        public List<SelectListItem> GetProjects(user userObj)
        {
            IGetProjectsService = new GetProjectsService();
            return IGetProjectsService.GetProjectsAdmin(userObj);
        }
    }
}