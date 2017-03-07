using BugTrackerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bug_Tracker_Client.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Overview()
        {
            if (IsAuthenticated())
                return View();
            else
                return View("Login");
        }
        public ActionResult UnassignedBugs()
        {
            if (IsAuthenticated())
                return View();
            else
                return View("Login");
        }
        public ActionResult AssignedBugs()
        {
            if (IsAuthenticated())
                return View();
            else
                return View("Login");
        }
        public ActionResult ClosedBugs()
        {
            if (IsAuthenticated())
                return View();
            else
                return View("Login");
        }
        public ActionResult ApproveBugs()
        {
            if (IsAuthenticated())
                return View();
            else
                return View("Login");
        }
        public ActionResult ManageTesters()
        {
            if (IsAuthenticated())
                return View();
            else
                return View("Login");
        }
        public ActionResult ManageDevelopers()
        {
            if (IsAuthenticated())
                return View();
            else
                return View("Login");
        }
        public ActionResult ManageProjects()
        {
            if (IsAuthenticated())
                return View();
            else
                return View("Login");
        }
        public ActionResult AddUsers()
        {
            if (IsAuthenticated())
                return View();
            else
                return View("Login");
        }
        public ActionResult RemoveUsers()
        {
            if (IsAuthenticated())
                return View();
            else
                return View("Login");
        }
        public bool IsAuthenticated()
        {
            var user = Session["User"] as UserDto;
            if (user != null && user.user_class == 0)
                return true;
            else
                return false;
        }
    }
}