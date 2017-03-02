using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrackerDTOs
{
    public class ProjectDto
    {
        public int project_id { get; set; }
        public string project_name { get; set; }
        public int project_manager_id { get; set; }
        public string project_status { get; set; }
    }
}
