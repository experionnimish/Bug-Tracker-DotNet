using BugTrackerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using BugTrackerDTOs;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Bug_Tracker_Client.Controllers
{
    public class TesterController : Controller
    {
        // GET: Tester
        public ActionResult Tasks()
        {
            if (IsAuthenticated())
                return View();
            else
                return View("Login");
        }
        public async Task<ActionResult> ReportBugs()
        {
            if (IsAuthenticated())
            {
                var user = Session["User"];
                GetProjects((UserDto)user);
                return View();
            }
            else
                return View("Login");
        }
        public ActionResult ReviewBugs()
        {
            if (IsAuthenticated())
                return View();
            else
                return View("Login");
        }
        public ActionResult TrackBugs()
        {
            if (IsAuthenticated())
                return View();
            else
                return View("Login");
        }
        public bool IsAuthenticated()
        {
            var user = Session["User"] as UserDto;
            if (user != null && user.user_class == 1)
                return true;
            else
                return false;
        }
        public async void GetProjects(UserDto userObj)
        {
            HttpClient client = new HttpClient();
            var param = Newtonsoft.Json.JsonConvert.SerializeObject(userObj);
            HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");
            client.BaseAddress = new Uri("http://localhost:49380/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            List<SelectListItem> ProjectsList = new List<SelectListItem>();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.PostAsync(string.Format("Tester/GetProjects"), contentPost).Result;
            var responses = await response.Content.ReadAsStringAsync();
            ProjectsList = JsonConvert.DeserializeObject<List<SelectListItem>>(responses);
            if (ProjectsList != null)
            {
                ViewBag.ProjectsTester = ProjectsList;
            }
            else
            {
                ViewBag.ProjectsTester = null;
            }
        }
        public async Task<ActionResult> ReportBug(BugDto Bug)
        {
            HttpClient client = new HttpClient();
            var param = Newtonsoft.Json.JsonConvert.SerializeObject(Bug);
            HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");
            client.BaseAddress = new Uri("http://localhost:49380/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.PostAsync(string.Format("Tester/ReportBug"), contentPost).Result;
            var responses = await response.Content.ReadAsStringAsync();
            bool result = JsonConvert.DeserializeObject<bool>(responses);
            if (result == true)
            {
                ViewBag.BugReportStatus = "Success";
            }
            else
            {
                ViewBag.BugReportStatus = "Fail";
            }
            return View("ReportBugs");
        }
    }
}