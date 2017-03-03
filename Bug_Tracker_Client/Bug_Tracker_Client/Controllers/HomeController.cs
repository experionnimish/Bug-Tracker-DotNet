using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BugTrackerDTOs;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Bug_Tracker_Client.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public async Task<ActionResult> Login(UserDto loginUser)
        {
            HttpClient client = new HttpClient();
            var param = Newtonsoft.Json.JsonConvert.SerializeObject(loginUser);
            HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");
            client.BaseAddress = new Uri("http://localhost:49380/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            UserDto myObject = new UserDto();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.PostAsync(string.Format("Home/Login"), contentPost).Result;
            var responses = await response.Content.ReadAsStringAsync();
            myObject = JsonConvert.DeserializeObject<UserDto>(responses);
            if (myObject != null)
            {
                return View("About");
            }
            else
            {
                ViewBag.LoginError = "Incorrect username or password!";
                return View("Index");
            }
        }
    }
}