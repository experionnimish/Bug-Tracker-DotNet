using Bug_Tracker_Server.Data;
using Bug_Tracker_Server.Mapping;
using BugTrackerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        public bool ChangeBugStatus(string BugStatus, int BugId, UserDto User)
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
        public bool EditBug(BugDto Bug)
        {
            try
            {
                var BugEdit = entities.bugs.Where(x => x.bug_id == Bug.bug_id).FirstOrDefault();
                BugDto BugEditDto = BugEntityDto.ToDto(BugEdit);
                foreach (PropertyInfo propertyInfo in typeof(bug).GetProperties())
                {
                    if (propertyInfo.CanRead)
                    {
                        object firstValue = propertyInfo.GetValue(BugEntityDto.ToEntity(Bug), null);
                        object secondValue = propertyInfo.GetValue(BugEntityDto.ToEntity(BugEditDto), null);
                        if (!object.Equals(firstValue, secondValue))
                        {
                            propertyInfo.SetValue(BugEdit, firstValue, null);
                        }
                    }
                }
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}