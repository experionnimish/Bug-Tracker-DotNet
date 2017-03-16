using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrackerDTOs
{
    public class AddTeamDto
    {
        public int[] members { get; set; }
        public int project_id { get; set; }
        public int member_class { get; set; }
    }
}
