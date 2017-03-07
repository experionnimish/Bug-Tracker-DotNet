using Bug_Tracker_Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bug_Tracker_Server.Data_Services
{
    interface IGetProjectsService
    {
        List<SelectListItem> GetProjects(user userObj);
    }
}
