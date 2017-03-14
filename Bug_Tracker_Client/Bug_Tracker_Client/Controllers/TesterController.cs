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
        public async Task<ActionResult> EditBugDetails(BugDto Bug)
        {
            if (IsAuthenticated())
            {
                var user = Session["User"];
                GetProjects((UserDto)user);
                return View("EditBugDetails", Bug);
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
            if(ModelState.IsValid)
            {
                HttpClient client = new HttpClient();
                UserDto user = (UserDto)Session["User"];
                Bug.bug_tester_id = user.user_id;
                Bug.bug_status = "Open";
                Bug.bug_date = DateTime.Now;
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
                GetProjects((UserDto)Session["User"]);
                return View("ReportBugs");
            }
            else
            {
                ViewBag.BugReportStatus = "Fail";
                GetProjects((UserDto)Session["User"]);
                return View("ReportBugs");
            }
        }
        public async Task<ActionResult> GetBugsList(string Type)
        {
            if (Type != null)
            {
                HttpClient client = new HttpClient();
                UserDto user = (UserDto)Session["User"];
                var param = Newtonsoft.Json.JsonConvert.SerializeObject(user);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");
                client.BaseAddress = new Uri("http://localhost:49380/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                List<BugReportDto> BugsList = new List<BugReportDto>();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.PostAsync(string.Format("Tester/GetBugsList?Type=" + Type), contentPost).Result;
                var responses = await response.Content.ReadAsStringAsync();
                BugsList = JsonConvert.DeserializeObject<List<BugReportDto>>(responses);
                if (BugsList != null)
                {
                    ViewBag.Type = Type;
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
        public async Task<ActionResult> TrackBugsReport(string Type)
        {
            if (Type != null)
            {
                HttpClient client = new HttpClient();
                UserDto user = (UserDto)Session["User"];
                var param = Newtonsoft.Json.JsonConvert.SerializeObject(user);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");
                client.BaseAddress = new Uri("http://localhost:49380/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                List<BugReportDto> BugsList = new List<BugReportDto>();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.PostAsync(string.Format("Tester/TrackBugs?Type=" + Type), contentPost).Result;
                var responses = await response.Content.ReadAsStringAsync();
                BugsList = JsonConvert.DeserializeObject<List<BugReportDto>>(responses);
                if (BugsList != null)
                {
                    ViewBag.Type = Type;
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
        public async Task<bool> RejectBugs(string RejectReason, string BugStatus, int BugId)
        {
            HttpClient client = new HttpClient();
            UserDto user = (UserDto)Session["User"];
            var param = Newtonsoft.Json.JsonConvert.SerializeObject(user);
            HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");
            client.BaseAddress = new Uri("http://localhost:49380/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.PostAsync(string.Format("Tester/RejectBugs?RejectReason=" + RejectReason + "&BugStatus=" + BugStatus + "&BugId=" + BugId), contentPost).Result;
            var responses = await response.Content.ReadAsStringAsync();
            return (JsonConvert.DeserializeObject<bool>(responses));
        }
        public async Task<bool> ApproveBugs(string BugStatus, int BugId)
        {
            HttpClient client = new HttpClient();
            UserDto user = (UserDto)Session["User"];
            var param = Newtonsoft.Json.JsonConvert.SerializeObject(user);
            HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");
            client.BaseAddress = new Uri("http://localhost:49380/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.PostAsync(string.Format("Tester/ApproveBugs?BugStatus=" + BugStatus + "&BugId=" + BugId), contentPost).Result;
            var responses = await response.Content.ReadAsStringAsync();
            return (JsonConvert.DeserializeObject<bool>(responses));
        }
        public async Task<ActionResult> EditBug(BugDto Bug)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = new HttpClient();
                UserDto user = (UserDto)Session["User"];
                Bug.bug_tester_id = user.user_id;
                Bug.bug_status = "Open";
                Bug.bug_date = DateTime.Now;
                var param = Newtonsoft.Json.JsonConvert.SerializeObject(Bug);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");
                client.BaseAddress = new Uri("http://localhost:49380/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.PostAsync(string.Format("Tester/EditBug"), contentPost).Result;
                var responses = await response.Content.ReadAsStringAsync();
                bool result = JsonConvert.DeserializeObject<bool>(responses);
                if (result == true)
                {
                    ViewBag.BugEditStatus = "Success";
                }
                else
                {
                    ViewBag.BugEditStatus = "Fail";
                }
                return View("TrackBugs");
            }
            else
            {
                ViewBag.BugEditStatus = "Fail";
                return View("TrackBugs");
            }
        }
    }
}