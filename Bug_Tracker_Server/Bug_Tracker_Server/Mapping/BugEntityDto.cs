using Bug_Tracker_Server.Data;
using BugTrackerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bug_Tracker_Server.Mapping
{
    public class BugEntityDto
    {
        public static BugDto ToDto(bug bugobj)
        {
            BugDto bugDto = new BugDto();
            if (bugobj != null)
            {
                bugDto.bug_name = bugobj.bug_name;
                bugDto.bug_type = bugobj.bug_type;
                bugDto.bug_description = bugobj.bug_description;
                bugDto.bug_project_id = bugobj.bug_project_id;
                bugDto.bug_file = bugobj.bug_file;
                bugDto.bug_method = bugobj.bug_method;
                bugDto.bug_line = bugobj.bug_line;
                bugDto.bug_priority = bugobj.bug_priority;
                bugDto.bug_severity = bugobj.bug_severity;
                bugDto.bug_status = bugobj.bug_status;
                bugDto.bug_tester_id = bugobj.bug_tester_id;
                bugDto.bug_developer_id = bugobj.bug_developer_id;
                bugDto.bug_reject_reason = bugobj.bug_reject_reason;
                bugDto.bug_screenshot = bugobj.bug_screenshot;
                bugDto.bug_date = bugobj.bug_date;
            }
            return bugDto;
        }
        public static bug ToEntity(BugDto bugDto)
        {
            bug bugobj = new bug();
            if (bugDto != null)
            {
                bugobj.bug_id = bugDto.bug_id;
                bugobj.bug_name = bugDto.bug_name;
                bugobj.bug_type = bugDto.bug_type;
                bugobj.bug_description = bugDto.bug_description;
                bugobj.bug_project_id = bugDto.bug_project_id;
                bugobj.bug_file = bugDto.bug_file;
                bugobj.bug_method = bugDto.bug_method;
                bugobj.bug_line = bugDto.bug_line;
                bugobj.bug_priority = bugDto.bug_priority;
                bugobj.bug_severity = bugDto.bug_severity;
                bugobj.bug_status = bugDto.bug_status;
                bugobj.bug_tester_id = bugDto.bug_tester_id;
                bugobj.bug_developer_id = bugDto.bug_developer_id;
                bugobj.bug_reject_reason = bugDto.bug_reject_reason;
                bugobj.bug_screenshot = bugDto.bug_screenshot;
                bugobj.bug_date = bugDto.bug_date;

            }
            return bugobj;
        }
    }
}