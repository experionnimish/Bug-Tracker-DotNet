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
        public bool RejectBugs(string RejectReason, string BugStatus, int BugId, UserDto User)
        {
            try
            {
                entities.bugs.Where(x => x.bug_id == BugId).FirstOrDefault().bug_status = BugStatus;
                entities.bugs.Where(x => x.bug_id == BugId).FirstOrDefault().bug_reject_reason = RejectReason;
                entities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool ApproveBugs(string BugStatus, int BugId, UserDto User)
        {
            try
            {
                entities.bugs.Where(x => x.bug_id == BugId).FirstOrDefault().bug_status = BugStatus;
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