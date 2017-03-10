using Bug_Tracker_Server.Data;
using BugTrackerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bug_Tracker_Server.Data_Services
{
    public class GetTeamMembersService : IGetTeamMembersService
    {
        bug_trackerEntities entities = new bug_trackerEntities();
        public List<UserDto> GetTeamMembers(int UserClass, UserDto User)
        {
            UserDto Dev;
            List<UserDto> Devs = new List<UserDto>();
            //SELECT project_team.user_id AS devID, users.name AS devName, projects.id AS projectId
            //FROM projects
            //JOIN project_team
            //JOIN users ON projects.manager_id = ?
            //AND projects.id = project_team.project_id
            //AND project_team.user_id = users.id
            //AND users.class = 2 
            //AND projects.status = 'Open'
            var Query = from projects in entities.projects
                       from project_team in entities.project_team
                       from users in entities.users.Where(x => projects.project_manager_id == User.user_id && projects.project_id == project_team.team_project_id && project_team.team_user_id == x.user_id && x.user_class == UserClass && projects.project_status == "Open")
                       select new { users };
            var QueryList = Query.ToList();
            foreach(var item in QueryList)
            {
                Dev = new UserDto();
                Dev.user_id = item.users.user_id;
                Dev.user_name = item.users.user_name;
                Devs.Add(Dev);
            }
            return (Devs);
        }
}
}