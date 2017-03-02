using Bug_Tracker_Server.Data;
using Bug_Tracker_Server.Data_Services;
using Bug_Tracker_Server.Mapping;
using BugTrackerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Bug_Tracker_Server.Controllers
{
    public class HomeController : ApiController
    {
        //public ActionResult Index()
        //{
        //    ViewBag.Title = "Home Page";
        //    return View();
        //}
        IAuthService IAuthService;
        public UserDto Login(user userObj)
        {
            IAuthService = new AuthService();
            return IAuthService.Login(userObj);
        }
    }
}
