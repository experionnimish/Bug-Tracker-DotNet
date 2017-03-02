using Bug_Tracker_Server.Data;
using BugTrackerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bug_Tracker_Server.Mapping
{
    public class ProjectTeamEntityDto
    {
        public static ProjectTeamDto ToDto(project_team projectteamobj)
        {
            ProjectTeamDto projectTeamDto = new ProjectTeamDto();
            if (projectteamobj != null)
            {
                projectTeamDto.team_sl_no = projectteamobj.team_sl_no;
                projectTeamDto.team_project_id = projectteamobj.team_project_id;
                projectTeamDto.team_user_id = projectteamobj.team_user_id;
            }
            return projectTeamDto;
        }
        public static project_team ToEntity(ProjectTeamDto projectTeamDto)
        {
            project_team projectteamobj = new project_team();
            if (projectTeamDto != null)
            {
                projectteamobj.team_sl_no = projectTeamDto.team_sl_no;
                projectteamobj.team_project_id = projectTeamDto.team_project_id;
                projectteamobj.team_user_id = projectTeamDto.team_user_id;
            }
            return projectteamobj;
        }
    }
}