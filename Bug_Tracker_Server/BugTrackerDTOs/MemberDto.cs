using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrackerDTOs
{
    public class MemberDto
    {
        public int user_id { get; set; }
        public int user_employee_id { get; set; }
        public string user_name { get; set; }
        public int user_class { get; set; }
        public int project_id { get; set; }
        public string project_name { get; set; }
    }
}
