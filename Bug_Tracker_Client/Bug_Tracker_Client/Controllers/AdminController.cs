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
        public ActionResult ApproveResolvedBugs()
        {
            if (IsAuthenticated())
                return View();
            else
                return View("Login");
        }
        public async Task<ActionResult> ManageTesters()
        {
            if (IsAuthenticated())
            {
                var user = Session["User"];
                ViewBag.ManageTestersMessage = TempData["Message"];
                GetProjects((UserDto)user);
                return View();
            }
            else
                return View("Login");
        }
        public async Task<ActionResult> ManageDevelopers()
        {
            if (IsAuthenticated())
            {
                var user = Session["User"];
                ViewBag.ManageDevelopersMessage = TempData["Message"];
                GetProjects((UserDto)user);
                return View();
            }
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
                var response = client.PostAsync(string.Format("Admin/GetBugsList?Type=" + Type), contentPost).Result;
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
        public async Task<string> GetTeamMembers(int ProjectId, int UserClass)
        {
            HttpClient client = new HttpClient();
            UserDto user = (UserDto)Session["User"];
            var param = Newtonsoft.Json.JsonConvert.SerializeObject(user);
            HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");
            client.BaseAddress = new Uri("http://localhost:49380/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            List<MemberDto> MemberList = new List<MemberDto>();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.PostAsync(string.Format("Admin/GetTeamMembers?ProjectId=" + ProjectId +"&UserClass=" + UserClass), contentPost).Result;
            var responses = await response.Content.ReadAsStringAsync();
            MemberList = JsonConvert.DeserializeObject<List<MemberDto>>(responses);
            var MyListArray = MemberList.Cast<MemberDto>().ToArray();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var JSArray = serializer.Serialize(MyListArray);
            //System.Web.Script.Serialization.JavaScriptSerializer oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            if (MemberList != null)
            {
                //string MemberString = oSerializer.Serialize(MemberList);
                return JSArray;
            }
            else
            {
                return null;
            }
        }
        public async Task<string> GetTeamMembersAdd(int ProjectId, int UserClass)
        {
            HttpClient client = new HttpClient();
            UserDto user = (UserDto)Session["User"];
            var param = Newtonsoft.Json.JsonConvert.SerializeObject(user);
            HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");
            client.BaseAddress = new Uri("http://localhost:49380/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            List<MemberDto> MemberList = new List<MemberDto>();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.PostAsync(string.Format("Admin/GetTeamMembersAdd?ProjectId=" + ProjectId + "&UserClass=" + UserClass), contentPost).Result;
            var responses = await response.Content.ReadAsStringAsync();
            MemberList = JsonConvert.DeserializeObject<List<MemberDto>>(responses);
            var MyListArray = MemberList.Cast<MemberDto>().ToArray();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var JSArray = serializer.Serialize(MyListArray);
            //System.Web.Script.Serialization.JavaScriptSerializer oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            if (MemberList != null)
            {
                //string MemberString = oSerializer.Serialize(MemberList);
                return JSArray;
            }
            else
            {
                return null;
            }
        }
        public async Task<bool> AssignDeveloper(int DeveloperId, int BugId)
        {
                HttpClient client = new HttpClient();
                UserDto user = (UserDto)Session["User"];
                var param = Newtonsoft.Json.JsonConvert.SerializeObject(user);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");
                client.BaseAddress = new Uri("http://localhost:49380/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.PostAsync(string.Format("Admin/AssignDeveloper?DeveloperId=" + DeveloperId + "&BugId=" + BugId), contentPost).Result;
                var responses = await response.Content.ReadAsStringAsync();
                return (JsonConvert.DeserializeObject<bool>(responses));
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
            var response = client.PostAsync(string.Format("Admin/RejectBugs?RejectReason=" + RejectReason + "&BugStatus=" + BugStatus + "&BugId=" + BugId), contentPost).Result;
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
            var response = client.PostAsync(string.Format("Admin/ApproveBugs?BugStatus=" + BugStatus + "&BugId=" + BugId), contentPost).Result;
            var responses = await response.Content.ReadAsStringAsync();
            return (JsonConvert.DeserializeObject<bool>(responses));
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
            var response = client.PostAsync(string.Format("Admin/GetProjects"), contentPost).Result;
            var responses = await response.Content.ReadAsStringAsync();
            ProjectsList = JsonConvert.DeserializeObject<List<SelectListItem>>(responses);
            if (ProjectsList != null)
            {
                ViewBag.ProjectsAdmin = ProjectsList;
            }
            else
            {
                ViewBag.ProjectsAdmin = null;
            }
        }
        public async Task<ActionResult> AddTeamMembers(AddTeamDto Member)
        {
            HttpClient client = new HttpClient();
            var param = Newtonsoft.Json.JsonConvert.SerializeObject(Member);
            HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");
            client.BaseAddress = new Uri("http://localhost:49380/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.PostAsync(string.Format("Admin/AddTeamMembers"), contentPost).Result;
            var responses = await response.Content.ReadAsStringAsync();
            string Status = (JsonConvert.DeserializeObject<string>(responses));
            if(Status == "True")
            {
                TempData["Message"] = "SuccessAdd";
            }
            else
            {
                TempData["Message"] = "FailAdd";
            }
            if(Member.member_class == 2)
                return RedirectToAction("ManageDevelopers", "Admin");
            if (Member.member_class == 1)
                return RedirectToAction("ManageTesters", "Admin");
            else
                return View();
        }
        public async Task<ActionResult> RemoveTeamMembers(AddTeamDto Member)
        {
            HttpClient client = new HttpClient();
            var param = Newtonsoft.Json.JsonConvert.SerializeObject(Member);
            HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");
            client.BaseAddress = new Uri("http://localhost:49380/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.PostAsync(string.Format("Admin/RemoveTeamMembers"), contentPost).Result;
            var responses = await response.Content.ReadAsStringAsync();
            string Status = (JsonConvert.DeserializeObject<string>(responses));
            if (Status == "True")
            {
                TempData["Message"] = "SuccessRem";
            }
            else
            {
                TempData["Message"] = "FailRem";
            }
            if (Member.member_class == 2)
                return RedirectToAction("ManageDevelopers", "Admin");
            if (Member.member_class == 1)
                return RedirectToAction("ManageTesters", "Admin");
            else
                return View();
        }
    }
}