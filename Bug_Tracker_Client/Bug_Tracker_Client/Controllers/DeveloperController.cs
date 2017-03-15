using BugTrackerDTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
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
                var response = client.PostAsync(string.Format("Developer/GetBugsList?Type=" + Type), contentPost).Result;
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
        public async Task<bool> UpdateBugStatus(string BugStatus, int BugId)
        {
            HttpClient client = new HttpClient();
            UserDto user = (UserDto)Session["User"];
            var param = Newtonsoft.Json.JsonConvert.SerializeObject(user);
            HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");
            client.BaseAddress = new Uri("http://localhost:49380/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.PostAsync(string.Format("Developer/UpdateBugStatus?BugStatus=" + BugStatus + "&BugId=" + BugId), contentPost).Result;
            var responses = await response.Content.ReadAsStringAsync();
            return (JsonConvert.DeserializeObject<bool>(responses));
        }
        public async Task<ActionResult> BugHistoryReport(string Type)
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
                var response = client.PostAsync(string.Format("Developer/BugHistory?Type=" + Type), contentPost).Result;
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
        public async Task<ActionResult> RejectedBugsReport(string Type)
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
                var response = client.PostAsync(string.Format("Developer/RejectedBugs?Type=" + Type), contentPost).Result;
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
    }
}