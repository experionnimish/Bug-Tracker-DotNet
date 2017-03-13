using BugTrackerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Tracker_Server.Data_Services
{
    public interface IGetBugsListService
    {
        List<BugReportDto> GetBugsAdmin(string Type, UserDto User);
        List<BugReportDto> GetBugsTester(string Type, UserDto User);
    }
}
