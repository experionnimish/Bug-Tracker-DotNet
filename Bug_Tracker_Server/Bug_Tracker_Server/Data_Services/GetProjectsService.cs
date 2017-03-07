using Bug_Tracker_Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bug_Tracker_Server.Data_Services
{
    public class GetProjectsService : IGetProjectsService
    {
        bug_trackerEntities entities = new bug_trackerEntities();
        public List<SelectListItem> GetProjects(user userObj)
        {
            var query = (from pt in entities.project_team
                          join us in entities.users on pt.team_user_id equals us.user_id
                          join pj in entities.projects on pt.team_project_id equals pj.project_id
                          where us.user_id == userObj.user_id && pj.project_status == "Open"
                          select new SelectListItem
                          {
                              Value = pj.project_id.ToString(),
                              Text = pj.project_name
                          }).ToList();
            return query;
        }
    }
}