using BugTrackerDTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
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
        public async Task<ActionResult> GetBugsList(string Type)
        {
            if(Type == "Unassigned")
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:49380/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                List<BugReportDto> BugsList = new List<BugReportDto>();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(string.Format("Admin/GetBugsList")).Result;
                var responses = await response.Content.ReadAsStringAsync();
                BugsList = JsonConvert.DeserializeObject<List<BugReportDto>>(responses);
                if (BugsList != null)
                {
                    return View("_BugReport", BugsList);
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}