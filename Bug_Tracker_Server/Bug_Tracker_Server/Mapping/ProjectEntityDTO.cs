using Bug_Tracker_Server.Data;
using BugTrackerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bug_Tracker_Server.Mapping
{
    public class ProjectEntityDto
    {
        public static ProjectDto ToDto(project projectobj)
        {
            ProjectDto projectDto = new ProjectDto();
            if (projectobj != null)
            {
                projectDto.project_id = projectobj.project_id;
                projectDto.project_name = projectobj.project_name;
                projectDto.project_manager_id = projectobj.project_manager_id;
                projectDto.project_status = projectobj.project_status;
            }
            return projectDto;
        }
        public static project ToEntity(ProjectDto projectDto)
        {
            project projectobj = new project();
            if (projectDto != null)
            {
                projectobj.project_id = projectDto.project_id;
                projectobj.project_name = projectDto.project_name;
                projectobj.project_manager_id = projectDto.project_manager_id;
                projectobj.project_status = projectDto.project_status;
            }
            return projectobj;
        }
    }
}