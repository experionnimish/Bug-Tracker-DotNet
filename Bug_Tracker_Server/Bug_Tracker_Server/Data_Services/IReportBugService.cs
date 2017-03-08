using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugTrackerDTOs;

namespace Bug_Tracker_Server.Data_Services
{
    interface IReportBugService
    {
        bool ReportBug(BugDto Bug);
    }
}
