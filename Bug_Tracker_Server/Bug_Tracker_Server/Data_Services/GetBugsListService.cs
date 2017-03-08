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
        public List<BugReportDto> GetBugsList(UserDto User)
        {
            BugReportDto Bug;
            List<BugReportDto> BugList;
            //var dbQuery = "SELECT bugs.id AS bugID, bugs.name AS bugName, bugs.bug_type AS bugType, bugs.description AS description, bugs.file AS file, bugs.method AS method, bugs.line AS line, bugs.priority AS priority, bugs.severity AS severity, bugs.status AS status, projects.name AS projectName, users.name AS userName, bugs.screenshot AS screenshot, bugs.reject_reason AS reason, projects.id AS projectId, bugs.date AS date 
            //    FROM bugs
            //    JOIN projects
            //    JOIN users ON bugs.id = ?
            //    AND projects.id = bugs.project_id
            //    AND(bugs.tester_id = users.id OR bugs.developer_id = users.id OR projects.manager_id = users.id)
            //    ORDER BY users.class";

            var query = from t1 in entities.bugs
                        join t2 in entities.projects on t1.bug_project_id equals t2.project_id
                        join t3 in entities.users on new { first = t1.bug_tester_id, second = t1.bug_developer_id, third = t2.project_manager_id } equals new { first = t3.user_id, second = t3.user_id, third = t3.user_id }
                        select new BugReportDto
                        {
                            bug_name = t1.bug_name,
                            bug_type = t1.bug_type,
                            bug_description = t1.bug_description,
                            bug_project_id = t1.bug_project_id,
                            bug_project_name = t2.project_name,
                            bug_file = t1.bug_file,
                            bug_method = t1.bug_method,
                            bug_line = t1.bug_line,
                            bug_priority = t1.bug_priority,
                            bug_severity = t1.bug_severity,
                            bug_status = t1.bug_status,
                            bug_tester_id = t1.bug_tester_id,
                            bug_tester_name = t3.user_name,
                            bug_developer_id = t1.bug_developer_id,
                            bug_developer_name = t3.user_name,
                            bug_reject_reason = t1.bug_reject_reason,
                            bug_screenshot = t1.bug_screenshot,
                            bug_date = t1.bug_date
                        };


        }
    }
}