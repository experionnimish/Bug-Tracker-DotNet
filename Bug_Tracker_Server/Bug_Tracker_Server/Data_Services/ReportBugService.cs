using Bug_Tracker_Server.Data;
using Bug_Tracker_Server.Mapping;
using BugTrackerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bug_Tracker_Server.Data_Services
{
    public class ReportBugService : IReportBugService
    {
        bug_trackerEntities entities = new bug_trackerEntities();
        public bool ReportBug(BugDto Bug)
        {
            try
            {
                var bug = BugEntityDto.ToEntity(Bug);
                entities.bugs.Add(bug);
                entities.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}