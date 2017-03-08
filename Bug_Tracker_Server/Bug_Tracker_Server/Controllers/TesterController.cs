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
        public List<SelectListItem> GetProjects(user userObj)
        {
            IGetProjectsService = new GetProjectsService();
            return IGetProjectsService.GetProjects(userObj);
        }
        IReportBugService IReportBugService;
        public bool ReportBug(BugDto Bug)
        {
            IReportBugService = new ReportBugService();
            return IReportBugService.ReportBug(Bug);
        }
    }
}