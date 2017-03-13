using Bug_Tracker_Server.Data;
using BugTrackerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bug_Tracker_Server.Data_Services
{
    public class UpdateBugsService : IUpdateBugsService
    {
        bug_trackerEntities entities = new bug_trackerEntities();
        public bool AssignDeveloper(int DeveloperId, int BugId, UserDto User)
        {
            try
            {
                entities.bugs.Where(x => x.bug_id == BugId).FirstOrDefault().bug_developer_id = DeveloperId;
                entities.bugs.Where(x => x.bug_id == BugId).FirstOrDefault().bug_status = "Assigned";
                entities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}