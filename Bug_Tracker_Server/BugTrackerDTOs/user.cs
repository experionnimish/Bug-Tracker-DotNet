using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrackerDTOs
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
}
