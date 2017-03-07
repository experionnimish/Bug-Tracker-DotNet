using BugTrackerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bug_Tracker_Client.Controllers
{
    public class DeveloperController : Controller
    {
        // GET: Developer
        public ActionResult BugReports()
        {
            if (IsAuthenticated())
                return View();
            else
                return View("Login");
        }
        public ActionResult BugHistory()
        {
            if (IsAuthenticated())
                return View();
            else
                return View("Login");
        }
        public ActionResult RejectedBugs()
        {
            if (IsAuthenticated())
                return View();
            else
                return View("Login");
        }
        public bool IsAuthenticated()
        {
            var user = Session["User"] as UserDto;
            if (user != null && user.user_class == 2)
                return true;
            else
                return false;
        }
    }
}