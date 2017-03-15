using Bug_Tracker_Server.Data;
using BugTrackerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bug_Tracker_Server.Data_Services
{
    public class GetBugsListService : IGetBugsListService
    {
        bug_trackerEntities entities = new bug_trackerEntities();
        public List<BugReportDto> GetBugsAdmin(string Type, UserDto User)
        {
            BugReportDto BugDetails;
            List<BugReportDto> BugDetailsList = new List<BugReportDto>();
            var bugReportDto = from bugs in entities.bugs
                               from projects in entities.projects
                               from users in entities.users.Where(x => (projects.project_id == bugs.bug_project_id && projects.project_manager_id == User.user_id) && (bugs.bug_tester_id == x.user_id || bugs.bug_developer_id == x.user_id || projects.project_manager_id == x.user_id) && bugs.bug_status == Type)
                               select new { bugs, projects, users };
            var BugReportDtoList = bugReportDto.ToList();
            int i = 0;

            while (i < BugReportDtoList.Count())
            {
                BugDetails = new BugReportDto();
                BugDetails.bug_id = BugReportDtoList[i].bugs.bug_id;
                BugDetails.bug_name = BugReportDtoList[i].bugs.bug_name;
                BugDetails.bug_type = BugReportDtoList[i].bugs.bug_type;
                BugDetails.bug_description = BugReportDtoList[i].bugs.bug_description;
                BugDetails.bug_project_id = BugReportDtoList[i].bugs.bug_project_id;
                BugDetails.bug_project_name = BugReportDtoList[i].projects.project_name;
                BugDetails.bug_project_manager_id = BugReportDtoList[i].users.user_id;
                BugDetails.bug_project_manager_name = BugReportDtoList[i].users.user_name;
                BugDetails.bug_file = BugReportDtoList[i].bugs.bug_file;
                BugDetails.bug_method = BugReportDtoList[i].bugs.bug_method;
                BugDetails.bug_line = BugReportDtoList[i].bugs.bug_line;
                BugDetails.bug_priority = BugReportDtoList[i].bugs.bug_priority;
                BugDetails.bug_severity = BugReportDtoList[i].bugs.bug_severity;
                BugDetails.bug_status = BugReportDtoList[i].bugs.bug_status;
                BugDetails.bug_tester_id = BugReportDtoList[i].bugs.bug_tester_id;
                i++;
                BugDetails.bug_tester_name = BugReportDtoList[i].users.user_name;
                if (BugReportDtoList[i].bugs.bug_developer_id != null)
                {
                    i++;
                    BugDetails.bug_developer_name = BugReportDtoList[i].users.user_name;
                }
                BugDetails.bug_developer_id = BugReportDtoList[i].bugs.bug_developer_id;
                BugDetails.bug_reject_reason = BugReportDtoList[i].bugs.bug_reject_reason;
                BugDetails.bug_screenshot = BugReportDtoList[i].bugs.bug_screenshot;
                BugDetails.bug_date = BugReportDtoList[i].bugs.bug_date;
                BugDetailsList.Add(BugDetails);
                i++;
            }
            return BugDetailsList;
        }
        public List<BugReportDto> GetBugsTester(string Type, UserDto User)
        {
            BugReportDto BugDetails;
            List<BugReportDto> BugDetailsList = new List<BugReportDto>();
            var bugReportDto = from bugs in entities.bugs
                               from projects in entities.projects
                               from users in entities.users.Where(x => (projects.project_id == bugs.bug_project_id && bugs.bug_tester_id == User.user_id) && (bugs.bug_tester_id == x.user_id || bugs.bug_developer_id == x.user_id || projects.project_manager_id == x.user_id) && bugs.bug_status == Type)
                               select new
                               {
                                   bugs,
                                   projects,
                                   users
                               };
            var BugReportDtoList = bugReportDto.ToList();
            int i = 0;

            while (i < BugReportDtoList.Count())
            {
                BugDetails = new BugReportDto();
                BugDetails.bug_id = BugReportDtoList[i].bugs.bug_id;
                BugDetails.bug_name = BugReportDtoList[i].bugs.bug_name;
                BugDetails.bug_type = BugReportDtoList[i].bugs.bug_type;
                BugDetails.bug_description = BugReportDtoList[i].bugs.bug_description;
                BugDetails.bug_project_id = BugReportDtoList[i].bugs.bug_project_id;
                BugDetails.bug_project_name = BugReportDtoList[i].projects.project_name;
                BugDetails.bug_project_manager_id = BugReportDtoList[i].users.user_id;
                BugDetails.bug_project_manager_name = BugReportDtoList[i].users.user_name;
                BugDetails.bug_file = BugReportDtoList[i].bugs.bug_file;
                BugDetails.bug_method = BugReportDtoList[i].bugs.bug_method;
                BugDetails.bug_line = BugReportDtoList[i].bugs.bug_line;
                BugDetails.bug_priority = BugReportDtoList[i].bugs.bug_priority;
                BugDetails.bug_severity = BugReportDtoList[i].bugs.bug_severity;
                BugDetails.bug_status = BugReportDtoList[i].bugs.bug_status;
                BugDetails.bug_tester_id = BugReportDtoList[i].bugs.bug_tester_id;
                i++;
                BugDetails.bug_tester_name = BugReportDtoList[i].users.user_name;
                if (BugReportDtoList[i].bugs.bug_developer_id != null)
                {
                    i++;
                    BugDetails.bug_developer_name = BugReportDtoList[i].users.user_name;
                }
                BugDetails.bug_developer_id = BugReportDtoList[i].bugs.bug_developer_id;
                BugDetails.bug_reject_reason = BugReportDtoList[i].bugs.bug_reject_reason;
                BugDetails.bug_screenshot = BugReportDtoList[i].bugs.bug_screenshot;
                BugDetails.bug_date = BugReportDtoList[i].bugs.bug_date;
                BugDetailsList.Add(BugDetails);
                i++;
            }
            return BugDetailsList;
        }
        public List<BugReportDto> GetBugsTesterTrack(string Type, UserDto User)
        {
            BugReportDto BugDetails;
            List<BugReportDto> BugDetailsList = new List<BugReportDto>();
            var bugReportDto = from bugs in entities.bugs
                               from projects in entities.projects
                               from users in entities.users.Where(x => (projects.project_id == bugs.bug_project_id && bugs.bug_tester_id == User.user_id) && (bugs.bug_tester_id == x.user_id || bugs.bug_developer_id == x.user_id || projects.project_manager_id == x.user_id))
                               select new
                               {
                                   bugs,
                                   projects,
                                   users
                               };
            var BugReportDtoList = bugReportDto.ToList();
            int i = 0;

            while (i < BugReportDtoList.Count())
            {
                BugDetails = new BugReportDto();
                BugDetails.bug_id = BugReportDtoList[i].bugs.bug_id;
                BugDetails.bug_name = BugReportDtoList[i].bugs.bug_name;
                BugDetails.bug_type = BugReportDtoList[i].bugs.bug_type;
                BugDetails.bug_description = BugReportDtoList[i].bugs.bug_description;
                BugDetails.bug_project_id = BugReportDtoList[i].bugs.bug_project_id;
                BugDetails.bug_project_name = BugReportDtoList[i].projects.project_name;
                BugDetails.bug_project_manager_id = BugReportDtoList[i].users.user_id;
                BugDetails.bug_project_manager_name = BugReportDtoList[i].users.user_name;
                BugDetails.bug_file = BugReportDtoList[i].bugs.bug_file;
                BugDetails.bug_method = BugReportDtoList[i].bugs.bug_method;
                BugDetails.bug_line = BugReportDtoList[i].bugs.bug_line;
                BugDetails.bug_priority = BugReportDtoList[i].bugs.bug_priority;
                BugDetails.bug_severity = BugReportDtoList[i].bugs.bug_severity;
                BugDetails.bug_status = BugReportDtoList[i].bugs.bug_status;
                BugDetails.bug_tester_id = BugReportDtoList[i].bugs.bug_tester_id;
                i++;
                BugDetails.bug_tester_name = BugReportDtoList[i].users.user_name;
                if (BugReportDtoList[i].bugs.bug_developer_id != null)
                {
                    i++;
                    BugDetails.bug_developer_name = BugReportDtoList[i].users.user_name;
                }
                BugDetails.bug_developer_id = BugReportDtoList[i].bugs.bug_developer_id;
                BugDetails.bug_reject_reason = BugReportDtoList[i].bugs.bug_reject_reason;
                BugDetails.bug_screenshot = BugReportDtoList[i].bugs.bug_screenshot;
                BugDetails.bug_date = BugReportDtoList[i].bugs.bug_date;
                BugDetailsList.Add(BugDetails);
                i++;
            }
            return BugDetailsList;
        }
        public List<BugReportDto> GetBugsDeveloper(string Type, UserDto User)
        {
            BugReportDto BugDetails;
            List<BugReportDto> BugDetailsList = new List<BugReportDto>();
            var bugReportDto = from bugs in entities.bugs
                               from projects in entities.projects
                               from users in entities.users.Where(x => (projects.project_id == bugs.bug_project_id && bugs.bug_developer_id == User.user_id) && (bugs.bug_tester_id == x.user_id || bugs.bug_developer_id == x.user_id || projects.project_manager_id == x.user_id) && bugs.bug_status == Type)
                               select new { bugs, projects, users };

            var BugReportDtoList = bugReportDto.ToList();
            int i = 0;

            while (i < BugReportDtoList.Count())
            {
                BugDetails = new BugReportDto();
                BugDetails.bug_id = BugReportDtoList[i].bugs.bug_id;
                BugDetails.bug_name = BugReportDtoList[i].bugs.bug_name;
                BugDetails.bug_type = BugReportDtoList[i].bugs.bug_type;
                BugDetails.bug_description = BugReportDtoList[i].bugs.bug_description;
                BugDetails.bug_project_id = BugReportDtoList[i].bugs.bug_project_id;
                BugDetails.bug_project_name = BugReportDtoList[i].projects.project_name;
                BugDetails.bug_project_manager_id = BugReportDtoList[i].users.user_id;
                BugDetails.bug_project_manager_name = BugReportDtoList[i].users.user_name;
                BugDetails.bug_file = BugReportDtoList[i].bugs.bug_file;
                BugDetails.bug_method = BugReportDtoList[i].bugs.bug_method;
                BugDetails.bug_line = BugReportDtoList[i].bugs.bug_line;
                BugDetails.bug_priority = BugReportDtoList[i].bugs.bug_priority;
                BugDetails.bug_severity = BugReportDtoList[i].bugs.bug_severity;
                BugDetails.bug_status = BugReportDtoList[i].bugs.bug_status;
                BugDetails.bug_tester_id = BugReportDtoList[i].bugs.bug_tester_id;
                i++;
                BugDetails.bug_tester_name = BugReportDtoList[i].users.user_name;
                if (BugReportDtoList[i].bugs.bug_developer_id != null)
                {
                    i++;
                    BugDetails.bug_developer_name = BugReportDtoList[i].users.user_name;
                }
                BugDetails.bug_developer_id = BugReportDtoList[i].bugs.bug_developer_id;
                BugDetails.bug_reject_reason = BugReportDtoList[i].bugs.bug_reject_reason;
                BugDetails.bug_screenshot = BugReportDtoList[i].bugs.bug_screenshot;
                BugDetails.bug_date = BugReportDtoList[i].bugs.bug_date;
                BugDetailsList.Add(BugDetails);
                i++;
            }
            return BugDetailsList;
        }
        public List<BugReportDto> GetBugsDeveloperHistory(string Type, UserDto User)
        {
            BugReportDto BugDetails;
            List<BugReportDto> BugDetailsList = new List<BugReportDto>();
            var bugReportDto = from bugs in entities.bugs
                               from projects in entities.projects
                               from users in entities.users.Where(x => (projects.project_id == bugs.bug_project_id && bugs.bug_developer_id == User.user_id) && (bugs.bug_tester_id == x.user_id || bugs.bug_developer_id == x.user_id || projects.project_manager_id == x.user_id))
                               select new { bugs, projects, users };

            var BugReportDtoList = bugReportDto.ToList();
            int i = 0;

            while (i < BugReportDtoList.Count())
            {
                BugDetails = new BugReportDto();
                BugDetails.bug_id = BugReportDtoList[i].bugs.bug_id;
                BugDetails.bug_name = BugReportDtoList[i].bugs.bug_name;
                BugDetails.bug_type = BugReportDtoList[i].bugs.bug_type;
                BugDetails.bug_description = BugReportDtoList[i].bugs.bug_description;
                BugDetails.bug_project_id = BugReportDtoList[i].bugs.bug_project_id;
                BugDetails.bug_project_name = BugReportDtoList[i].projects.project_name;
                BugDetails.bug_project_manager_id = BugReportDtoList[i].users.user_id;
                BugDetails.bug_project_manager_name = BugReportDtoList[i].users.user_name;
                BugDetails.bug_file = BugReportDtoList[i].bugs.bug_file;
                BugDetails.bug_method = BugReportDtoList[i].bugs.bug_method;
                BugDetails.bug_line = BugReportDtoList[i].bugs.bug_line;
                BugDetails.bug_priority = BugReportDtoList[i].bugs.bug_priority;
                BugDetails.bug_severity = BugReportDtoList[i].bugs.bug_severity;
                BugDetails.bug_status = BugReportDtoList[i].bugs.bug_status;
                BugDetails.bug_tester_id = BugReportDtoList[i].bugs.bug_tester_id;
                i++;
                BugDetails.bug_tester_name = BugReportDtoList[i].users.user_name;
                if (BugReportDtoList[i].bugs.bug_developer_id != null)
                {
                    i++;
                    BugDetails.bug_developer_name = BugReportDtoList[i].users.user_name;
                }
                BugDetails.bug_developer_id = BugReportDtoList[i].bugs.bug_developer_id;
                BugDetails.bug_reject_reason = BugReportDtoList[i].bugs.bug_reject_reason;
                BugDetails.bug_screenshot = BugReportDtoList[i].bugs.bug_screenshot;
                BugDetails.bug_date = BugReportDtoList[i].bugs.bug_date;
                BugDetailsList.Add(BugDetails);
                i++;
            }
            return BugDetailsList;
        }
    }
}