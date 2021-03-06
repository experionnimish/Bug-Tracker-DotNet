﻿using Bug_Tracker_Server.Data;
using Bug_Tracker_Server.Mapping;
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
        public List<MemberDto> GetTeamMembers(int ProjectId, int UserClass, UserDto User)
        {
            MemberDto Dev;
            List<MemberDto> Devs = new List<MemberDto>();
            var Query = from projects in entities.projects
                       from project_team in entities.project_team
                       from users in entities.users.Where(x => projects.project_id == ProjectId && projects.project_manager_id == User.user_id && projects.project_id == project_team.team_project_id && project_team.team_user_id == x.user_id && x.user_class == UserClass && projects.project_status == "Open")
                       select new { users, projects };
            var QueryList = Query.ToList();
            foreach(var item in QueryList)
            {
                Dev = new MemberDto();
                Dev.user_id = item.users.user_id;
                Dev.user_employee_id = item.users.user_employee_id;
                Dev.user_name = item.users.user_name;
                Dev.project_id = item.projects.project_id;
                Dev.project_name = item.projects.project_name;
                Devs.Add(Dev);
            }
            return (Devs);
        }
        public List<MemberDto> GetTeamMembersAdd(int ProjectId, int UserClass, UserDto User)
        {
            MemberDto Dev;
            List<MemberDto> Devs = new List<MemberDto>();
            var Query1 = from projects in entities.projects
                        from project_team in entities.project_team
                        from users in entities.users.Where(x => projects.project_id == ProjectId && projects.project_manager_id == User.user_id && projects.project_id == project_team.team_project_id && project_team.team_user_id == x.user_id && x.user_class == UserClass && projects.project_status == "Open")
                        select new { users };
            var QueryList1 = Query1.ToList();
            var Query = from users in entities.users.Where(x => x.user_class == UserClass && x.user_flag == 1)
                        select new { users };
            var QueryList = Query.ToList();

            var difference = QueryList.Except(QueryList1).ToList();
            foreach (var item in difference)
            {
                Dev = new MemberDto();
                Dev.user_id = item.users.user_id;
                Dev.user_employee_id = item.users.user_employee_id;
                Dev.user_name = item.users.user_name;
                Devs.Add(Dev);
            }
            return (Devs);
        }
        public bool AddTeamMembers(AddTeamDto Member)
        {
            try
            {
                ProjectTeamDto Team;
                List<ProjectTeamDto> TeamList = new List<ProjectTeamDto>();
                foreach (var item in Member.members)
                {
                    Team = new ProjectTeamDto();
                    Team.team_user_id = item;
                    Team.team_project_id = Member.project_id;
                    TeamList.Add(Team);
                }
                foreach (var item in TeamList)
                {
                    entities.project_team.Add(ProjectTeamEntityDto.ToEntity(item));
                    entities.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool RemoveTeamMembers(AddTeamDto Member)
        {
            try
            {
                ProjectTeamDto Team;
                List<ProjectTeamDto> TeamList = new List<ProjectTeamDto>();
                foreach (var item in Member.members)
                {
                    Team = new ProjectTeamDto();
                    Team.team_user_id = item;
                    Team.team_project_id = Member.project_id;
                    TeamList.Add(Team);
                }
                foreach (var item in TeamList)
                {
                    var y = entities.project_team.Where(x => x.team_user_id == item.team_user_id && x.team_project_id == item.team_project_id).FirstOrDefault();
                    entities.project_team.Remove(y);
                    entities.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}