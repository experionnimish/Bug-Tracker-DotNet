using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrackerDTO
{
    public class user
    {
        public int user_id { get; set; }
        public int user_employee_id { get; set; }
        public string user_password { get; set; }
        public int user_class { get; set; }
        public string user_name { get; set; }
        public string user_email { get; set; }
        public int user_flag { get; set; }
    }
    public class bug
    {
        public int bug_id { get; set; }
        public string bug_name { get; set; }
        public string bug_type { get; set; }
        public string bug_description { get; set; }
        public int bug_project_id { get; set; }
        public string bug_file { get; set; }
        public string bug_method { get; set; }
        public int bug_line { get; set; }
        public string bug_priority { get; set; }
        public string bug_severity { get; set; }
        public string bug_status { get; set; }
        public int bug_tester_id { get; set; }
        public Nullable<int> bug_developer_id { get; set; }
        public string bug_reject_reason { get; set; }
        public string bug_screenshot { get; set; }
        public byte[] bug_date { get; set; }
    }
    public class project
    {
        public int project_id { get; set; }
        public string project_name { get; set; }
        public int project_manager_id { get; set; }
        public string project_status { get; set; }
    }
    public class project_team
    {
        public int team_sl_no { get; set; }
        public int team_project_id { get; set; }
        public int team_user_id { get; set; }
    }
}
