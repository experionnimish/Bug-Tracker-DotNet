using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrackerDTOs
{
    public class BugDto
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
}
