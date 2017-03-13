using BugTrackerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Tracker_Server.Data_Services
{
    public interface IUpdateBugsService
    {
        bool AssignDeveloper(int DeveloperId, int BugId, UserDto User);
    }
}
