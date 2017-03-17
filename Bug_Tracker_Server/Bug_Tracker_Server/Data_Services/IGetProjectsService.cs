using Bug_Tracker_Server.Data;
using BugTrackerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bug_Tracker_Server.Data_Services
{
    interface IGetProjectsService
    {
        List<SelectListItem> GetProjects(user userObj);
        List<ProjectDto> GetTasks(UserDto User);
        List<SelectListItem> GetProjectsAdmin(user userObj);
        bool AddProject(ProjectDto Project);
        bool RemoveProject(int[] ProjectId);
    }
}
