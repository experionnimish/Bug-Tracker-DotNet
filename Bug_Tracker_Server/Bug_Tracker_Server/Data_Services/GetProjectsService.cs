using Bug_Tracker_Server.Data;
using BugTrackerDTOs;
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
        public List<SelectListItem> GetProjectsAdmin(user userObj)
        {
            var query = (from us in entities.users
                         join pj in entities.projects on us.user_id equals pj.project_manager_id
                         where us.user_id == userObj.user_id && pj.project_status == "Open"
                         select new SelectListItem
                         {
                             Value = pj.project_id.ToString(),
                             Text = pj.project_name
                         }).ToList();
            return query;
        }
        public List<ProjectDto> GetTasks(UserDto User)
        {
            ProjectDto Project;
            List<ProjectDto> ProjectList = new List<ProjectDto>();
            var query = (from pt in entities.project_team
                         join us in entities.users on pt.team_user_id equals us.user_id
                         join pj in entities.projects on pt.team_project_id equals pj.project_id
                         join us2 in entities.users on pj.project_manager_id equals us2.user_id
                         where (us.user_id == User.user_id) && pj.project_status == "Open"
                         select new
                         {
                             pj, us2
                         }).ToList();
            foreach(var item in query)
            {
                Project = new ProjectDto();
                Project.project_id = item.pj.project_id;
                Project.project_name = item.pj.project_name;
                Project.project_manager_name = item.us2.user_name;
                ProjectList.Add(Project);
            }
            return ProjectList;
        }
    }
}